using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestApp.Models
{
    public interface IRepository
    {
        IEnumerable<Phone> GetAll();
        Phone Get(int id);
        void Create(Phone p);
    }
}
