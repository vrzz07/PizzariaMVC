﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzariaMVC.Data;

namespace PizzariaMVC.Migrations
{
    [DbContext(typeof(PizzariaDbContext))]
    partial class PizzariaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzariaMVC.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TamanhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TamanhoId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzariaMVC.Models.PizzaSabor", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("SaborId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "SaborId");

                    b.HasIndex("SaborId");

                    b.ToTable("PizzasSabores");
                });

            modelBuilder.Entity("PizzariaMVC.Models.Sabor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sabores");
                });

            modelBuilder.Entity("PizzariaMVC.Models.Tamanho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tamanhos");
                });

            modelBuilder.Entity("PizzariaMVC.Models.Pizza", b =>
                {
                    b.HasOne("PizzariaMVC.Models.Tamanho", "Tamanho")
                        .WithMany("Pizzas")
                        .HasForeignKey("TamanhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tamanho");
                });

            modelBuilder.Entity("PizzariaMVC.Models.PizzaSabor", b =>
                {
                    b.HasOne("PizzariaMVC.Models.Pizza", "Pizza")
                        .WithMany("PizzasSabores")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzariaMVC.Models.Sabor", "Sabor")
                        .WithMany("PizzasSabores")
                        .HasForeignKey("SaborId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Sabor");
                });

            modelBuilder.Entity("PizzariaMVC.Models.Pizza", b =>
                {
                    b.Navigation("PizzasSabores");
                });

            modelBuilder.Entity("PizzariaMVC.Models.Sabor", b =>
                {
                    b.Navigation("PizzasSabores");
                });

            modelBuilder.Entity("PizzariaMVC.Models.Tamanho", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
