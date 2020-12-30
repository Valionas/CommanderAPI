using CommandHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandHelper.Data.DataDB
{
    public class CommanderContext:DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt):base(opt)
        {

        }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<LecturerPlatform> LecturerPlatforms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
