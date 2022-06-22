﻿using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Utilities;
using ViewModel;

namespace Services
{
   public class SignUp
    {
        private CoffeShopDbContext _Database = null;
        public SignUp()
        {
           
            _Database = new CoffeShopDbContext();
        }
        public  bool Register(SignupViewModel user)
        {  
            var check=_Database.Accounts.FirstOrDefault(s=>s.UserName== user.UserName || s.Email==user.Email);
            if (check == null)
            {
                Account account = new Account()
                {
                    UserName = user.UserName,
                    Password = Encryptor.MD5Hash(user.Password),
                    Email = user.Email,
                    UserType = "Guest",
                    CreatedDate = DateTime.Now
                };
                 byte[] imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\source\repos\CoffeShop\CoffeShop\Assets\img\Avatar.jpg");
                Profile profile = new Profile()
                {
                    FullName = "",
                    Address = "",
                    PhoneNumber = 0,
                    AccountId = account.AccountID,
                    Image = imgdata
                };
                _Database.Profiles.Add(profile);
                _Database.Accounts.Add(account);
                _Database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
