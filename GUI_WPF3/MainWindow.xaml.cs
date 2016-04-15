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
         textBoxProducer.Focus();
         listViewMobilePhoneList.ItemsSource = mbList;
      }

      private void buttonAddMobilephone_Click(object sender, RoutedEventArgs e)
      {
         var h = new Mobilephone
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
         var dialog = new SaveFileDialog();
         dialog.Filter = "fileTypes with serializer (DAT, XML, JSON)|*.DAT;*.XML; .JSON;";
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
                  listViewMobilePhoneList.Items.Refresh();
                  break;
               case ".xml":
                  mbList.AddRange(new XmlParser().FromFile<MobilePhoneList>(dialog.FileName));
                  listViewMobilePhoneList.Items.Refresh();
                  break;
               case ".json":
                  mbList.AddRange(new JsonParser().FromFile<MobilePhoneList>(dialog.FileName));
                  listViewMobilePhoneList.Items.Refresh();
                  break;
               default:
                  Console.WriteLine("Format Unbekannt!!!!");
                  break;
            }
         }
      }
   }
}
