using System;

namespace Billing.RepositoryPattern.Api.Dtos
{
    public class ProductDto
    {
     //   public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public bool IsActive { get; set; }
    }
}
