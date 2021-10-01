using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class CollegeRepository : ICollegeRepositry
    {

        private Dictionary<int, College> data = new Dictionary<int, College>();

        public CollegeRepository()
        {
            data.Add(1, new College(1, "HoGent", "Gent", 23000, "D"));
            data.Add(2, new College(2, "KuLeuven", "Leuven", 20000, "A"));
            data.Add(3, new College(3, "Artevelde", "Gent", 12000, "T"));
            data.Add(4, new College(4, "VUB", "Brussel", 45000, "D"));
            data.Add(5, new College(5, "UGent", "Gent", 23700, "O"));
            data.Add(6, new College(6, "Vives", "Kortrijk", 1200, "C"));
        }

        public void AddCollege(College college)
        {
            if (!data.ContainsKey(college.Id))
                data.Add(college.Id, college);
            else
                throw new CollegeException("College allready exist");
        }

        public IEnumerable<College> GetAll()
        {
            return data.Values;
        }

        public IEnumerable<College> GetAllByName(string name)
        {
            return data.Values.Where(x => x.Name == name);
        }

        public College GetCollege(int id)
        {
            if (data.ContainsKey(id))
                return data[id];
            else
                throw new CollegeException("College doesn't exist");

        }

        public void RemoveCollege(College college)
        {
            if (data.ContainsKey(college.Id))
                data.Remove(college.Id);
            else
                throw new CollegeException("College doesn't exist");
        }

        public void UpdateCountry(College college)
        {
            if (data.ContainsKey(college.Id))
                data[college.Id] = college;
            else
                throw new CollegeException("College doesn't exist");
        }

        public IEnumerable<College> GetAllByNameAndLocation(string name, string location)
        {
            return data.Values.Where(x => x.Name == name && x.Location == location);
        }
    }
}
