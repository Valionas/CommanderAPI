using CommandHelper.Data.DataDB;
using CommandHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CommandHelper.Data.InterfacesAndRepos
{
    public class SQLLecturer:ILecturer
    {
        private CommanderContext _context;

        public SQLLecturer(CommanderContext context)
        {
            _context = context;
        }

        public int CreateCommand(Lecturer lec)
        {
            if (lec == null)
            {
                throw new ArgumentNullException(nameof(lec));
            }


            var result = _context.Lecturers.Where(x => x.FirstName == lec.FirstName && x.LastName == lec.LastName && x.Email == lec.Email).FirstOrDefault();
            if (result == null)
            {
                _context.Lecturers.Add(lec);

                return _context.SaveChanges();

            }
            return 0;
        }


        public void DeleteCommand(Lecturer lec)
        {
            if (lec == null)
            {
                throw new ArgumentNullException(nameof(lec));
            }
            _context.Lecturers.Remove(lec);
        }

       

        public IEnumerable<Lecturer> GetAllCommands()
        {
            return _context.Lecturers.Include(x => x.Events).ToList();
        }

        public Lecturer GetCommandById(int id)
        {
            return _context.Lecturers.Include(x => x.Events).Include(x => x.LecturePlatforms).ThenInclude(x => x.Platform).FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }



      

        public void UpdateCommand(Lecturer lec)
        {
          
        }

      

       
    }
}
