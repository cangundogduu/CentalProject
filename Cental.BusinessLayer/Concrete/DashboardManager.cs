using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class DashboardManager(IDashboardDal _dashboardDal) : IDashboardService
    {
        public int TApprovedBookingCount()
        {
            return _dashboardDal.ApprovedBookingCount();
        }

        public int TDeclineBookingCount()
        {
            return _dashboardDal.DeclineBookingCount();
        }

        public List<Car> TGetLastAddedCars()
        {
            return _dashboardDal.GetLastAddedCars();
        }

        public List<Booking> TGetLastBookings()
        {
            return _dashboardDal.GetLastBookings();
        }

        public int TGetMessageCount()
        {
            return _dashboardDal.GetMessageCount();
        }

        public List<Message> TGetMessages()
        {
            return _dashboardDal.GetMessages();
        }

        public int TGetReviewCount()
        {
            return _dashboardDal.GetReviewCount();
        }

        public List<Testimonial> TGetTestimonials()
        {
            return _dashboardDal.GetTestimonials();
        }

        public int TGetTotalBrands()
        {
            return _dashboardDal.GetTotalBrands();
        }

        public int TGetTotalCars()
        {
            return _dashboardDal.GetTotalCars();
        }

        public int TGetTotalUsers()
        {
            return _dashboardDal.GetTotalUsers();
        }

        public int TWaitingBookingCount()
        {
            return _dashboardDal.WaitingBookingCount();
        }
    }
}
