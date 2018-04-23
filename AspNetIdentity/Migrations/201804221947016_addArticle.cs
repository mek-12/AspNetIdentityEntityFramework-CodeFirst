namespace AspNetIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                {
                    ArtcileId = c.Int(nullable: false, identity: true),
                    ArticleName = c.String(nullable: false),
                    ArticleContent = c.String(nullable: false),
                    ApllicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.ArtcileId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApllicationUser_Id)
                .Index(t => t.ApllicationUser_Id);


        }    
        
        public override void Down()
        {
           
        }
    }
}
