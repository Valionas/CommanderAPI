using CommandHelper.Data.DataDB;
using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.InterfacesAndRepos
{
    public class SQLPlatform:IPlatform
    {
        private CommanderContext _context;

        public SQLPlatform(CommanderContext context)
        {
            _context = context;
        }
        public int CreateCommand(Platform plt)
        {
            if (plt == null)
            {
                throw new ArgumentNullException(nameof(plt));
            }


            var result = _context.Platform.Where(x => x.PlatformName == plt.PlatformName).FirstOrDefault();
            if (result == null)
            {
                _context.Platform.Add(plt);

                return _context.SaveChanges();

            }
            return 0;
        }


        public void DeleteCommand(Platform plt)
        {
            if (plt == null)
            {
                throw new ArgumentNullException(nameof(plt));
            }
            _context.Platform.Remove(plt);
        }



        public IEnumerable<Platform> GetAllCommands()
        {
            return _context.Platform.ToList();
        }

        public Platform GetCommandById(int id)
        {
            return _context.Platform.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Platform plt)
        {
            throw new NotImplementedException();
        }
    }
}
