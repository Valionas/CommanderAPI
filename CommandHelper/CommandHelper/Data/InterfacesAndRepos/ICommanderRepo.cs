
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandHelper.Models;


namespace CommandHelper.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        int CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
