// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectNewApi.Context;

#nullable disable

namespace ProjectNewApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230106193840_studios1")]
    partial class studios1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectNewApi.Models.Lokacija", b =>
                {
                    b.Property<int>("LokacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LokacijaId"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mjesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opcina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostanskiBroj")
                        .HasColumnType("int");

                    b.HasKey("LokacijaId");

                    b.ToTable("lokacije", (string)null);
                });

            modelBuilder.Entity("ProjectNewApi.Models.Studio", b =>
                {
                    b.Property<int>("StudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudioId"));

                    b.Property<int?>("LokacijaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudioImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VlasnikId")
                        .HasColumnType("int");

                    b.HasKey("StudioId");

                    b.HasIndex("LokacijaId");

                    b.ToTable("studios", (string)null);
                });

            modelBuilder.Entity("ProjectNewApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudioId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudioId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ProjectNewApi.Models.Studio", b =>
                {
                    b.HasOne("ProjectNewApi.Models.Lokacija", "Lokacija")
                        .WithMany()
                        .HasForeignKey("LokacijaId");

                    b.Navigation("Lokacija");
                });

            modelBuilder.Entity("ProjectNewApi.Models.User", b =>
                {
                    b.HasOne("ProjectNewApi.Models.Studio", null)
                        .WithMany("Instruktori")
                        .HasForeignKey("StudioId");
                });

            modelBuilder.Entity("ProjectNewApi.Models.Studio", b =>
                {
                    b.Navigation("Instruktori");
                });
#pragma warning restore 612, 618
        }
    }
}
