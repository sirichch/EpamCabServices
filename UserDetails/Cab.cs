using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CabServices
{
    public class Cab
    {
        public int CabId { get; set; }
        public int Seats {  get; set; }
        public bool IsAvailable {  get; set; }
        public Repair repairDetails { get; set; }

        public Cab(int cabId, int seats)
        {
            CabId = cabId;
            Seats = seats;
            IsAvailable = true;
            repairDetails = null;
        }
        public void SendForRepair(Repair repair)
        {
            IsAvailable = false;
            repairDetails = repair;
        }
        public void MarkAsAvailable()
        {
            IsAvailable = true;
            repairDetails = null;
        }
    }
}
