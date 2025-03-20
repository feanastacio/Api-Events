﻿// <auto-generated />
using System;
using Api_Event.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_Event.Migrations
{
    [DbContext(typeof(Event_Context))]
    [Migration("20250318121556_DbProjectEvents")]
    partial class DbProjectEvents
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxidentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api_Event.Domains.ComentarioEvento", b =>
                {
                    b.Property<Guid>("ComentarioEventoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Eventoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("Usuarioid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComentarioEventoid");

                    b.HasIndex("Eventoid");

                    b.HasIndex("Exibe")
                        .IsUnique();

                    b.HasIndex("Usuarioid");

                    b.ToTable("ComentarioEvento");
                });

            modelBuilder.Entity("Api_Event.Domains.Evento", b =>
                {
                    b.Property<Guid>("Eventoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATE");

                    b.Property<string>("DescricaoEvento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Instituicaoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("TipoDeEventoid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Eventoid");

                    b.HasIndex("Instituicaoid");

                    b.HasIndex("TipoDeEventoid");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Api_Event.Domains.Instituicao", b =>
                {
                    b.Property<Guid>("Institucaoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Institucaoid");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("Api_Event.Domains.Presenca", b =>
                {
                    b.Property<Guid>("Presencaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Eventoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Situacao")
                        .HasColumnType("BIT");

                    b.Property<Guid>("Usuarioid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Presencaid");

                    b.HasIndex("Eventoid")
                        .IsUnique();

                    b.HasIndex("Situacao")
                        .IsUnique();

                    b.HasIndex("Usuarioid");

                    b.ToTable("Presenca");
                });

            modelBuilder.Entity("Api_Event.Domains.TipoDeEvento", b =>
                {
                    b.Property<Guid>("TipoDeEventoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TipoDeEventoid");

                    b.ToTable("TipoDeEvento");
                });

            modelBuilder.Entity("Api_Event.Domains.TipoDeUsuario", b =>
                {
                    b.Property<Guid>("TipoDeUsuarioid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TipoDeUsuarioid");

                    b.ToTable("TipoDeUsuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Usuario", b =>
                {
                    b.Property<Guid>("Usuarioid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("SenhaUsuario")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<Guid>("TipoDeUsuarioid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Usuarioid");

                    b.HasIndex("EmailUsuario")
                        .IsUnique();

                    b.HasIndex("TipoDeUsuarioid");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Api_Event.Domains.ComentarioEvento", b =>
                {
                    b.HasOne("Api_Event.Domains.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("Eventoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Event.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Evento", b =>
                {
                    b.HasOne("Api_Event.Domains.Instituicao", "instituicao")
                        .WithMany()
                        .HasForeignKey("Instituicaoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Event.Domains.TipoDeEvento", "TipoDeEvento")
                        .WithMany()
                        .HasForeignKey("TipoDeEventoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeEvento");

                    b.Navigation("instituicao");
                });

            modelBuilder.Entity("Api_Event.Domains.Presenca", b =>
                {
                    b.HasOne("Api_Event.Domains.Evento", "Evento")
                        .WithOne("Presenca")
                        .HasForeignKey("Api_Event.Domains.Presenca", "Eventoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Event.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Usuario", b =>
                {
                    b.HasOne("Api_Event.Domains.TipoDeUsuario", "TipoDeUsuario")
                        .WithMany()
                        .HasForeignKey("TipoDeUsuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeUsuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Evento", b =>
                {
                    b.Navigation("Presenca");
                });
#pragma warning restore 612, 618
        }
    }
}
