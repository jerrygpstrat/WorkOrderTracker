using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOrderTracker.DataLayer.Entities
{

    [Table("AppVars")]
    public class AppVar
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(32)]
        public required string Name { get; set; }

        [StringLength(64)]
        public required string Value { get; set; }

        [StringLength(32)]
        public required string ConvertsTo { get; set; }

        [StringLength(16)]
        public string? UsePrefix { get; set; }

        public bool IsActive { get; set; }
    }
}
