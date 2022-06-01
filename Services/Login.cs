using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ViewModel;

namespace Services
{
    public class Login
    {
        private CoffeShopDbContext _Database = null;
        public Login()
        {

            _Database = new CoffeShopDbContext();
        }
        public UserResponse UserLogin(AccountViewModel user)
        {
            user.Password = Encryptor.MD5Hash(user.Password);
            var response =_Database.Accounts.Where(s => s.UserName.Equals(user.UserName) && s.Password.Equals(user.Password))
               .Select(s => new UserResponse()
               { UserName = s.UserName,
                   UserType = s.UserType,
                   AccountID=s.AccountID
               })
               .FirstOrDefault();
            
                return response;
           
           
            
        }
    }
}
