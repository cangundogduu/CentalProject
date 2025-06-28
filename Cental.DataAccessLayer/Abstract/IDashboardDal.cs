using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IDashboardDal
    {
        int GetTotalUsers();
        int GetTotalCars();
        int GetTotalBrands();
        int GetReviewCount();
        List<Car> GetLastAddedCars();
        List<Booking> GetLastBookings();
        int ApprovedBookingCount(); 
        int WaitingBookingCount(); 
        int DeclineBookingCount(); 
        List<Message> GetMessages();
        List<Testimonial> GetTestimonials();
        int GetMessageCount();

    }
}
