using System;
using LightupFactoryService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LightupFactoryService.ContextStr
{
    public class LightUpFactoryContext : DbContext
    {
        //public LightUpFactoryContext(DbContextOptions<LightUpFactoryContext> options)
        //{
        //}

        /// <summary>
        /// 测试表
        /// </summary>
        //public virtual DbSet<Aqllevel> Aqllevel { get; set; }

        //public virtual DbSet<Capa> Capa { get; set; }
        #region WMS

        /// <summary>
        /// 产品
        /// </summary>
        //public virtual DbSet<Product> Product { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        //public virtual DbSet<Unit> Unit { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        //public virtual DbSet<Producttype> Producttype { get; set; }

        /// <summary>
        /// 产品系列
        /// </summary>
        //public virtual DbSet<Productfamily> Productfamily { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        //public virtual DbSet<Customer> Customer { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        //public virtual DbSet<Supplier> Supplier { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        //public virtual DbSet<Warehouse> Warehouse { get; set; }

        /// <summary>
        /// 货位
        /// </summary>
        //public virtual DbSet<StockPoint> StockPoint { get; set; }

        #endregion

        #region SystemRelated       
        /// <summary>
        /// 服务内容
        /// </summary>
        public virtual DbSet<serviceRequestLog> serviceRequestLog { get; set; }
      
        /// <summary>
        /// 公司
        /// </summary>
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        #endregion

        #region Knowledge management
        public virtual DbSet<KnowledgePoint> KnowledgePoint{ get; set; }
        #endregion

        #region FamilyTree
        // add class for family tree management,2022-1-12
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<MemberRelation> MemberRelation { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<RelationShip> RelationShip { get; set; }
        public virtual DbSet<Story> Story { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<SectionDetail> SectionDetail { get; set; }
        public virtual DbSet<UserFamilyMapping> UserFamilyMapping { get; set; }
        public virtual DbSet<KnowledgeDetail> KnowledgeDetail { get; set; }
        public virtual DbSet<ObjectsEditHistory> ObjectsEditHistory { get; set; }

        public virtual DbSet<GroupEdit> GroupEdit { get; set; }
        public virtual DbSet<GroupEditHistory> GroupEditHistory { get; set; }
        public virtual DbSet<FamilySquare> FamilySquare { get; set; }
        public virtual DbSet<FamilySquareDetails> FamilySquareDetails { get; set; }

        public virtual DbSet<AuditTask> AuditTask { get; set; }
        public virtual DbSet<AuditHistory> AuditHistory { get; set; }

        public virtual DbSet<dataPermission> dataPermission { get; set; }
        #endregion

        public LightUpFactoryContext(DbContextOptions<LightUpFactoryContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("User Id=sa;Password=xxzx_123456;data source=.\\sqlexpress;initial catalog=LightUpFactory; ");
            //            }

            base.OnConfiguring(optionsBuilder);
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
