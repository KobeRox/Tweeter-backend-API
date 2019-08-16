using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tweeter_API.Model
{
    public partial class Tweeter
    {
        [Column("postid")]
        public int Postid { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Column("post")]
        [StringLength(1000)]
        public string Post { get; set; }
        [Column("isFavourate")]
        public bool? IsFavourate { get; set; }
    }
}
