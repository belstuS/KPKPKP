using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
    public class AuctionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH.mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH.mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        [DefaultValue(0)]
        public int Income { get; set; }
    }
}