﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TutorMe.Models;

namespace TutorMe.Data
{
    public partial class TutorMeContext : DbContext
    {
        public TutorMeContext()
        {
        }

        public TutorMeContext(DbContextOptions<TutorMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupMember> GroupMember { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>(entity =>
            {
                entity.HasKey(e => e.ConnectionId);

                entity.HasIndex(e => e.ModuleId, "IX_Connections_ModuleId");

                entity.HasIndex(e => e.TuteeId, "IX_Connections_TuteeId");

                entity.HasIndex(e => e.TutorId, "IX_Connections_TutorId");

                entity.Property(e => e.ConnectionId).ValueGeneratedNever();

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Connections)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Tutee)
                    .WithMany(p => p.ConnectionsTutee)
                    .HasForeignKey(d => d.TuteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.ConnectionsTutor)
                    .HasForeignKey(d => d.TutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.ModuleId, "IX_Group_ModuleId");

                entity.Property(e => e.GroupId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ModuleId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Group_Module_FK");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasKey(e => e.GroupMemberId);

                entity.HasIndex(e => e.UserId, "IX_GroupMembers_UserId");

                entity.Property(e => e.GroupMemberId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.Property(e => e.GroupId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GroupMembers_Group_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GroupMembers_User_FK");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.InstitutionId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.Property(e => e.Faculty).IsRequired();

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.HasIndex(e => e.InstitutionId, "IX_Modules_InstitutionId");

                entity.Property(e => e.ModuleId).ValueGeneratedNever();

                entity.Property(e => e.InstitutionId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Modules_Institution_FK");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.HasIndex(e => e.TuteeId, "IX_Requests_TuteeId");

                entity.HasIndex(e => e.TutorId, "IX_Requests_TutorId");
                
                entity.HasIndex(e => e.ModuleId, "IX_Requests_ModuleId");

                entity.Property(e => e.RequestId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.HasOne(d => d.Tutee)
                    .WithMany(p => p.RequestsTutee)
                    .HasForeignKey(d => d.TuteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Tutee_FK");

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.RequestsTutor)
                    .HasForeignKey(d => d.TutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Tutor_FK");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.RequestModule)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Module_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.InstitutionId, "IX_User_InstitutionId");

                entity.HasIndex(e => e.UserTypeId, "IX_User_UserTypeId");

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())").HasMaxLength(36);

                entity.Property(e => e.Bio).IsRequired();

                entity.Property(e => e.DateOfBirth).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Gender).IsRequired();

                entity.Property(e => e.InstitutionId).HasDefaultValueSql("(newid())").HasMaxLength(36);

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserTypeId).HasDefaultValueSql("(newid())").HasMaxLength(36);;

                entity.Property(e => e.Year).IsRequired();

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Institutioin_FK");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserType_FK");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasDefaultValueSql("(newid())").HasMaxLength(36);

                entity.Property(e => e.Type).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}