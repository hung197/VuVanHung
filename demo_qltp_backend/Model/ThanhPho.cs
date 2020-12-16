using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_qltp_backend.Model
{
    public class ThanhPho
    {
        [Key]
        public int MaTp { get; set; }
        [Column(TypeName="nvarchar(200)")]
        [Required]
        public string TenTp { get; set; }

        //public List<string> tenQuanHuyen { get; set; }
        //public List<string> tenXaPhuong { get; set; }
    }
}
