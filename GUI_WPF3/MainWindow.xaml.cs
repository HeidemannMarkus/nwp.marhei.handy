using System;

namespace GUI_WPF3
{
   using System.Windows;

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
         ClearInputForHandy();
         listViewMobilePhoneList.Items.Refresh();
      }

      private void ClearInputForHandy()
      {
         textBoxProducer.Text = string.Empty;
         textBoxModel.Text = string.Empty;
         textBoxSerial_Number.Text = string.Empty;
         textBoxPrice.Text = string.Empty;

      }
   }
}
