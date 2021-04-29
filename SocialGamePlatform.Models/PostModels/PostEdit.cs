﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Models.PostModels
{
    public class PostEdit
    {
        /// <summary>
        /// Text for the post
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(240, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

        /// <summary>
        /// ID of the post
        /// </summary>
        [Required]
        public int PostId { get; set; }

    }
}
