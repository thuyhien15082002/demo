using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReponsitoryMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        [Precision(16, 2)]
        public decimal Price { get; set; }
        [MaxLength(400)]
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
