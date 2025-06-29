﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IBookingDal: IGenericDal<Booking>
    {
        List<Booking> UsersBookings(int id);
    }
}
