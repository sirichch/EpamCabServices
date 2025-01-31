using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabService.Core.Services;
using CabServices;

namespace CabServices
{
    class Program
    {
        static void Main()
        {
            var cabService = new CabService.Core.Services.CabService();
            var userService = new UserService();
            var managerService = new ManagerService();

            while (true)
            {
                Console.WriteLine("1. Book Cab\n2. Cancel Cab\n3. Give Feedback\n4. Add Cab (Manager)\n5. Send Cab to Repair\n6. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Cab ID:");
                        int cabId = int.Parse(Console.ReadLine());
                        cabService.BookCab(1, cabId);
                        break;
                    case "2":
                        Console.WriteLine("Enter Cab ID:");
                        cabId = int.Parse(Console.ReadLine());
                        cabService.CancelCab(cabId);
                        break;
                    case "3":
                        Console.WriteLine("Enter Cab ID & Feedback:");
                        cabId = int.Parse(Console.ReadLine());
                        string feedback = Console.ReadLine();
                        userService.GiveFeedback(cabId, feedback);
                        break;
                    case "6":
                        return;
                }
            }
        }
    }
}
