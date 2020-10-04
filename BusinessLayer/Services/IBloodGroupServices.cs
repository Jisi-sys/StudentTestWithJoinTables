using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;

namespace BusinessLayer.Services
{
    public interface IBloodGroupServices
    {
        IEnumerable<BloodGroup> GetAllBloodGroup();
        IEnumerable<BloodGroup> GetBloodGroupById(int id);
        void AddNewBloodGroup(BloodGroup bloodgroup);
        void UpdateBloodGroup(int id, BloodGroup bloodgroup);
        void DeleteBloodGroup(int id);

    }
}
