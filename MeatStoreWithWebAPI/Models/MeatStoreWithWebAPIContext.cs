using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeatStoreWithWebAPI.Models
{
    public class MeatStoreWithWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MeatStoreWithWebAPIContext() : base("name=MeatStoreWithWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<MeatStoreWithWebAPI.Models.MeatKind> MeatKinds { get; set; }

        public System.Data.Entity.DbSet<MeatStoreWithWebAPI.Models.MeatRates> MeatRates { get; set; }

        public System.Data.Entity.DbSet<MeatStoreWithWebAPI.Models.Transactions> Transactions { get; set; }
    }
}
