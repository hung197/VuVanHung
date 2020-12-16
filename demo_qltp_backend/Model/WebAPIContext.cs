using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_qltp_backend.Model
{
    public class WebAPIContext :DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> options) : base(options)
        {
          
        }
        public DbSet<ThanhPho> thanhPhos { get; set; }
        public DbSet<QuanHuyen> quanHuyens { get; set; }
        public DbSet<XaPhuong> xaPhuongs { get; set; }
    }
}
