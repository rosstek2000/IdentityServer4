using Microsoft.AspNet.Identity.EntityFramework;
using ALPAIdentityServer.AIROCore;
using System.Data.Entity;
using ALPAIdentityServer.Models;

namespace ALPAIdentityServer.Models
{
   
        public class AIRODbContext : DbContext
        {
            public AIRODbContext()
                : base("AIROConnection")
            {
            }

            public static AIRODbContext Create()
            {
                return new AIRODbContext();
            }

            public DbSet<Person> Person { get; set; }
            public DbSet<vwPersons> vwPersons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
               // base.OnModelCreating(modelBuilder);

                

            }



        }
   
}