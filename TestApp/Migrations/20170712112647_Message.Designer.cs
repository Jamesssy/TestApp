using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestApp.Models;

namespace TestApp.Migrations
{
    [DbContext(typeof(TestAppContext))]
    [Migration("20170712112647_Message")]
    partial class Message
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

            modelBuilder.Entity("TestApp.Model.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Meddelande");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("TestApp.Model.Vegetables", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Antal");

                    b.Property<int?>("EmailId");

                    b.Property<string>("Enhet");

                    b.Property<int?>("MeddelandeId");

                    b.Property<string>("Produkt");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.HasIndex("MeddelandeId");

                    b.ToTable("Vegetables");
                });

            modelBuilder.Entity("TestApp.Model.Vegetables", b =>
                {
                    b.HasOne("TestApp.Model.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");

                    b.HasOne("TestApp.Model.Message", "Meddelande")
                        .WithMany()
                        .HasForeignKey("MeddelandeId");
                });
        }
    }
}
