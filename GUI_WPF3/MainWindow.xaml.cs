namespace GUI_WPF3
{
   using System.IO;
   using nwp.marhei.mobilephoneLibary.Parser;
   using System.Windows;

   using Microsoft.Win32;

   using nwp.marhei.mobilephoneLibary;
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      MobilePhoneList mbList = new MobilePhoneList();
      public MainWindow()
      {
         InitializeComponent();
         ClearInputForHandy();
         textBoxProducer.Focus();
         listViewMobilePhoneList.ItemsSource = mbList;
      }

      private void buttonAddMobilephone_Click(object sender, RoutedEventArgs e)
      {
         Mobilephone h = new Mobilephone
         {
            Model = textBoxModel.Text,
            Price = double.Parse(textBoxPrice.Text),
            Producer = textBoxProducer.Text,
            SerialNumber = textBoxSerial_Number.Text
         };
         mbList.AddHandy(h);
         listViewMobilePhoneList.Items.Refresh();
         ClearInputForHandy();
      }

      private void ClearInputForHandy()
      {
         textBoxProducer.Text = string.Empty;
         textBoxModel.Text = string.Empty;
         textBoxSerial_Number.Text = string.Empty;
         textBoxPrice.Text = string.Empty;

      }

      private void buttonSaveList_Click(object sender, RoutedEventArgs e)
      {
         SaveFileDialog dialog = new SaveFileDialog();
         dialog.Filter = "fileTypes with serializer (DAT, XML)|*.DAT;*.XML";

         if (dialog.ShowDialog() == true)
         {
            if (Path.GetExtension(dialog.FileName) == ".dat")
            {
               new BinaryParser().ToFile(dialog.FileName, mbList);
            }
            else if (Path.GetExtension(dialog.FileName) == ".xml")
            {
               new XmlParser().ToFile(dialog.FileName, mbList);
            }
         }
      }

      private void buttonLoadList_Click(object sender, RoutedEventArgs e)
      {
         OpenFileDialog dialog = new OpenFileDialog();
         dialog.Filter = "Serialized Files (DAT, XML)|*.DAT;*.XML;";

         if (dialog.ShowDialog() == true)
         {
            if (Path.GetExtension(dialog.FileName) == ".dat")
            {
               mbList.AddRange(new BinaryParser().FromFile<MobilePhoneList>(dialog.FileName));
               listViewMobilePhoneList.Items.Refresh();
            }
            else if (Path.GetExtension(dialog.FileName) == ".xml")
            {
               mbList.AddRange(new XmlParser().FromFile<MobilePhoneList>(dialog.FileName));
               listViewMobilePhoneList.Items.Refresh();

            }

         }
      }
   }
}
