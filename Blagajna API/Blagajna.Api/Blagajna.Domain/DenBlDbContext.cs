using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Domain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Domain
{
    public class DenBlDbContext : DbContext
    {
        public DenBlDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DenSmetka> DenSmetki { get; set; }
        public DbSet<DenDocument> DenDocumenti { get; set; }
        public DbSet<DenIzvod> DenIzvodi { get; set; }
        public DbSet<Vraboten> Vraboteni { get; set; }
        public DbSet<PresmetkovnaEd> PresmetkovniEd { get; set; }
        public DbSet<DenBlSostojba> DenBlSostojba { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DenDocument>()
                .HasOne(d => d.Vraboten)
                .WithMany(v => v.DenDocuments)
                .HasForeignKey(d => d.VrabotenId);
            modelBuilder.Entity<DenDocument>()
                .HasOne(d => d.PresmetkovnaEd)
                .WithMany(v => v.DenDocuments)
                .HasForeignKey(d => d.PresmetkovnaEdId);
            modelBuilder.Entity<DenDocument>()
                .HasMany(s => s.DenSmetki)
                .WithOne(d => d.DenDocumnet)
                .HasForeignKey(s => s.DenDocumnetId);
            modelBuilder.Entity<DenDocument>()
                .HasOne(d => d.DenIzvod)
                .WithMany(v => v.DenDocuments)
                .HasForeignKey(d => d.DenIzvodId);
            


            modelBuilder.Entity<Vraboten>()
                .HasData(new Vraboten
                {
                    Id = 1,
                    Mb = 190,
                    FullName = "Ivan Mitev"
                },
                new Vraboten{
                    Id = 2,
                    Mb = 191,
                    FullName = "Ljubica Donevska"
                });

            modelBuilder.Entity<PresmetkovnaEd>()
                .HasData(new PresmetkovnaEd
                {
                    Id = 1,
                    PeNumber = 250,
                    PeName = "SK 123 ZZ" 
                },
                new PresmetkovnaEd
                {
                    Id = 2,
                    PeNumber = 251,
                    PeName = "SK 124 HZ"
                });
            modelBuilder.Entity<DenBlSostojba>()
                .HasData(new DenBlSostojba
                {
                    Id = 1,
                    DenSostojba = 1000000
                    
                });
            modelBuilder.Entity<DenSmetka>()
                .HasData(new DenSmetka
                {
                    Id = 1,
                    DenDocumnetId = 1,
                    SmetkaDate = new DateTime(2020, 02, 15),
                    SmetkaInfo = "1234aaa",
                    SmetkaTotal = 1000
                },
                new DenSmetka
                {
                    Id = 2,
                    DenDocumnetId = 1,
                    SmetkaDate = new DateTime(2020, 02, 15),
                    SmetkaInfo = "123w",
                    SmetkaTotal = 4000
                });

            modelBuilder.Entity<DenDocument>()
                .HasData(new DenDocument
                {
                    Id = 1,
                    VrabotenId = 1,
                    PresmetkovnaEdId = 1,
                    VidDocument = 1,
                    DocDate = new DateTime(2021, 01, 01),
                    DenIzvodId = 1
                    
                });
            modelBuilder.Entity<DenIzvod>()
                .HasData(new DenIzvod
                {
                    Id = 1,
                    DenBlSostojba = 1000000,
                    IzvodDate = new DateTime(2021, 01, 01),
                    VkupenPriem = 0,
                    VkupnaIsplata = 0,
                    Saldo = 0,
                    FinalIzvod = false
                });
        }
    }

}
