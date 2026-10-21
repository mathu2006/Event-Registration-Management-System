using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Registration_Management_System.Models
{
    public class Event
    {
        public string EventID { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public DateTime Eventdate { get; set; }
        public int Capacity { get; set; }
        public decimal RegistrationFee { get; set; }
        public Event()
        {

        }
        public Event(string eventid,string name,string venue,DateTime eventdate,int capacity,decimal registrationfee)
        {
            EventID = eventid;
            Name = name;
            Venue = venue;
            Eventdate = eventdate;
            Capacity = capacity;
            RegistrationFee = registrationfee;
        }
       


    }
}
