using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_qltp_backend.Model
{
    public class XaPhuong
    {
        [Key]
        public int MaXaPhuong { get; set; }
        [Required]
        public int MaTp { get; set; }
        [Required]
        public int MaQuanHuyen { get; set; }
        [Column(TypeName="nvarchar(200)")]
        [Required]
        public string TenXaPhuong { get; set; }
    }
}
