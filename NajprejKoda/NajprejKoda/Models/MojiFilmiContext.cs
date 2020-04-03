using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NajprejKoda.Models
{
    public class MojiFilmiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MojiFilmiContext() : base("name=MojiFilmiContext")
        {
        }

        public System.Data.Entity.DbSet<NajprejKoda.Models.Film> Films { get; set; }
    }
}
