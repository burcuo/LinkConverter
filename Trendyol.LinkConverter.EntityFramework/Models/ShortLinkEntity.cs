using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trendyol.LinkConverter.EntityFramework.Models
{
    [Table("shortLinks")]
    public class ShortLinkEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "ShortLink is required.")]
        [StringLength(10, ErrorMessage = "ShortLink can't be longer than 10 characters.")]
        public string ShortLink { get; set; }

        [Required(ErrorMessage = "WebUrl is required.")]
        public string WebUrl { get; set; }

        [Required(ErrorMessage = "Deeplink is required.")]
        public string Deeplink { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }
    }
}
