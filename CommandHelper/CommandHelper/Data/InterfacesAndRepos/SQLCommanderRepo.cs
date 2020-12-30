using CommandHelper.Data.DataDB;
using CommandHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CommandHelper.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private CommanderContext _context;

        public SQLCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public int CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
           

            var result = _context.Commands.Where(x => x.HowTo == cmd.HowTo && x.Platform == cmd.Platform && x.Line == cmd.Line).FirstOrDefault();
            if(result==null)
            {
                _context.Commands.Add(cmd);
               
                 return _context.SaveChanges();

            }
            return 0;
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.Include(x => x.Platform).ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.Include(x => x.Platform).FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            
        }
    }
}
