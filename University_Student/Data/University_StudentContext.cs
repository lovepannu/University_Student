using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University_Student.Models;

namespace University_Student.Data
{
    public class University_StudentContext : DbContext
    {
        public University_StudentContext (DbContextOptions<University_StudentContext> options)
            : base(options)
        {
        }

        public DbSet<University_Student.Models.scholar> scholar { get; set; }
    }
}
