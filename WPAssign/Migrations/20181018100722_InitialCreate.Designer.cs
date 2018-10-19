﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPAssign.Models;

namespace WPAssignment.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20181018100722_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WPAssignment.Models.Ticket", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Start")
                        .IsRequired();

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("WPAssignment.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WPAssignment.Models.Ticket", b =>
                {
                    b.HasOne("WPAssignment.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("Id")
                        .HasConstraintName("ForeignKey_Ticket_User")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
