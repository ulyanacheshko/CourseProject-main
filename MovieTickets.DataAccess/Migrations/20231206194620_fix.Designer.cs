﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieTickets.DataAccess;

#nullable disable

namespace MovieTickets.DataAccess.Migrations
{
    [DbContext(typeof(MovieTicketsDbContext))]
    [Migration("20231206194620_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieTickets.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", "dbo");
                });

            modelBuilder.Entity("MovieTickets.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HallNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovieDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Tickets", "dbo");
                });

            modelBuilder.Entity("MovieTickets.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("MovieTickets.Entities.Order", b =>
                {
                    b.HasOne("MovieTickets.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieTickets.Entities.Ticket", b =>
                {
                    b.HasOne("MovieTickets.Entities.Order", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MovieTickets.Entities.Order", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MovieTickets.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
