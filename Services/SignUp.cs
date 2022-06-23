﻿using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Data.Entity;
using Utilities;
using ViewModel;

namespace Services
{
   public class SignUp
    {
        private CoffeShopDbContext _Database = null;
        string AvatarPath = @"C:\Users\DINH LOC\source\repos\CoffeShop\CoffeShop\Assets\img\";
        public SignUp()
        {

           
            _Database = new CoffeShopDbContext();
        }
        public int Register(SignupViewModel user)
        {  
            var check=_Database.Accounts.FirstOrDefault(s=>s.UserName== user.UserName || s.Email==user.Email);
            if (check == null)
            {
                byte[] imgdata = System.IO.File.ReadAllBytes(AvatarPath + "Avatar.jpg");
              
                    Account account = new Account()
                    {
                        UserName = user.UserName,
                        Password = Encryptor.MD5Hash(user.Password),
                        Email = user.Email,
                        UserType = "Guest",
                        CreatedDate = DateTime.Now,
                        Image = imgdata

                    };
                Profile profile = new Profile()
                {
                    Address = "",
                    PhoneNumber = "",
                    FullName = "",
                    Account = account,
                };

                _Database.Accounts.Add(account);
                _Database.Profiles.Add(profile);
              
                    _Database.SaveChanges();

                //   ProfileService profileservice = new ProfileService();
                //profileservice.CreateNewProfile(account.AccountID);
        



                return account.AccountID;
            }
            else
            {
                return 0;
            }
           
        }
    }
}
