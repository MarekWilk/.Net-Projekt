﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fryzjerski.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZakladFryzjerskiEntities : DbContext
    {
        public ZakladFryzjerskiEntities()
            : base("name=ZakladFryzjerskiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Fryzjer> Fryzjer { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Usługa> Usługa { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<Wizyta> Wizyta { get; set; }
    }
}