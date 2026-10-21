using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Registration_Management_System.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal AmountPaid { get; set; }
        public RegistrationStatus Status { get; set; }
        public Registration()
        {

        }
        public Registration(int registrationid,int eventid,int participantid,DateTime registrationdate,decimal amountpaid, RegistrationStatus status)
        {
            RegistrationId = registrationid;
            EventId = eventid;
            ParticipantId = participantid;
            RegistrationDate = registrationdate;
            AmountPaid = amountpaid;
            Status = status;
        }

    }
}
