using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRM2.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
        }
        public string CustomerId { get; set; } = null!;
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required, MaxLength(100)]
        public string? Email { get; set; }
        [Required, MaxLength(100)]
        public string? Phone { get; set; }
        [Required, MaxLength(100)]
        public string? Address { get; set; }
        [Required, MaxLength(100)]
        public string? CreatedDate { get; set; }
        [Required, MaxLength(100)]
        public string? Status { get; set; }
    }
}