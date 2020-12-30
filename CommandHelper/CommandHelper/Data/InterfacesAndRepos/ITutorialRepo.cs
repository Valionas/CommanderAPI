using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data
{
    public interface ITutorialRepo
    {
        bool SaveChanges();
        IEnumerable<Tutorial> GetAllCommands();
        Tutorial GetCommandById(int id);
        int CreateCommand(Tutorial tut);
        void UpdateCommand(Tutorial tut);
        void DeleteCommand(Tutorial tut);
    }
}
