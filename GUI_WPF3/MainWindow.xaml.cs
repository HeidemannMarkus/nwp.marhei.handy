namespace GUI_WPF3
{
   using System.Windows;

   using nwp.marhei.mobilephoneLibary;
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
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
         System.Console.WriteLine(h);

      }
   }
}
