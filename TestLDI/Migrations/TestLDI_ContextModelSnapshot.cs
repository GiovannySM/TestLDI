﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TestLDI.Entities;

namespace TestLDI.Migrations
{
    [DbContext(typeof(TestLDI_Context))]
    partial class TestLDI_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestLDI.Models.PhoneDirectory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CellPhone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(260);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<int>("Phone");

                    b.Property<string>("SurNames")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.HasKey("Id");

                    b.ToTable("phoneDirectories");
                });
#pragma warning restore 612, 618
        }
    }
}
