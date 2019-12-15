using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Models
{
    public class DealModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Byer")]
        public int Buyer_Id { get; set; }

        [Required]
        [Display(Name = "Seller")]
        public int Seller_Id { get; set; }

        [Required]
        [Display(Name = "Item")]
        public int Item_Id { get; set; }

        [Required]
        [Display(Name = "Auction")]
        public int Auction_Id { get; set; }

        [Required]
        [Display(Name = "Deal State")]
        public int DealState_Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH.mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please inter price from 0")]
        public int Price { get; set; }

        [ForeignKey("Buyer_Id")]
        public IEnumerable<ParticipantModel> Buyers { get; set; }
        [ForeignKey("Seller_Id")]
        public IEnumerable<ParticipantModel> Sellers { get; set; }
        [ForeignKey("Item_Id")]
        public IEnumerable<ItemModel> Items { get; set; }
        [ForeignKey("Auction_Id")]
        public IEnumerable<AuctionModel> Auctions { get; set; }
        [ForeignKey("DealState_Id")]
        public IEnumerable<DealStateModel> DealStates { get; set; }

        public string Buyer { get; set; }
        public string Seller { get; set; }
        public string Item { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Auction { get; set; }
        [Display(Name = "Deal State")]
        public string DealState { get; set; }

        public string Info {
            get
            {
                return String.Format("Auction: {0} ({1})", Auction_Id, Time);
            }
            private set { }
        }
    }
}