using CommandHelper.Data.DataDB;
using CommandHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.InterfacesAndRepos
{
    public class SQLEventRepo
    {
        private CommanderContext _context;

        public SQLEventRepo(CommanderContext context)
        {
            _context = context;
        }
        public int CreateCommand(Event evn)
        {
            if (evn == null)
            {
                throw new ArgumentNullException(nameof(evn));
            }


            var result = _context.Events.Where(x => x.StartLecture == evn.StartLecture && x.EndLecture == evn.EndLecture && x.TutorialId == evn.TutorialId).FirstOrDefault();
            if (result == null)
            {
                _context.Events.Add(evn);

                return _context.SaveChanges();

            }
            return 0;
        }


        public void DeleteCommand(Event evn)
        {
            if (evn == null)
            {
                throw new ArgumentNullException(nameof(evn));
            }
            _context.Events.Remove(evn);
        }



        public IEnumerable<Event> GetAllCommands()
        {
            return _context.Events.ToList();
        }

        public Event GetCommandById(int id)
        {
            return _context.Events.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
