using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11TUMAKOV
{
    public class Event
    {
        public string Name { get; }
        public DateTime Data { get; }
        public Dictionary<string, List<Student>> PatrticipantsByGroup{ get; }
        public Event(string name, DateTime data)
        {
            Name = name;
            Data = data;
            PatrticipantsByGroup = new Dictionary<string, List<Student>>();
        }
        public void AddParticipant(Student student)
        {
            if(!PatrticipantsByGroup.ContainsKey(student.Group))
            {
                PatrticipantsByGroup[student.Group] = new List<Student>();
            }
            PatrticipantsByGroup[student.Group].Add(student);
        }
    }
}
