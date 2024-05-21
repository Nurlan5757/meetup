using System.ComponentModel.DataAnnotations;

namespace meetup.ViewModels
{
    public class UpdateMeetVM
    {
        public int id { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(100), Required]
        public string Subtitle { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string logo1 { get; set; }
        [Required]
        public string logo2 { get; set; }
        [Required]
        public string logo3 { get; set; }
    }
}
