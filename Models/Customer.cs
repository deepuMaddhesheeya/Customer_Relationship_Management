using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM2.Models;
[Table("Customer")]

public partial class Customer
{
    public string CustomerId { get; set; } = null!;
    [Required,MaxLength(100)]
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
