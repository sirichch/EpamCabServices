using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabServices
{
    public class Manager
    {
        public int ManagerId {  get; set; }
        public List<Cab> Cabs {  get; set; }
        public List<Feedback> FeedbackList { get; set; }

        public Manager(int managerid)
        {
            ManagerId = managerid;
            Cabs = new List<Cab>();
            FeedbackList = new List<Feedback>();
        }

        public void AddCab(Cab cab)
        {
            Cabs.Add(cab);
            Console.WriteLine($"Cab {cab.CabId} added to the fleet.");
        }
        public void ReviewFeedback()
        {
            foreach(var feedback in FeedbackList)
            {
                Console.WriteLine($"Feedback for {feedback.CabId} is {feedback.FeedbackText}.");
            }
        }
        public void SendCabForRepair(Cab cab, Repair repair)
        {
            cab.SendForRepair(repair);
            Console.WriteLine($"Cab {cab.CabId} sent for repair.");
        } 
        
    }
}
