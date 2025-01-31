using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabServices;

namespace CabDatabase
{
    public class BookingRepository
    {
        private List<Booking> _bookings;
        public BookingRepository()
        {
            _bookings = new List<Booking>();
        }
        public void AddBooking(Booking booking)
        {
            _bookings.Add(booking);
        }
        public List<Booking> GetBookingsByUserId(int userId)
        {
            return _bookings.Where(b => b.UserId == userId).ToList();
        }
    }
}
