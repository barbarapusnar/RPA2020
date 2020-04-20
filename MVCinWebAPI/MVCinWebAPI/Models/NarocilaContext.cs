using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCinWebAPI.Models
{
    public class NarocilaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NarocilaContext() : base("name=NarocilaContext")
        {
        }

        public System.Data.Entity.DbSet<MVCinWebAPI.Models.Produkt> Produkts { get; set; }
        public System.Data.Entity.DbSet<MVCinWebAPI.Models.Naročilo> Naročila { get; set; }
        public System.Data.Entity.DbSet<MVCinWebAPI.Models.Podrobnosti> Podrobnosti { get; set; }
    }
}
