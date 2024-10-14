﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTrial11.Data;

#nullable disable

namespace ProjectTrial11.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240125180037_abilities")]
    partial class abilities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectTrial11.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("ProjectTrial11.Models.BaseStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("CobblemonStatsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("int");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("TotalStats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BaseStat");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Cobblemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanEvolve")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvolutionMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalDexNum")
                        .HasColumnType("int");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cobblemon");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonBaseStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BaseStatId")
                        .HasColumnType("int");

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseStatId");

                    b.HasIndex("CobblemonId");

                    b.ToTable("CobblemonBaseStats");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonCType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CTypeId");

                    b.HasIndex("CobblemonId");

                    b.ToTable("CobblemonCTypes");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonEggMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.Property<int>("EggMoveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CobblemonId");

                    b.HasIndex("EggMoveId");

                    b.ToTable("CobblemonEggMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonLevelUpMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.Property<int>("LevelUpMoveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CobblemonId");

                    b.HasIndex("LevelUpMoveId");

                    b.ToTable("CobblemonLevelUpMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CobblemonId");

                    b.HasIndex("LocationId");

                    b.ToTable("CobblemonLocations");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.Property<int>("MoveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CobblemonId");

                    b.HasIndex("MoveId");

                    b.ToTable("CobblemonMove");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonTMMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CobblemonId")
                        .HasColumnType("int");

                    b.Property<int>("TMMoveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CobblemonId");

                    b.HasIndex("TMMoveId");

                    b.ToTable("CobblemonTMMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CType");
                });

            modelBuilder.Entity("ProjectTrial11.Models.EggMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoveAccuracy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EggMove");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("ProjectTrial11.Models.LevelUpMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoveAccuracy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoveLevel")
                        .HasColumnType("int");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LevelUpMove");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weather")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoveAccuracy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Move");
                });

            modelBuilder.Entity("ProjectTrial11.Models.TMMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoveAccuracy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TMNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TMMove");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonBaseStat", b =>
                {
                    b.HasOne("ProjectTrial11.Models.BaseStat", "BaseStat")
                        .WithMany("CobblemonBaseStats")
                        .HasForeignKey("BaseStatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonBaseStats")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseStat");

                    b.Navigation("Cobblemon");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonCType", b =>
                {
                    b.HasOne("ProjectTrial11.Models.CType", "CType")
                        .WithMany("CobblemonCTypes")
                        .HasForeignKey("CTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonCTypes")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CType");

                    b.Navigation("Cobblemon");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonEggMove", b =>
                {
                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonEggMoves")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.EggMove", "EggMove")
                        .WithMany("CobblemonEggMoves")
                        .HasForeignKey("EggMoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobblemon");

                    b.Navigation("EggMove");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonLevelUpMove", b =>
                {
                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonLevelUpMoves")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.LevelUpMove", "LevelUpMove")
                        .WithMany("CobblemonLevelUpMoves")
                        .HasForeignKey("LevelUpMoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobblemon");

                    b.Navigation("LevelUpMove");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonLocation", b =>
                {
                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonLocations")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.Location", "Location")
                        .WithMany("CobblemonLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobblemon");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonMove", b =>
                {
                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonMoves")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.Move", "Move")
                        .WithMany("CobblemonMoves")
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobblemon");

                    b.Navigation("Move");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CobblemonTMMove", b =>
                {
                    b.HasOne("ProjectTrial11.Models.Cobblemon", "Cobblemon")
                        .WithMany("CobblemonTMMoves")
                        .HasForeignKey("CobblemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTrial11.Models.TMMove", "TMMove")
                        .WithMany("CobblemonTMMoves")
                        .HasForeignKey("TMMoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobblemon");

                    b.Navigation("TMMove");
                });

            modelBuilder.Entity("ProjectTrial11.Models.BaseStat", b =>
                {
                    b.Navigation("CobblemonBaseStats");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Cobblemon", b =>
                {
                    b.Navigation("CobblemonBaseStats");

                    b.Navigation("CobblemonCTypes");

                    b.Navigation("CobblemonEggMoves");

                    b.Navigation("CobblemonLevelUpMoves");

                    b.Navigation("CobblemonLocations");

                    b.Navigation("CobblemonMoves");

                    b.Navigation("CobblemonTMMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.CType", b =>
                {
                    b.Navigation("CobblemonCTypes");
                });

            modelBuilder.Entity("ProjectTrial11.Models.EggMove", b =>
                {
                    b.Navigation("CobblemonEggMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.LevelUpMove", b =>
                {
                    b.Navigation("CobblemonLevelUpMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Location", b =>
                {
                    b.Navigation("CobblemonLocations");
                });

            modelBuilder.Entity("ProjectTrial11.Models.Move", b =>
                {
                    b.Navigation("CobblemonMoves");
                });

            modelBuilder.Entity("ProjectTrial11.Models.TMMove", b =>
                {
                    b.Navigation("CobblemonTMMoves");
                });
#pragma warning restore 612, 618
        }
    }
}
