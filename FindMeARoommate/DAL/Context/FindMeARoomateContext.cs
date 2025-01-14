﻿using System;
using System.Collections.Generic;
using FindMeARoommate.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FindMeARoommate.DAL.Context
{
    public partial class FindMeARoomateContext : DbContext
    {
        public FindMeARoomateContext()
        {
        }

        public FindMeARoomateContext(DbContextOptions<FindMeARoomateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<Dormitory> Dormitories { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentRoom> StudentRooms { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(10);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(10);
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AnnouncementId).ValueGeneratedOnAdd();

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.AnnouncementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applications_Announcements");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applications_Students");
            });

            modelBuilder.Entity<Dormitory>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DormitoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.Dormitory)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.DormitoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Dormitories");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Surname).HasMaxLength(20);
            });

            modelBuilder.Entity<StudentRoom>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StudentId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.StudentRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentRooms_Rooms");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentRooms)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentRooms_Students");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
