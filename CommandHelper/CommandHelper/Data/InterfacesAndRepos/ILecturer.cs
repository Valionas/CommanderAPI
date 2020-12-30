using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.InterfacesAndRepos
{
    public interface ILecturer
    {
        bool SaveChanges();
        IEnumerable<Lecturer> GetAllCommands();
        Lecturer GetCommandById(int id);
        int CreateCommand(Lecturer lec);
        void UpdateCommand(Lecturer lec);
        void DeleteCommand(Lecturer lec);
    }
}
