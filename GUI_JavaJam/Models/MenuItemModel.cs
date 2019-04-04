using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GUI_JavaJam.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A Name for the menu is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A Description for the menu is required")]
        public string Description { get; set; }
        
        public List<MenuItemPriceModel> PriceModels { get; set; }
    }
}