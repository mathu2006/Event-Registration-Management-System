using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Registration_Management_System.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Participant()
        {

        }
        public Participant (int participantid,string fullname,string emain,string phonenumbet)
        {
            ParticipantId = participantid;
            FullName = fullname;
            Email = Email;
            PhoneNumber = PhoneNumber;

        }
    }
}
