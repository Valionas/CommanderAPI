using CommandHelper.Data.DataDB;
using CommandHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data
{

    public class SQLTutorialRepo: ITutorialRepo
    {
        private CommanderContext _context;

        public SQLTutorialRepo(CommanderContext context)
        {
            _context = context;
        }

        public int CreateCommand(Tutorial tut)
        {
            if (tut == null)
            {
                throw new ArgumentNullException(nameof(tut));
            }


            var result = _context.Tutorials.Where(x => x.TutorialName == tut.TutorialName && x.Difficulty == tut.Difficulty && x.IsActive == tut.IsActive).FirstOrDefault();
            if (result == null)
            {
                _context.Tutorials.Add(tut);

                return _context.SaveChanges();

            }
            return 0;
        }

        public void DeleteCommand(Tutorial tut)
        {
            if (tut == null)
            {
                throw new ArgumentNullException(nameof(tut));
            }
            _context.Tutorials.Remove(tut);
        }

        public IEnumerable<Tutorial> GetAllCommands()
        {
            return _context.Tutorials.Include(x => x.Event).ToList();
        }

        public Tutorial GetCommandById(int id)
        {
            return _context.Tutorials.Include(x => x.Event).FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

     

        public void UpdateCommand(Tutorial cmd)
        {
            
        }
    }
}
