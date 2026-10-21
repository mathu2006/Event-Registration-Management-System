using Event_Registration_Management_System.Services;
using Event_Registration_Management_System.Models;
using System;
namespace Event_Registration_Management_System
    {
    internal class Program
        {
            static void Main(string[] args)
            {
            EventServices eventServices = new EventServices();
            bool running = true;
            while (running)
                {
                Console.WriteLine("\n===== EVENT REGISTRATION MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Display All Events");
                Console.WriteLine("3. Get Event By ID");
                Console.WriteLine("4. Search Event By Name or Venue");
                Console.WriteLine("5. Update Event");
                Console.WriteLine("6. Delete Event");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine() ?? "";
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Event ID: ");
                            string eventID = Console.ReadLine() ?? "";
                            Console.Write("Enter Event Name: ");
                            string name = Console.ReadLine() ?? "";
                            Console.Write("Enter Venue: ");
                            string venue = Console.ReadLine() ?? "";
                            Console.Write("Enter Event Date (yyyy-MM-dd): ");
                           DateTime eventDate;
                            if (!DateTime.TryParse(
                                    Console.ReadLine(), out eventDate))
                                {
                                    Console.WriteLine("Invalid event date.");
                                    break;
                                }

                                Console.Write("Enter Capacity: ");
                                int capacity;

                                if (!int.TryParse(
                                    Console.ReadLine(), out capacity))
                                {
                                    Console.WriteLine("Invalid capacity.");
                                    break;
                                }

                                Console.Write("Enter Registration Fee: ");
                                decimal registrationFee;

                                if (!decimal.TryParse(
                                    Console.ReadLine(), out registrationFee))
                                {
                                    Console.WriteLine("Invalid registration fee.");
                                    break;
                                }

                                Event newEvent = new Event
                                {
                                    EventID = eventID,
                                    Name = name,
                                    Venue = venue,
                                    Eventdate = eventDate,
                                    Capacity = capacity,
                                    RegistrationFee = registrationFee
                                };

                                eventServices.CreateEvent(newEvent);
                                break;

                            case "2":
                             
                                eventServices.DisplayEvents();
                                break;

                            case "3":
                             
                                Console.Write("Enter Event ID: ");
                                string searchID = Console.ReadLine() ?? "";

                                Event? foundEvent =
                                    eventServices.GetEventById(searchID);

                                if (foundEvent == null)
                                {
                                    Console.WriteLine("Event not found.");
                                }
                                else
                                {
                                    Console.WriteLine(
                                        $"ID: {foundEvent.EventID}, " +
                                        $"Name: {foundEvent.Name}, " +
                                        $"Venue: {foundEvent.Venue}, " +
                                        $"Date: {foundEvent.Eventdate}, " +
                                        $"Capacity: {foundEvent.Capacity}, " +
                                        $"Fee: {foundEvent.RegistrationFee}");
                                }
                                break;

                            case "4":
                            
                                Console.Write("Enter event name or venue: ");
                                string keyword = Console.ReadLine() ?? "";

                                eventServices.SearchEventByNameorVenue(keyword);
                                break;

                            case "5":
                               
                                Console.Write("Enter Event ID: ");
                                string updateID = Console.ReadLine() ?? "";

                                Console.Write("Enter New Venue: ");
                                string newVenue = Console.ReadLine() ?? "";

                                Console.Write("Enter New Event Date (yyyy-MM-dd): ");
                                DateTime newDate;

                                if (!DateTime.TryParse(
                                    Console.ReadLine(), out newDate))
                                {
                                    Console.WriteLine("Invalid event date.");
                                    break;
                                }

                                Console.Write("Enter New Capacity: ");
                                int newCapacity;

                                if (!int.TryParse(
                                    Console.ReadLine(), out newCapacity))
                                {
                                    Console.WriteLine("Invalid capacity.");
                                    break;
                                }

                                Console.Write("Enter New Registration Fee: ");
                                decimal newFee;

                                if (!decimal.TryParse(
                                    Console.ReadLine(), out newFee))
                                {
                                    Console.WriteLine("Invalid registration fee.");
                                    break;
                                }

                                eventServices.UpdateEvent(
                                    newVenue,
                                    newDate,
                                    newCapacity,
                                    newFee,
                                    updateID);
                                break;

                            case "6":
                                Console.Write("Enter Event ID: ");
                                string deleteID = Console.ReadLine() ?? "";

                                eventServices.DeleteEvent(deleteID);
                                break;

                            case "0":
                                running = false;
                                Console.WriteLine("Exiting application...");
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }


        
    


