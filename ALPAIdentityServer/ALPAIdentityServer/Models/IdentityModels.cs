using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using EventManager.Core;

namespace ALPAIdentityServer.Models
{
    [Table("UserRoles")]
    public class ApplicationUserRole : IdentityUserRole<int> { }
    [Table("UserClaims")]
    public class ApplicationUserClaim : IdentityUserClaim<int> { }
    [Table("UserLogins")]
    public class ApplicationUserLogin : IdentityUserLogin<int> { }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [Table("Users")]
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;

        }

        public DateTime LastLogin { get; set; }
    }

    [Table("Roles")]
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {

    }
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<RegistrationScreenQuestionData> RegistrationScreenQuestionData { get; set; }
        public DbSet<RegistrationQuestionExternalMapping> RegistrationQuestionExternalMappings { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<AttendeeType> AttendeeTypes { get; set; }
        public DbSet<AirlineCode> AirlineCodes { get; set; }
        public DbSet<EventManagerSession> EventManagerSessions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<RegistrationProcess> RegistrationProcesses { get; set; }
        public DbSet<RegistrationProcessScreenQuestion> RegistrationProcessScreenQuestions { get; set; }
        public DbSet<RegistrationQuestionFormat> RegistrationQuestionFormats { get; set; }
        public DbSet<RegistrationQuestionType> RegistrationQuestionTypes { get; set; }
        public DbSet<RegistrationScreenQuestion> RegistrationScreenQuestions { get; set; }
        public DbSet<RegistrationScreen> RegistrationScreens { get; set; }
       // public DbSet<Member> Member { get; set; }
        public DbSet<GmsList> gmsList { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<GmsMember> gmsMember { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<ReportParameter> ReportParameters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");

        }

       

    }
    
}