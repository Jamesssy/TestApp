using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestApp.Models;

namespace TestApp.Migrations
{
    [DbContext(typeof(TestAppContext))]
    [Migration("20170712104147_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestApp.Model.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("TestApp.Model.Vegetables", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Antal");

                    b.Property<int?>("EmailId");

                    b.Property<string>("Enhet");

                    b.Property<string>("Meddelande");

                    b.Property<string>("Produkt");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("Vegetables");
                });

            modelBuilder.Entity("TestApp.Model.Vegetables", b =>
                {
                    b.HasOne("TestApp.Model.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");
                });
        }
    }
}
