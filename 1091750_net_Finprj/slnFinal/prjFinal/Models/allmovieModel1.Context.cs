//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Common;//�s�W
    using System.Data.Entity.Core.EntityClient;//�s�W
    using System.Configuration;//�s�W

    public partial class allmovieEntities : DbContext
    {
        public allmovieEntities()
            : base("name=allmovieEntities")
        {
            //�H�U�����s�W
            var originalConnectionString = ConfigurationManager.ConnectionStrings["allmovieEntities"].ConnectionString;//�ק�Entities�W��
            var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
            var providerBuilder = factory.CreateConnectionStringBuilder();

            providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;

            providerBuilder.Add("Password", "yzuim1102netdbB"); // �[�JSQL�K�X���

            entityBuilder.ProviderConnectionString = providerBuilder.ToString();

            this.Database.Connection.ConnectionString = entityBuilder.ProviderConnectionString;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tabletmovieall1091750> Tabletmovieall1091750 { get; set; }
    }
}
