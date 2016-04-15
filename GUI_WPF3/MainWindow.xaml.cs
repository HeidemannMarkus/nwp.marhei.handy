using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using nwp.marhei.mobilephoneLibary;
using nwp.marhei.mobilephoneLibary.Parser;

namespace GUI_WPF3
{
   /// <summary>
   ///    Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private readonly MobilePhoneList mbList = new MobilePhoneList();

      public MainWindow()
      {
         InitializeComponent();
         ClearInputForHandy();
         TextBoxProducer.Focus();
         ListViewMobilePhoneList.ItemsSource = mbList;
      }

      private void buttonAddMobilephone_Click(object sender, RoutedEventArgs e)
      {
         var h = new Mobilephone
         {
            Model = TextBoxModel.Text,
            Price = double.Parse(TextBoxPrice.Text),
            Producer = TextBoxProducer.Text,
            SerialNumber = TextBoxSerialNumber.Text
         };
         mbList.AddHandy(h);
         ListViewMobilePhoneList.Items.Refresh();
         ClearInputForHandy();
      }

      private void ClearInputForHandy()
      {
         TextBoxProducer.Text = string.Empty;
         TextBoxModel.Text = string.Empty;
         TextBoxSerialNumber.Text = string.Empty;
         TextBoxPrice.Text = string.Empty;
      }

      private void buttonSaveList_Click(object sender, RoutedEventArgs e)
      {
         var dialog = new SaveFileDialog();
         dialog.Filter = "fileTypes with serializer (DAT, XML, JSON, CSV)|*.DAT;*.XML; .JSON; *.CSV";
         if (dialog.ShowDialog() == true)
         {
            switch (Path.GetExtension(dialog.FileName))
            {
               case ".dat":
                  new BinaryParser().ToFile(dialog.FileName, mbList);
                  break;
               case ".xml":
                  new XmlParser().ToFile(dialog.FileName, mbList);
                  break;
               case ".json":
                  new JsonParser().ToFile(dialog.FileName, mbList);
                  break;
               case ".csv":
                  new MobilePhoneListCsvParser().ToFile(dialog.FileName, mbList);
                  break;
               default:
                  Console.WriteLine("Format Unbekannt!!!!");
                  break;
            }
         }
      }

      private void buttonLoadList_Click(object sender, RoutedEventArgs e)
      {
         var dialog = new OpenFileDialog();
         dialog.Filter = "Serialized Files (DAT, XML, JSON)|*.DAT;*.XML; .JSON;";
         if (dialog.ShowDialog() == true)
         {
            switch (Path.GetExtension(dialog.FileName))
            {
               case ".dat":
                  mbList.AddRange(new BinaryParser().FromFile<MobilePhoneList>(dialog.FileName));
                  ListViewMobilePhoneList.Items.Refresh();
                  break;
               case ".xml":
                  mbList.AddRange(new XmlParser().FromFile<MobilePhoneList>(dialog.FileName));
                  ListViewMobilePhoneList.Items.Refresh();
                  break;
               case ".json":
                  mbList.AddRange(new JsonParser().FromFile<MobilePhoneList>(dialog.FileName));
                  ListViewMobilePhoneList.Items.Refresh();
                  break;
               default:
                  Console.WriteLine("Format Unbekannt!!!!");
                  break;
            }
         }
      }
   }
}
