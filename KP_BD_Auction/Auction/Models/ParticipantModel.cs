using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Models
{
    public class ParticipantModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length can not exceed 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length can not exceed 50 characters")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length can not exceed 50 characters")]
        public string LastName { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Please inter valid age")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect adress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((8|\+7)[\-]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Incorrect adress")]
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}. {2}. (...{3})", LastName, FirstName[0], MiddleName[0], PhoneNumber.Substring(PhoneNumber.Length -5, 5));
            }
            private set { }
        }
    }
}