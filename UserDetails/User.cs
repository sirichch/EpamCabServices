using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabServices
{
    internal class User
    {
        public int UserId {  get; set; }
        public string UserName { get; set; }
        public List<Feedback> FeedbackList { get; set; }

        public User(int userid, string name) 
        {
            UserId = userid;
            UserName = name;
            FeedbackList = new List<Feedback>();
        }
        public void BookCab(int cabid, DateTime bookingtime)
        {
            Console.WriteLine($"Booking Cab {cabid} at {bookingtime} ...");
        }
        public void GiveFeedback(int cabid, string feedbacktext)
        {
            FeedbackList.Add(new Feedback(cabid, this.UserId, feedbacktext));
            Console.WriteLine("Feedback Submitted.");
        }
    }
}
