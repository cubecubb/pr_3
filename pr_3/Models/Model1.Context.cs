//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pr_3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UVD_BDEntities4 : DbContext
    {
        public UVD_BDEntities4()
            : base("name=UVD_BDEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<article> article { get; set; }
        public virtual DbSet<award> award { get; set; }
        public virtual DbSet<crime> crime { get; set; }
        public virtual DbSet<department> department { get; set; }
        public virtual DbSet<gender> gender { get; set; }
        public virtual DbSet<officer> officer { get; set; }
        public virtual DbSet<rank> rank { get; set; }
        public virtual DbSet<register> register { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<search> search { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<type_of_search> type_of_search { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<vacancy> vacancy { get; set; }
    }
}
