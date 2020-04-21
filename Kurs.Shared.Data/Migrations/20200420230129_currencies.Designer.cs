﻿// <auto-generated />
using System;
using Kurs.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kurs.Shared.Data.Migrations
{
    [DbContext(typeof(KursContext))]
    [Migration("20200420230129_currencies")]
    partial class currencies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kurs.Shared.Data.Context.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Kurs.Shared.Data.Context.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int?>("ExchangerId");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ExchangerId");

                    b.HasIndex("UserId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Kurs.Shared.Data.Context.Exchanger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("CityId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Exchangers");
                });

            modelBuilder.Entity("Kurs.Shared.Data.Context.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kurs.Shared.Data.Context.Currency", b =>
                {
                    b.HasOne("Kurs.Shared.Data.Context.Exchanger", "Exchanger")
                        .WithMany()
                        .HasForeignKey("ExchangerId");

                    b.HasOne("Kurs.Shared.Data.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Kurs.Shared.Data.Context.Exchanger", b =>
                {
                    b.HasOne("Kurs.Shared.Data.Context.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Kurs.Shared.Data.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}