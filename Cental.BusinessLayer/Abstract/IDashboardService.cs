using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IDashboardService
    {
        int TGetTotalUsers();
        int TGetTotalCars();
        int TGetTotalBrands();
        int TGetReviewCount();
        List<Car> TGetLastAddedCars();
        List<Booking> TGetLastBookings();
        int TApprovedBookingCount();
        int TWaitingBookingCount();
        int TDeclineBookingCount();
        List<Message> TGetMessages();
        List<Testimonial> TGetTestimonials();
        int TGetMessageCount();
    }
}
