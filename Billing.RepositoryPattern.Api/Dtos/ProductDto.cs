using System;

namespace Billing.RepositoryPattern.Api.Dtos
{
    public class ProductDto
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }
    }
}
