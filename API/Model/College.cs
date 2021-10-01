using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class College
    {
        public College() { }
        public College(int id, string name, string location, int students, string code)
        {
            Id = id;
            Name = name;
            Location = location;
            Students = students;
            Code = code;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public int Students { get; set; }

        public string Code { get; set; }
    }
}
