using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.InterfacesAndRepos
{
    public interface IEventcs
    {
        bool SaveChanges();
        IEnumerable<Event> GetAllCommands();
        Event GetCommandById(int id);
        int CreateCommand(Event cmd);
        void UpdateCommand(Event cmd);
        void DeleteCommand(Event cmd);
    }
}
