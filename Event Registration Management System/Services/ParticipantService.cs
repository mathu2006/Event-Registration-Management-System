using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Event_Registration_Management_System.Models;
namespace Event_Registration_Management_System.Services
{
    public class ParticipantService
    {
        private List<Participant> participant = new List<Participant>();
        public void CreateParticipant(Participant newParticipant)
        {
            participant.Add(newParticipant);
            Console.WriteLine("Participant Created Successfully");
        }
        public void DisplayParticipants()
        {
            foreach (Participant participant in participant)
            {
                Console.WriteLine("---participantservice----");
                Console.WriteLine($"Participant ID : {participant.ParticipantId}");
                Console.WriteLine($"Full Name : {participant.FullName}");
                Console.WriteLine($"Email : {participant.Email}");
                Console.WriteLine($"Phone Number : {participant.PhoneNumber}");
            }
        }
        public Participant GetParticipantSById(int participantId)
        {
            return participant.FirstOrDefault(p => p.ParticipantId == participantId);
        }
        public List<Participant> SearchParticipantByName(string keyword)
        {
            return participant .FindAll Where(p => p.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void UpdateParticipant(int participantId,string fullName,string email,string phoneNumber)
        {
            Participant participant = GetParticipantById(participantId);
            if (participant != null)
            {
                participant.FullName = fullName;
                participant.Email = email;
                participant.PhoneNumber = phoneNumber;
                Console.WriteLine("Participant Updated Successfully");
            }
            else
            {
                Console.WriteLine("Participant not found");
            }
        }
    }
}
