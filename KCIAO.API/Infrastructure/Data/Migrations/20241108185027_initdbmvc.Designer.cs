﻿// <auto-generated />
using KCIAO.API.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace KCIAO.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241108185027_initdbmvc")]
    partial class initdbmvc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KCIAO.API.Domain.Entities.ClienteEntity", b =>
                {
                    b.Property<string>("id_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("nm_cliente")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_cliente");

                    b.ToTable("tb_cliente");
                });

            modelBuilder.Entity("KCIAO.API.Domain.Entities.DoencaEntity", b =>
                {
                    b.Property<string>("id_doenca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("nm_doenca")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_doenca");

                    b.ToTable("tb_repositorio_doenca");
                });
#pragma warning restore 612, 618
        }
    }
}
