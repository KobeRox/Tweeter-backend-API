using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tweeter_API.Model
{
    public partial class Users
    {
        [Column("userid")]
        public int Userid { get; set; }
        [Required]
        [Column("username")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        [Column("post")]
        [StringLength(255)]
        public string Post { get; set; }
    }
}
