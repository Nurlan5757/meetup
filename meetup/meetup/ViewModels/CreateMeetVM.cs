using System.ComponentModel.DataAnnotations;

namespace meetup.ViewModels
{
    public class CreateMeetVM
    {

       
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(100), Required]
        public string Subtitle { get; set; }
        [Required]
        public string Image { get; set; }
        
        public string logo1 { get; set; }
        
        public string logo2 { get; set; }
       
        public string logo3 { get; set; }
    }
}
