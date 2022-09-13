using System.ComponentModel.DataAnnotations;

namespace ASPShoppingCart2022.Models
{
    public class CartItem
    {
        [Display(Name = "Název položky")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Počet kusů")]
        [Range(1, 100)]
        [Required]
        public int Amount { get; set; }
        [Display(Name = "Jednotková cena")]
        [Required]
        public double UnitPrice { get; set; }
    }
}
