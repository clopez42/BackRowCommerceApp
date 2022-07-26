using BackRowCommerceApp.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace BackRowCommerceApp.Models
{
    public class UserInfo
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(10)]
        public int? AccountNum { get; set; }
        public string? UserName { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public float? Balance { get; set; }
        [EnumDataType(typeof(Constants.States))]
        public Constants.States Location { get; set; }
    }
}
