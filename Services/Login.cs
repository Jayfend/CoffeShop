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
        public bool UserLogin(AccountViewModel user)
        {
            user.Password=Encryptor.MD5Hash(user.Password);
            var check = _Database.Accounts.FirstOrDefault(s => s.UserName.Equals(user.UserName) && s.Password.Equals(user.Password));
            if(check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
