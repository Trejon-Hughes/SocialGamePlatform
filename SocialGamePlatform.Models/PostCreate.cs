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
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(5000, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}
