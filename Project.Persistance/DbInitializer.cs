using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
