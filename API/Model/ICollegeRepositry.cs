using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public interface ICollegeRepositry
    {
        void AddCollege(College college);
        College GetCollege(int id);
        IEnumerable<College> GetAll();
        IEnumerable<College> GetAllByName(string name);
        IEnumerable<College> GetAllByNameAndLocation(string name, string location);
        void RemoveCollege(College college);
        void UpdateCountry(College college);
    }
}
