﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZAOGST.WIS.Data.DataBaseContext;

#nullable disable

namespace ZAOGST.WIS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240122111828_updating_shippingDate_entities")]
    partial class updating_shippingDate_entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.Ballon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BallonNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ControlBlockId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShippingDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StrainGaugeNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ControlBlockId");

                    b.ToTable("Ballons");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.ControlBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShippingDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ControlBlocks");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.ShippedBallon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BallonNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShippedControlBlockId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShippingDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StrainGaugeNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShippedControlBlockId");

                    b.ToTable("ShippedBallons");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.ShippedControlBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShippingDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ShippedControlBlocks");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.Ballon", b =>
                {
                    b.HasOne("ZAOGST.WIS.Data.Entities.ControlBlock", "ControlBlock")
                        .WithMany("Ballons")
                        .HasForeignKey("ControlBlockId");

                    b.Navigation("ControlBlock");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.ShippedBallon", b =>
                {
                    b.HasOne("ZAOGST.WIS.Data.Entities.ShippedControlBlock", "ShippedControlBlock")
                        .WithMany("ShippedBallons")
                        .HasForeignKey("ShippedControlBlockId");

                    b.Navigation("ShippedControlBlock");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.ControlBlock", b =>
                {
                    b.Navigation("Ballons");
                });

            modelBuilder.Entity("ZAOGST.WIS.Data.Entities.ShippedControlBlock", b =>
                {
                    b.Navigation("ShippedBallons");
                });
#pragma warning restore 612, 618
        }
    }
}
