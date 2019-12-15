using System.ComponentModel.DataAnnotations;

/*
 *  Is over
 *  No active
 *  Run
 *      */

namespace Auction.Models
{
    public class DealStateModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Length can not exceed 20 characters")]
        public string State { get; set; }
    }
}