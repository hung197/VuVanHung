﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo_qltp_backend.Model;

namespace demo_qltp_backend.Migrations
{
    [DbContext(typeof(WebAPIContext))]
    [Migration("20201208024328_InitialDB2")]
    partial class InitialDB2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("demo_qltp_backend.Model.QuanHuyen", b =>
                {
                    b.Property<int>("MaQuanHuyen")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaTp");

                    b.Property<string>("TenQuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaQuanHuyen");

                    b.ToTable("quanHuyens");
                });

            modelBuilder.Entity("demo_qltp_backend.Model.ThanhPho", b =>
                {
                    b.Property<int>("MaTp")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenTp")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaTp");

                    b.ToTable("thanhPhos");
                });

            modelBuilder.Entity("demo_qltp_backend.Model.XaPhuong", b =>
                {
                    b.Property<int>("MaXaPhuong")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaQuanHuyen");

                    b.Property<int>("MaTp");

                    b.Property<string>("TenXaPhuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaXaPhuong");

                    b.ToTable("xaPhuongs");
                });
#pragma warning restore 612, 618
        }
    }
}