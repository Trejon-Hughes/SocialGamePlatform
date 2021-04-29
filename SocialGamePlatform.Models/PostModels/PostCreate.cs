using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(400, ErrorMessage = "There are too many characters in this field.")]
        public string PostName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(10000, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public Guid PosterID { get; set; }
    }
}
