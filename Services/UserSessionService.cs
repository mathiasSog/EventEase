using System.Collections.Generic;

namespace EventEase.Services
{
    public class UserSessionService
    {
        public string? CurrentUserName { get; set; }
        public string? CurrentUserEmail { get; set; }

        // Dictionary to track attendance: EventId -> List of attendees
        private readonly Dictionary<int, List<string>> _attendance = new();

        public void RegisterAttendance(int eventId, string userName)
        {
            if (!_attendance.ContainsKey(eventId))
            {
                _attendance[eventId] = new List<string>();
            }

            if (!_attendance[eventId].Contains(userName))
            {
                _attendance[eventId].Add(userName);
            }
        }

        public List<string> GetAttendees(int eventId)
        {
            return _attendance.ContainsKey(eventId) ? _attendance[eventId] : new List<string>();
        }
    }
}