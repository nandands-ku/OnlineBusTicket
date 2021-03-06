﻿using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace OBTM.DataAccess
{
    public class DateWiseTripDataAccess : GenericDataAccess<DateWiseTrip> , IDateWiseTripRepository
    {
        public DateWiseTripDataAccess(OBTMDbContext context) : base(context)
        {
        }
        public List<DateWiseTrip> GetDateWiseByTrip(int id, DateTime date)
        {
            var DateWiseTripList= (from T in OBTMDbContext.DateWiseTrips where T.TripBaseId == id && T.Date==date.Date select T).ToList();
            return DateWiseTripList;
        }
        public IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId)
        {
            var dateWiseTripList = OBTMDbContext.DateWiseTrips.Where(dWTrip => dWTrip.TripBaseId == tripId && dWTrip.IsDeleted!=true).ToList();
            return dateWiseTripList;
        }

        public int GetNumOfNotBookedSeats(int DateWiseTripId)
        {
            int bookedSeatCount = OBTMDbContext.BookingTickets.Where(bt => bt.DateWiseTripId == DateWiseTripId && bt.IsBooked == false).Count();
            return bookedSeatCount;
        }

        public bool IsSeatsReducible(int NoOfSeats, int DateWiseTripId)
        {
            bool status = false;

            int bookedSeatCount = OBTMDbContext.BookingTickets.Where(bt => bt.DateWiseTripId == DateWiseTripId && bt.IsBooked == true).Count();
            if (bookedSeatCount >= NoOfSeats)
                status = false;
            else
                status = true;

            return status;
        }

        public int SoftDelete(int id)
        {
            DateWiseTrip dateWiseTrip = OBTMDbContext.DateWiseTrips.Find(id);
            bool isAnySeatPurchased = OBTMDbContext.BookingTickets.Where(bt => bt.DateWiseTripId == dateWiseTrip.Id && bt.IsBooked == true).Any();
            if (isAnySeatPurchased)
            {
                return -1;
            }
            else
            {
                dateWiseTrip.IsDeleted = true;
                OBTMDbContext.Entry(dateWiseTrip).State = EntityState.Modified;
                return OBTMDbContext.SaveChanges();
            }
            
        }
    }
}
