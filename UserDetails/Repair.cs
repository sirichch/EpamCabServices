using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabServices
{
    public class Repair
    {
        public int RepairId {  get; set; }
        public DateTime RepairDate { get; set; }
        public string RepairStatus { get; set; }

        public Repair(int repairId, DateTime repairDate)
        {
            RepairId = repairId;
            RepairDate = repairDate;
            RepairStatus = "Under Repair";
        }
        public void MarkAsRepaired()
        {
            RepairStatus = "Repaired";
        }
    }
}
