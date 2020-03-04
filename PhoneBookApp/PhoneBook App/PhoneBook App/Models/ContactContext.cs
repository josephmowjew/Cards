using Microsoft.EntityFrameworkCore;
using PhoneBook_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_App.Models
{
    class ContactContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        //configuring where to store the database context
        protected override void OnConfiguring(DbContextOptionsBuilder options)

            => options.UseSqlite("Filename=Phonebook.db");

    }
}
