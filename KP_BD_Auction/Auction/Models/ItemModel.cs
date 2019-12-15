using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 *  Available
 *  Sold
 *      */

namespace Auction.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length can not exceed 50 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Length can not exceed 256 characters")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_Id { get; set; }

        [Required]
        public int StartedPrice { get; set; }

        [Required]
        public int PriceGrowth { get; set; }

        [ForeignKey("Category_Id")]
        public IEnumerable<ItemCategoryModel> ItemCategories { get; set; }

        public string Category { get; set; }
    }
}
