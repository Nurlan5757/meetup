using System.ComponentModel.DataAnnotations;

namespace meetup.Models
{
    public class Meet
    {
        public int Id { get; set; }
        [MaxLength(100),Required]
        public string Name { get; set; }
        [MaxLength(100), Required]
        public string Subtitle { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public string logo1 { get; set; }
        [Required]
        public string logo2 { get; set; }
        [Required]
        public string logo3 { get; set; }
    }
}
