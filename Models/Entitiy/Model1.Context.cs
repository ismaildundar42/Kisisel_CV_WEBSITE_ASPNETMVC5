﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UdemyMVCCVsitesi.Models.Entitiy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbCVSitesiEntities : DbContext
    {
        public DbCVSitesiEntities()
            : base("name=DbCVSitesiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_deneyim> tbl_deneyim { get; set; }
        public virtual DbSet<tbl_egitim> tbl_egitim { get; set; }
        public virtual DbSet<tbl_hakkimda> tbl_hakkimda { get; set; }
        public virtual DbSet<tbl_hobiler> tbl_hobiler { get; set; }
        public virtual DbSet<tbl_iletisim> tbl_iletisim { get; set; }
        public virtual DbSet<tbl_login> tbl_login { get; set; }
        public virtual DbSet<tbl_oduller> tbl_oduller { get; set; }
        public virtual DbSet<tbl_yetenekler> tbl_yetenekler { get; set; }
        public virtual DbSet<tbl_sosyalmedya> tbl_sosyalmedya { get; set; }
    }
}
