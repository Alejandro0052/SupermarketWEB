using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;

namespace SupermarketWEB.Data
{
	public class SupermarketContext : DbContext
	{
		internal object Providers;

		public SupermarketContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
