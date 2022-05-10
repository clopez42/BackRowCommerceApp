using System.ComponentModel.DataAnnotations;

namespace BackRowCommerceApp.Models
{
    public class NotificationSettings
    {
        [Key]
        public int? Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        public bool LessThan100 { get; set; }
        [Required]
        public bool OutOfStateTransaction { get; set; }
        [Required]
        public bool Withdrawal { get; set; }
        [Required]
        public bool Deposit { get; set; }
        [Required]
        public bool Overdraft { get; set; }
        [Required]
        public bool TransactionDescription { get; set; }
    }
}
