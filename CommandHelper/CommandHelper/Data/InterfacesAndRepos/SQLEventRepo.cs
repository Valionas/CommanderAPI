using CommandHelper.Data.DataDB;
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
    }
}
