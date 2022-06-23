using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
            var getprofile = _Database.Profiles.Include(s=>s.Account).FirstOrDefault(s => s.AccountId == AccountID);
           if(getprofile != null)
            {
                getprofile.FullName = profile.FullName;
                getprofile.PhoneNumber = profile.PhoneNumber;
                getprofile.Address = profile.Address;
                if (profile.Image.Length > 0)
                {
                    getprofile.Account.Image = profile.Image;
                }
               
                _Database.SaveChanges();
                return true;
            }
            else
            {   
                if (profile.Image.Length > 0)
                {
                    var getaccount = _Database.Accounts.FirstOrDefault(s => s.AccountID == AccountID);
                    getaccount.Image = profile.Image;
                    Profile newprofile = new Profile()
                    {
                        FullName = profile.FullName,
                        PhoneNumber = profile.PhoneNumber,
                        Address = profile.Address,
                        Account = getaccount,

                    };
                    _Database.Profiles.Add(newprofile);
                    _Database.SaveChanges();
                }
                else
                {
                    var getaccount = _Database.Accounts.FirstOrDefault(s => s.AccountID == AccountID);
                    Profile newprofile = new Profile()
                    {
                        FullName = profile.FullName,
                        PhoneNumber = profile.PhoneNumber,
                        Address = profile.Address,
                        Account= getaccount,

                    };
                    _Database.Profiles.Add(newprofile);
                    _Database.SaveChanges();
                }
                
                return true;
            }
            
            
        }
        public string GetFullName(int AccountId)
        {
            var response = _Database.Profiles.Where(s => s.AccountId == AccountId).FirstOrDefault();
            if (response.FullName != null)
            {
                return response.FullName;
            }
            else
            {
                response.FullName ="";
                return response.FullName;
            }
          

        }
        public string GetAddress(int AccountId)
        {
            var response = _Database.Profiles.Where(s => s.AccountId == AccountId).FirstOrDefault();

            if (response.Address != null)
            {
                return response.Address;
            }
            else
            {
                response.Address = "";
                return response.Address;
            }

        }
        public string GetPhone(int AccountId)
        {
            var response = _Database.Profiles.Where(s => s.AccountId == AccountId).FirstOrDefault();

            if (response.PhoneNumber != null)
            {
                return response.PhoneNumber;
            }
            else
            {
                response.PhoneNumber = "";
                return response.Address;
            }

        }
        public ProfileViewModel getProfile(int AccountId)
        {
            var response = _Database.Profiles.Include(s => s.Account).FirstOrDefault(s => s.AccountId == AccountId);
            ProfileViewModel profile = new ProfileViewModel();
            profile.Address = response.Address;
            profile.PhoneNumber=response.PhoneNumber;
            profile.FullName = response.FullName;
            return profile;
        }
        public void CreateNewProfile(int AccountId)
        {
            var account = _Database.Accounts.Where(s => s.AccountID == AccountId).FirstOrDefault();

            
            Profile profile = new Profile()
            {
                FullName = "",
                PhoneNumber = "",
                Address = "",
                Account = account


            };

            _Database.Profiles.Add(profile);
            _Database.SaveChanges();
        }
    }
}
