using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOrderTracker.DataLayer.Entities
{
    [Table("Parts")]
    public class Part
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SKU { get; set; } = string.Empty;

        [StringLength(256)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
    }
}
