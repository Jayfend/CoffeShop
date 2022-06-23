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
                 //byte[] imgdata = System.IO.File.ReadAllBytes(@"C:\Users\DINH LOC\source\repos\CoffeShop\CoffeShop\Assets\img\Avatar.jpg");
                
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
