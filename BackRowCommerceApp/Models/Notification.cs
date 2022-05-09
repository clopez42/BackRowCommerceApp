using System.ComponentModel.DataAnnotations;

namespace BackRowCommerceApp.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
