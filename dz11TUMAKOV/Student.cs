using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dz11TUMAKOV
{
    public class Student
    {
        public string Name { get; }
        public string Group { get; }
        public List<string> Wishes { get; }

        public Student(string name, string group)
        {
            Name = name;
            Group = group;
            Wishes = new List<string>();
        }
        public void AddWish(string eventName)
        {
            Wishes.Add(eventName);
        }
    }
}
