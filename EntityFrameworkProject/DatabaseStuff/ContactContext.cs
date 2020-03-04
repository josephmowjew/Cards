using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseStuff
{
    class ContactContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}
