using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.InterfacesAndRepos
{
    public interface IPlatform
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllCommands();
        Platform GetCommandById(int id);
        int CreateCommand(Platform cmd);
        void UpdateCommand(Platform cmd);
        void DeleteCommand(Platform cmd);
    }
}
