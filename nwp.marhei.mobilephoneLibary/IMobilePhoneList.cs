namespace nwp.marhei.mobilephoneLibary
{
   public interface IMobilePhoneList
   {
      void AddHandy(Mobilephone newHandy);
      MobilePhoneList GetCheapestMobilePhones();
      Mobilephone GetHandy(string serialNumber);
      MobilePhoneList Search(string producer);
      string ToString();
   }
}