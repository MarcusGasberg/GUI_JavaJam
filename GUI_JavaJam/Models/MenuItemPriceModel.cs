using System.ComponentModel.DataAnnotations;

namespace GUI_JavaJam.Models
{
    public class MenuItemPriceModel
    {
        public int Id { get; set; }
        public string PriceDescription { get; set; }
        [Required(ErrorMessage = "The Item must have a price")]
        public double Price { get; set; }
        public int MenuItemId { get; set; }
        public MenuItemModel MenuItem { get; set; }
    }
}