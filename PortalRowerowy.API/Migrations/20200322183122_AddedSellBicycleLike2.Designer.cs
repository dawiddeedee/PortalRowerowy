﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalRowerowy.API.Data;

namespace PortalRowerowy.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200322183122_AddedSellBicycleLike2")]
    partial class AddedSellBicycleLike2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("PortalRowerowy.API.Models.Adventure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdventureName");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("Distance");

                    b.Property<string>("TypeBicycle");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Adventures");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.AdventureLike", b =>
                {
                    b.Property<int>("UserLikesAdventureId");

                    b.Property<int>("AdventureIsLikedId");

                    b.HasKey("UserLikesAdventureId", "AdventureIsLikedId");

                    b.HasIndex("AdventureIsLikedId");

                    b.ToTable("AdventureLikes");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.AdventurePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdventureId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<string>("Url");

                    b.Property<string>("public_id");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.ToTable("AdventurePhotos");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.Like", b =>
                {
                    b.Property<int>("UserLikesId");

                    b.Property<int>("UserIsLikedId");

                    b.HasKey("UserLikesId", "UserIsLikedId");

                    b.HasIndex("UserIsLikedId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime?>("DateRead");

                    b.Property<DateTime>("DateSent");

                    b.Property<bool>("IsRead");

                    b.Property<bool>("RecipientDeleted");

                    b.Property<int>("RecipientId");

                    b.Property<bool>("SenderDeleted");

                    b.Property<int>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.SellBicycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("Price");

                    b.Property<string>("SellBicycleName");

                    b.Property<string>("TypeBicycle");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SellBicycles");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.SellBicycleLike", b =>
                {
                    b.Property<int>("UserLikesSellBicycleId");

                    b.Property<int>("SellBicycleIsLikedId");

                    b.HasKey("UserLikesSellBicycleId", "SellBicycleIsLikedId");

                    b.HasIndex("SellBicycleIsLikedId");

                    b.ToTable("SellBicycleLikes");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.SellBicyclePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<int>("SellBicycleId");

                    b.Property<string>("Url");

                    b.Property<string>("public_id");

                    b.HasKey("Id");

                    b.HasIndex("SellBicycleId");

                    b.ToTable("SellBicyclePhotos");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bicycles");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Description");

                    b.Property<string>("DreamBicycle");

                    b.Property<string>("Gender");

                    b.Property<string>("Interests");

                    b.Property<DateTime>("LastActive");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Profession");

                    b.Property<string>("TypeBicycle");

                    b.Property<string>("Username");

                    b.Property<string>("Voivodeship");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.UserPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.Property<string>("public_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhotos");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.Adventure", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.User", "User")
                        .WithMany("Adventures")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.AdventureLike", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.Adventure", "AdventureIsLiked")
                        .WithMany("UserLikesAdventure")
                        .HasForeignKey("AdventureIsLikedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PortalRowerowy.API.Models.User", "UserLikesAdventure")
                        .WithMany("AdventureIsLiked")
                        .HasForeignKey("UserLikesAdventureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.AdventurePhoto", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.Adventure", "Adventure")
                        .WithMany("AdventurePhotos")
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.Like", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.User", "UserIsLiked")
                        .WithMany("UserLikes")
                        .HasForeignKey("UserIsLikedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PortalRowerowy.API.Models.User", "UserLikes")
                        .WithMany("UserIsLiked")
                        .HasForeignKey("UserLikesId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.Message", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.User", "Recipient")
                        .WithMany("MessagesRecived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PortalRowerowy.API.Models.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.SellBicycle", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.User", "User")
                        .WithMany("SellBicycles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.SellBicycleLike", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.SellBicycle", "SellBicycleIsLiked")
                        .WithMany("UserLikesSellBicycle")
                        .HasForeignKey("SellBicycleIsLikedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PortalRowerowy.API.Models.User", "UserLikesSellBicycle")
                        .WithMany("SellBicycleIsLiked")
                        .HasForeignKey("UserLikesSellBicycleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.SellBicyclePhoto", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.SellBicycle", "SellBicycle")
                        .WithMany("SellBicyclePhotos")
                        .HasForeignKey("SellBicycleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PortalRowerowy.API.Models.UserPhoto", b =>
                {
                    b.HasOne("PortalRowerowy.API.Models.User", "User")
                        .WithMany("UserPhotos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
