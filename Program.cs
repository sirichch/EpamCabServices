using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabServices;
using CabDatabase;

namespace EpamCabServices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cabRepo = new CabRepository();
            var bookingRepo = new BookingRepository();

            while (true)
            {
                // Show Role Selection Prompt (User or Manager)
                Console.WriteLine("Select your role:");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Manager");
                Console.WriteLine("3. Exit");
                int roleOption = int.Parse(Console.ReadLine());

                if (roleOption == 1)
                {
                    // User Role
                    ShowUserOptions(cabRepo, bookingRepo);
                }
                else if (roleOption == 2)
                {
                    // Manager Role
                    var manager = new Manager(1); // Assuming Manager ID is 1
                    ShowManagerOptions(manager, cabRepo, bookingRepo);
                }
                else if (roleOption == 3)
                {
                    Console.WriteLine("Exiting...");
                    break; // Exit the loop and the program
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        static void ShowUserOptions(CabRepository cabrepo, BookingRepository bookingrepo)
        {

            Console.WriteLine("Welcome to EPAM CAB SERVICES !!");
            while (true)
            {
                Console.WriteLine("1. Book a cab");
                Console.WriteLine("2. cancel your cab");
                Console.WriteLine("3. Give feedback");
                Console.WriteLine("4. Back to role selection");
                Console.WriteLine("5. Exit");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        BookCab(cabrepo, bookingrepo);
                        break;
                    case 2:
                        CancelCab(bookingrepo);
                        break;
                    case 3:
                        GiveFeedback();
                        break;
                    case 4:
                        return;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, Please try again.");
                        break;
                }
            }
        }
        static void ShowManagerOptions(Manager manager, CabRepository cabRepo, BookingRepository bookingRepo)
        {
            Console.WriteLine("Welcome to Cab Service (Manager)");

            while (true)
            {
                Console.WriteLine("1. Add a Cab");
                Console.WriteLine("2. Review Feedback");
                Console.WriteLine("3. Back to role selection");
                Console.WriteLine("4. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddCab(cabRepo);
                        break;
                    case 2:
                        ReviewFeedback(manager);
                        break;
                    case 3:
                        return;
                    case 4:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        static void BookCab(CabRepository cabRepo, BookingRepository bookingRepo)
        {
            Console.WriteLine("Available cabs:");
            var cabs = cabRepo.GetAllCabs();
            foreach (var cab in cabs)
            {
                Console.WriteLine($"ID: {cab.CabId}, Available: {cab.IsAvailable}");
            }

            Console.WriteLine("Enter Cab ID to book:");
            int cabId = int.Parse(Console.ReadLine());

            var cabToBook = cabRepo.GetCabById(cabId);
            if (cabToBook != null && cabToBook.IsAvailable)
            {
                Console.WriteLine("Enter your name:");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter booking time (yyyy-mm-dd):");
                DateTime bookingTime = DateTime.Parse(Console.ReadLine());

                var booking = new Booking(1, 01, cabId, bookingTime);
                bookingRepo.AddBooking(booking);

                Console.WriteLine("Booking successful!");
            }
            else
            {
                Console.WriteLine("Cab not available.");
            }
        }
        static void CancelCab(BookingRepository bookingRepo)
        {
            Console.WriteLine("Enter Booking ID to cancel:");
            int bookingId = int.Parse(Console.ReadLine());

            var booking = bookingRepo.GetBookingsByUserId(bookingId).FirstOrDefault();
            if (booking != null)
            {
                booking.CancelBooking();
                Console.WriteLine("Booking cancelled.");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }

        // Method to give feedback (same as before)
        static void GiveFeedback()
        {
            Console.WriteLine("Enter Cab ID to give feedback:");
            int cabId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter feedback:");
            string feedbackText = Console.ReadLine();

            var feedback = new Feedback(cabId, 1, feedbackText);
            Console.WriteLine("Feedback submitted.");
        }
        static void AddCab(CabRepository cabRepo)
        {
            Console.WriteLine("Enter Cab ID:");
            int cabId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Cab Type:");
            string cabType = Console.ReadLine();

            Console.WriteLine("Enter number of seats:");
            int seats = int.Parse(Console.ReadLine());

            var newCab = new Cab(cabId, seats);
            cabRepo.AddCab(newCab);

            Console.WriteLine("Cab added successfully.");
        }
        static void ReviewFeedback(Manager manager)
        {
            Console.WriteLine("Reviewing feedback...");
            foreach (var feedback in manager.FeedbackList)
            {
                Console.WriteLine($"Cab ID: {feedback.CabId}, Feedback: {feedback.FeedbackText}");
            }
        }

    }
}
