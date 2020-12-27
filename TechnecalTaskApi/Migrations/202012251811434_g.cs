namespace TechnecalTaskApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        P_Id = c.Int(nullable: false, identity: true),
                        p_Name = c.String(),
                        P_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        P_Photo = c.String(),
                        P_LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.P_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
