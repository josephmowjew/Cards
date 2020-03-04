using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;

namespace ContactModel
{
   public class ContactContext: DbContext
    {
        public DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "phonebook.db");
            optionsBuilder.UseSqlite("Filename = " + dbPath);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
