using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Billing.Presentation.Models
{
    public class Product
    {

		public int ProductId { get; set; }

		public string ProductName { get; set; }
	
		public decimal Price { get; set; }
	
		public bool IsActive { get; set; }
    }

	//public class ProductData
	//{

	//	[JsonProperty("$id")]
	//	public string Id { get; set; }
	//	[JsonProperty("$values")]
	//	public List<Product> Products { get; set; }
	//}
	//public class DropdownProductData
	//{
	//	public long ProductId { get; set; }
	//	public string ProductName { get; set; }
	//}
}
