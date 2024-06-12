﻿// <auto-generated />
using System;
using Karapinha.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Karapinha.DAL.Migrations
{
    [DbContext(typeof(KarapinhaContext))]
    [Migration("20240609190833_final")]
    partial class final
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Karapinha.Model.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Karapinha.Model.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHorario"));

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.HasKey("IdHorario");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Karapinha.Model.HorarioFuncionario", b =>
                {
                    b.Property<int>("IdHorarioFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHorarioFuncionario"));

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdProfissional")
                        .HasColumnType("int");

                    b.HasKey("IdHorarioFuncionario");

                    b.HasIndex("IdHorario");

                    b.HasIndex("IdProfissional");

                    b.ToTable("HorarioFuncionarios");
                });

            modelBuilder.Entity("Karapinha.Model.Marcacao", b =>
                {
                    b.Property<int>("IdMarcacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarcacao"));

                    b.Property<DateOnly>("DataDeMarcacao")
                        .HasColumnType("date");

                    b.Property<bool>("EstadoDeMarcacao")
                        .HasColumnType("bit");

                    b.Property<int?>("IdUtilizador")
                        .HasColumnType("int");

                    b.HasKey("IdMarcacao");

                    b.HasIndex("IdUtilizador");

                    b.ToTable("Marcacoes");
                });

            modelBuilder.Entity("Karapinha.Model.Profissional", b =>
                {
                    b.Property<int>("IdProfissional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfissional"));

                    b.Property<string>("BI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProfissional");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("Karapinha.Model.Servico", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServico"));

                    b.Property<DateOnly>("DataDoServico")
                        .HasColumnType("date");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("MarcacaoIdMarcacao")
                        .HasColumnType("int");

                    b.Property<float>("PrecoDoServico")
                        .HasColumnType("real");

                    b.Property<int>("TipoDeServico")
                        .HasColumnType("int");

                    b.HasKey("IdServico");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("MarcacaoIdMarcacao");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Karapinha.Model.Utilizador", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtilizador"));

                    b.Property<string>("BI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoDaConta")
                        .HasColumnType("bit");

                    b.Property<bool>("EstadoDoUtilizador")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDeUser")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUtilizador");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("Karapinha.Model.HorarioFuncionario", b =>
                {
                    b.HasOne("Karapinha.Model.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("IdHorario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Karapinha.Model.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("IdProfissional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Horario");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Karapinha.Model.Marcacao", b =>
                {
                    b.HasOne("Karapinha.Model.Utilizador", "Utilizador")
                        .WithMany()
                        .HasForeignKey("IdUtilizador");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("Karapinha.Model.Profissional", b =>
                {
                    b.HasOne("Karapinha.Model.Categoria", "Categoria")
                        .WithMany("Profissionais")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Karapinha.Model.Servico", b =>
                {
                    b.HasOne("Karapinha.Model.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Karapinha.Model.Marcacao", null)
                        .WithMany("Servico")
                        .HasForeignKey("MarcacaoIdMarcacao");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Karapinha.Model.Categoria", b =>
                {
                    b.Navigation("Profissionais");
                });

            modelBuilder.Entity("Karapinha.Model.Marcacao", b =>
                {
                    b.Navigation("Servico");
                });
#pragma warning restore 612, 618
        }
    }
}
