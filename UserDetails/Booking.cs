using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabServices
{
    public class Booking
    {
        public int BookingId {  get; set; }
        public int UserId { get; set; }
        public int CabId {  get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; }

        public Booking(int bookingId, int userId, int cabId, DateTime bookingTime)
        {
            BookingId = bookingId;
            UserId = userId;
            CabId = cabId;
            BookingTime = bookingTime;
            Status = "Booked";
        }
        public void CancelBooking()
        {
            Status = "Cancelled";
        }
    }
}
