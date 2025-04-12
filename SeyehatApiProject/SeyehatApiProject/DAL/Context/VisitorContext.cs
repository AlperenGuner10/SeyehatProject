using Microsoft.EntityFrameworkCore;
using SeyehatApiProject.DAL.Entities;

namespace SeyehatApiProject.DAL.Context
{
	public class VisitorContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-TVGOALM\\SQLEXPRESS;Database=SeyehatDbApi;TrustServerCertificate=true;Integrated Security=True;"
);
		}
		public DbSet<Visitor> Visitors { get; set; }
	}
}
