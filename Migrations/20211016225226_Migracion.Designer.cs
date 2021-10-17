﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registro_Roles.DAL;

namespace Registro_Roles.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211016225226_Migracion")]
    partial class Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Registro_Roles.Entidades.aPermiso", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripción")
                        .HasColumnType("TEXT");

                    b.HasKey("RolId");

                    b.ToTable("aPermiso");
                });

            modelBuilder.Entity("Registro_Roles.Entidades.aPermisosDetalle", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermisoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolId");

                    b.HasIndex("PermisoId");

                    b.ToTable("aPermisosDetalle");
                });

            modelBuilder.Entity("Registro_Roles.Entidades.rPermiso", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EsAsignado")
                        .HasColumnType("TEXT");

                    b.Property<int>("PermisoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolId");

                    b.ToTable("rPermiso");
                });

            modelBuilder.Entity("Registro_Roles.Entidades.aPermisosDetalle", b =>
                {
                    b.HasOne("Registro_Roles.Entidades.rPermiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registro_Roles.Entidades.aPermiso", null)
                        .WithMany("aPermisosDetalle")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("Registro_Roles.Entidades.aPermiso", b =>
                {
                    b.Navigation("aPermisosDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
