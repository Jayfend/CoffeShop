using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class ProfileService
    {
        private CoffeShopDbContext _Database = null;
        public  ProfileService()
        {
            _Database = new CoffeShopDbContext();
        }
        public bool ProfileChanges(ProfileViewModel profile,int AccountID)
        {
            var getprofile = _Database.Profiles.FirstOrDefault(s => s.AccountId == AccountID);
           
                getprofile.FullName = profile.FullName;
                getprofile.PhoneNumber = profile.PhoneNumber;
                getprofile.Address = profile.Address;

                getprofile.Image = profile.Image;
                _Database.Profiles.Add(getprofile);
                _Database.SaveChanges();
                return true;  
            
            
        }
       
    }
}
