using System.ComponentModel.DataAnnotations;

namespace jovens_ambientalistas_net_core.Entity
{
    public class Product
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set;}
    }
}