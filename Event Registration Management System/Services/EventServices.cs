using Event_Registration_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Registration_Management_System.Services
{
    public class EventServices
    {
        private readonly List<Event> events = new List<Event>();
        public bool CreateEvent(Event newEvent)
        {
            if (newEvent == null)
            {
                Console.WriteLine("Event cannot be null.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(newEvent.EventID))
            {
                Console.WriteLine("Event ID cannot be empty.");
                return false;
            }
            if (events.Any(e => e.EventID.Equals(newEvent.EventID.Trim(),StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("An event with this ID already exists.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(newEvent.Name))
            {
                Console.WriteLine("Event name cannot be empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(newEvent.Venue))
            {
                Console.WriteLine("Venue cannot be empty.");
                return false;
            }
            if (newEvent.Capacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than zero.");
                return false;
            }
            if (newEvent.RegistrationFee < 0)
            {
                Console.WriteLine("Registration fee cannot be negative.");
                return false;
            }
            if (newEvent.Eventdate < DateTime.Now)
            {
                Console.WriteLine("Event date cannot be in the past.");
                return false;
            }
            events.Add(newEvent);
            Console.WriteLine("Event created successfully!!!");
            return true;
        }
        public void DisplayEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No events available.");
                return;
            }
            Console.WriteLine("Available Events:");
            foreach (Event e in events)
            {
                Console.WriteLine($"ID: {e.EventID}, Name: {e.Name}, Date: {e.Eventdate}, Venue: {e.Venue}, Capacity: {e.Capacity}, Fee: {e.RegistrationFee}");
            }
        }
        public Event? GetEventById(string eventId)
        {
            if (string.IsNullOrWhiteSpace(eventId))
            {
                return null;
            }
            return events.FirstOrDefault(e =>
                e.EventID.Equals(eventId.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        public void SearchEventByNameorVenue(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Search text cannot be empty.");
                return;
            }
            var foundEvents = events.Where(e => e.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) || e.Venue.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundEvents.Count == 0)
            {
                Console.WriteLine("No matching events found.");
                return;
            }

            Console.WriteLine("\n========== SEARCH RESULTS ==========");

            foreach (Event e in foundEvents)
            {
                Console.WriteLine($"Name: {e.Name}, Venue: {e.Venue}, Date:{e.Eventdate}, Capacity:{e.Capacity}, Fee: {e.RegistrationFee}");
            }
        }
        public void UpdateEvent(string venue, DateTime eventDate, int capacity, decimal registrationFee, string eventId)
        {
            Event? existingEvent = GetEventById(eventId);
            if (existingEvent == null)
            {
                Console.WriteLine("Event not found.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(venue))
            {
                existingEvent.Venue = venue;
            }
            if (eventDate > DateTime.Now)
            {
                existingEvent.Eventdate = eventDate;
            }
            else
            {
                Console.WriteLine("Event date cannot be in the past.");
                return;
            }
            if (capacity > 0)
            {
                existingEvent.Capacity = capacity;
            }
            else
            {
                Console.WriteLine("Capacity must be greater than zero.");
                return;
            }
            if (registrationFee >= 0)
            {
                existingEvent.RegistrationFee = registrationFee;
            }
            else
            {
                Console.WriteLine("Registration fee cannot be negative.");
                return;
            }
            Console.WriteLine("Event updated successfully.");
        }
        public void DeleteEvent(string eventId)
        {
            Event? existingEvent = GetEventById(eventId);
            if (existingEvent == null)
            {
                Console.WriteLine("Event not found.");
                return;
            }
            events.Remove(existingEvent);
            Console.WriteLine("Event deleted successfully.");
        }
    }
}
