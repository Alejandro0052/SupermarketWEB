using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
	public class Product
	{
		//[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "decimal(6,2)")]

		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
