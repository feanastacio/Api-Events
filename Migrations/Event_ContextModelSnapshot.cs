﻿// <auto-generated />
using System;
using Api_Event.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_Event.Migrations
{
    [DbContext(typeof(Event_Context))]
    partial class Event_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api_Event.Domains.ComentarioEvento", b =>
                {
                    b.Property<Guid>("ComentarioEventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComentarioEventoId");

                    b.HasIndex("EventoId");

                    b.HasIndex("Exibe")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("ComentarioEvento");
                });

            modelBuilder.Entity("Api_Event.Domains.Evento", b =>
                {
                    b.Property<Guid>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATE");

                    b.Property<string>("DescricaoEvento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstituicaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("TipoDeEventoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventoId");

                    b.HasIndex("InstituicaoId");

                    b.HasIndex("TipoDeEventoId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Api_Event.Domains.Instituicao", b =>
                {
                    b.Property<Guid>("InstitucaoId")
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

                    b.HasKey("InstitucaoId");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("Api_Event.Domains.Presenca", b =>
                {
                    b.Property<Guid>("PresencaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Situacao")
                        .HasColumnType("BIT");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PresencaId");

                    b.HasIndex("EventoId")
                        .IsUnique();

                    b.HasIndex("Situacao")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Presenca");
                });

            modelBuilder.Entity("Api_Event.Domains.TipoDeEvento", b =>
                {
                    b.Property<Guid>("TipoDeEventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TipoDeEventoId");

                    b.ToTable("TipoDeEvento");
                });

            modelBuilder.Entity("Api_Event.Domains.TipoDeUsuario", b =>
                {
                    b.Property<Guid>("TipoDeUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TipoDeUsuarioId");

                    b.ToTable("TipoDeUsuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
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

                    b.Property<Guid>("TipoDeUsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UsuarioId");

                    b.HasIndex("EmailUsuario")
                        .IsUnique();

                    b.HasIndex("TipoDeUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Api_Event.Domains.ComentarioEvento", b =>
                {
                    b.HasOne("Api_Event.Domains.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Event.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Evento", b =>
                {
                    b.HasOne("Api_Event.Domains.Instituicao", "instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Event.Domains.TipoDeEvento", "TipoDeEvento")
                        .WithMany()
                        .HasForeignKey("TipoDeEventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeEvento");

                    b.Navigation("instituicao");
                });

            modelBuilder.Entity("Api_Event.Domains.Presenca", b =>
                {
                    b.HasOne("Api_Event.Domains.Evento", "Evento")
                        .WithOne("Presenca")
                        .HasForeignKey("Api_Event.Domains.Presenca", "EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Event.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Api_Event.Domains.Usuario", b =>
                {
                    b.HasOne("Api_Event.Domains.TipoDeUsuario", "TipoDeUsuario")
                        .WithMany()
                        .HasForeignKey("TipoDeUsuarioId")
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
