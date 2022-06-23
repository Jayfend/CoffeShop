using CoffeShopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class ReviewService
    {
        private CoffeShopDbContext _Database = null;
        public ReviewService()
        {
            _Database = new CoffeShopDbContext();
        }
        public bool ReceiveReview(ContactViewModel review)
        {
            Contact contact = new Contact()
            {
                Name = review.Name,
                Email = review.Email,
                Subject = review.Subject,
                Message = review.Message,
                CreatedDate = DateTime.Now
            };
            _Database.Contacts.Add(contact);
            _Database.SaveChanges();
            return true;
        }
        public List<ContactViewModel> getReviews()
        {
            return _Database.Contacts.Select(x => new ContactViewModel()
            {
               Name=x.Name,
               Email=x.Email,
               Subject=x.Subject,
               Message=x.Message,
               CreateDate=x.CreatedDate,
            }).ToList();
        }
    
    }
}
