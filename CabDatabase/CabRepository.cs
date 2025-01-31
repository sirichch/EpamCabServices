using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabServices;

namespace CabDatabase
{
    public class CabRepository
    {
        private List<Cab> _cabs;
        public CabRepository()
        {
            _cabs = new List<Cab>();
        }
        public void AddCab(Cab cab)
        {
            _cabs.Add(cab);
        }
        public List<Cab> GetAllCabs()
        {
            return _cabs;
        }
        public Cab GetCabById(int id)
        {
            return _cabs.FirstOrDefault(c => c.CabId == id);
        }
    }
}
