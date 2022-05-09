using BackRowCommerceApp.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace BackRowCommerceApp.Models
{
    public class Transaction
    {
        [Key]
        public int? TransactionId { get; set; }
        
        public int? AccountNum { get; set; }
        public DateTime ProcessDate { get; set; } = DateTime.Now;
        public float? Balance { get; set; }
        [Required]
        [EnumDataType(typeof(Constants.TransactionType))]
        [Display(Name ="Transaction Type")]
        public Constants.TransactionType CR_DR { get; set; }
        [Required]
        [Range(0, 999999999999.99, ErrorMessage = "Amount must be greater than 0")]
        public float? Amount { get; set; }
        [Required]
        [EnumDataType(typeof(Constants.States))]
        public Constants.States Location { get; set; }
        //public string? Location { get; set; }
        public string? Description { get; set; }
    }
}
