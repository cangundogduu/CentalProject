using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfDashboardDal(CentalContext _centalContext) : IDashboardDal
    {
        public int ApprovedBookingCount()
        {
            return _centalContext.Bookings.Where(x => x.IsApproved == true).Count();
        }

        public int DeclineBookingCount()
        {
            return _centalContext.Bookings.Where(x => x.IsApproved == false).Count();
        }

        public List<Car> GetLastAddedCars()
        {
            var cars = _centalContext.Cars
                .OrderByDescending(x => x.CarId)
                .Take(5)
                .ToList();
            return cars;
        }

        public List<Booking> GetLastBookings()
        {
            var bookings = _centalContext.Bookings
                .OrderByDescending(x => x.BookingId)
                .Take(5)
                .ToList();
            return bookings;
        }

        public int GetMessageCount()
        {
            return _centalContext.Messages.Count();
        }

        public List<Message> GetMessages()
        {
            var messages = _centalContext.Messages
                .OrderByDescending(x => x.MessageId)
                .Take(5)
                .ToList();
            return messages;
        }

        public int GetReviewCount()
        {
            return _centalContext.Reviews.Count();
        }

        public List<Testimonial> GetTestimonials()
        {
            var testimonials = _centalContext.Testimonials
                .OrderByDescending(x => x.TestimonialId)
                .Take(5)
                .ToList();
            return testimonials;
        }

        public int GetTotalBrands()
        {
            return _centalContext.Brands.Count();
        }

        public int GetTotalCars()
        {
            return _centalContext.Cars.Count();
        }

     

        public int GetTotalUsers()
        {
            return _centalContext.Users.Count();
        }

        public int WaitingBookingCount()
        {
            return _centalContext.Bookings
                .Where(x => x.IsApproved == null)
                .Count();
        }
    }
}
