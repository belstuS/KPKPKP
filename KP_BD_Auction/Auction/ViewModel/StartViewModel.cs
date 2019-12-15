using System.Collections.Generic;
using Auction.Models;

namespace Auction.ViewModel
{
    public class StartViewModel
    {
        public int currentByuer { get; set; }
        public IEnumerable<DealModel> deals { get; set; }
        public IEnumerable<ParticipantModel> participants { get; set; }

    }   
}