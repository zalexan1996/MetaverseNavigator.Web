﻿// <auto-generated />
using MN.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MN.Data.Migrations
{
    [DbContext(typeof(Persona5Context))]
    [Migration("20220817181923_RemovedLinkeBetweenBattleAndConfidant")]
    partial class RemovedLinkeBetweenBattleAndConfidant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MN.Domain.BattleCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AwakenedPersonaId")
                        .HasColumnType("int");

                    b.Property<int>("BasePersonaId")
                        .HasColumnType("int");

                    b.Property<string>("Codename")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GameCharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MeleeWeaponTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RangedWeaponTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwakenedPersonaId");

                    b.HasIndex("BasePersonaId");

                    b.HasIndex("GameCharacterId");

                    b.HasIndex("MeleeWeaponTypeId");

                    b.HasIndex("RangedWeaponTypeId");

                    b.ToTable("BattleCharacter");
                });

            modelBuilder.Entity("MN.Domain.Confidant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameCharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GameCharacterId")
                        .IsUnique();

                    b.ToTable("Confidant");
                });

            modelBuilder.Entity("MN.Domain.ConfidantBenefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ConfidantId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RankUnlocked")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfidantId");

                    b.ToTable("ConfidantBenefit");
                });

            modelBuilder.Entity("MN.Domain.ConfidantGift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConfidantId")
                        .HasColumnType("int");

                    b.Property<int>("GameItemId")
                        .HasColumnType("int");

                    b.Property<int>("GiftScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfidantId");

                    b.HasIndex("GameItemId");

                    b.ToTable("ConfidantGift");
                });

            modelBuilder.Entity("MN.Domain.ConfidantResponses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BoostAmount")
                        .HasColumnType("int");

                    b.Property<int>("ConfidantId")
                        .HasColumnType("int");

                    b.Property<int>("ResponseOrder")
                        .HasColumnType("int");

                    b.Property<string>("ResponseText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ConfidantId");

                    b.ToTable("ConfidantResponses");
                });

            modelBuilder.Entity("MN.Domain.GameCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("GameCharacter");
                });

            modelBuilder.Entity("MN.Domain.GameItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("GameItem");
                });

            modelBuilder.Entity("MN.Domain.MeleeWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeleeWeaponTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeleeWeaponTypeId");

                    b.ToTable("MeleeWeapon");
                });

            modelBuilder.Entity("MN.Domain.MeleeWeaponType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MeleeWeaponType");
                });

            modelBuilder.Entity("MN.Domain.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConfidantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StartingLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfidantId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("MN.Domain.RangedWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RangedWeaponTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RangedWeaponTypeId");

                    b.ToTable("RangedWeapon");
                });

            modelBuilder.Entity("MN.Domain.RangedWeaponType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RangedWeaponType");
                });

            modelBuilder.Entity("MN.Domain.BattleCharacter", b =>
                {
                    b.HasOne("MN.Domain.Persona", "AwakenedPersona")
                        .WithMany()
                        .HasForeignKey("AwakenedPersonaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MN.Domain.Persona", "BasePersona")
                        .WithMany()
                        .HasForeignKey("BasePersonaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MN.Domain.GameCharacter", "GameCharacter")
                        .WithMany()
                        .HasForeignKey("GameCharacterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MN.Domain.MeleeWeaponType", "MeleeWeaponType")
                        .WithMany()
                        .HasForeignKey("MeleeWeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MN.Domain.RangedWeaponType", "RangedWeaponType")
                        .WithMany()
                        .HasForeignKey("RangedWeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwakenedPersona");

                    b.Navigation("BasePersona");

                    b.Navigation("GameCharacter");

                    b.Navigation("MeleeWeaponType");

                    b.Navigation("RangedWeaponType");
                });

            modelBuilder.Entity("MN.Domain.Confidant", b =>
                {
                    b.HasOne("MN.Domain.GameCharacter", "GameCharacter")
                        .WithOne()
                        .HasForeignKey("MN.Domain.Confidant", "GameCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameCharacter");
                });

            modelBuilder.Entity("MN.Domain.ConfidantBenefit", b =>
                {
                    b.HasOne("MN.Domain.Confidant", "Confidant")
                        .WithMany()
                        .HasForeignKey("ConfidantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confidant");
                });

            modelBuilder.Entity("MN.Domain.ConfidantGift", b =>
                {
                    b.HasOne("MN.Domain.Confidant", "Confidant")
                        .WithMany()
                        .HasForeignKey("ConfidantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MN.Domain.GameItem", "GameItem")
                        .WithMany()
                        .HasForeignKey("GameItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confidant");

                    b.Navigation("GameItem");
                });

            modelBuilder.Entity("MN.Domain.ConfidantResponses", b =>
                {
                    b.HasOne("MN.Domain.Confidant", "Confidant")
                        .WithMany()
                        .HasForeignKey("ConfidantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confidant");
                });

            modelBuilder.Entity("MN.Domain.MeleeWeapon", b =>
                {
                    b.HasOne("MN.Domain.MeleeWeaponType", "MeleeWeaponType")
                        .WithMany()
                        .HasForeignKey("MeleeWeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeleeWeaponType");
                });

            modelBuilder.Entity("MN.Domain.Persona", b =>
                {
                    b.HasOne("MN.Domain.Confidant", "Confidant")
                        .WithMany()
                        .HasForeignKey("ConfidantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confidant");
                });

            modelBuilder.Entity("MN.Domain.RangedWeapon", b =>
                {
                    b.HasOne("MN.Domain.RangedWeaponType", "RangedWeaponType")
                        .WithMany()
                        .HasForeignKey("RangedWeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RangedWeaponType");
                });
#pragma warning restore 612, 618
        }
    }
}