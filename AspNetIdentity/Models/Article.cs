using AspNetIdentity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetIdentity.Models
{
    public class Article
    {
        [Key]
        public int ArtcileId { get; set; }
        [Required]
        [Display(Name = "Makale Adı")]
        public string ArticleName { get; set; }

        [Required]
        [Display(Name = "Makale İçeriği")]
        public string ArticleContent { get; set; }

        public ApplicationUser ApllicationUser { get; set; }
    }
}