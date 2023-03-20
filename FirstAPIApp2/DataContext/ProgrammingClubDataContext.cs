using FirstAPIApp2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp2.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet<Announcement> Announcements { get; set; }

        //public DbSet<CodeSnippet> CodeSnippets { get; set; }
        //public DbSet<Member> Members { get; set; }
        //public DbSet<Membership> Memberships { get; set; }
        //public DbSet<MembershipType> MembershipTypes { get; set; } - Create Services DTOs and Controllers

    }
}

