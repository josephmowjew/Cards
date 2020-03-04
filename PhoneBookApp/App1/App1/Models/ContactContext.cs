using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class ContactContext: DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        //configuring where to store the database context
        protected override void OnConfiguring(DbContextOptionsBuilder options)

            => options.UseSqlite("Filename=Phonebook.db");
    }
}
