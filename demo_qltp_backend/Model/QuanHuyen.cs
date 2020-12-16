using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_qltp_backend.Model
{
    public class QuanHuyen
    {
        [Key]
        public int MaQuanHuyen { get; set; }
        [Required]
        public int MaTp { get; set; }
        
        [Column(TypeName="nvarchar(200)")]
        [Required]
        public string TenQuanHuyen { get; set; }
    }
}
