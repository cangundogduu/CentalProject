﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        List<Booking> TUserBookings(int id);
    }
}
