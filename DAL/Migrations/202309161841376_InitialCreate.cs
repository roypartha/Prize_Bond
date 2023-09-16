namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageName = c.String(),
                        Ammount = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageId = c.Int(nullable: false),
                        PremiumId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Premiums", t => t.PremiumId, cascadeDelete: true)
                .Index(t => t.PackageId)
                .Index(t => t.PremiumId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Premiums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CraeteAt = c.DateTime(nullable: false),
                        CloseAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        IsBan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrizeBonds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BondId = c.String(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PremiumId", "dbo.Premiums");
            DropForeignKey("dbo.Premiums", "UserId", "dbo.Users");
            DropForeignKey("dbo.PrizeBonds", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Payments", "PackageId", "dbo.Packages");
            DropIndex("dbo.PrizeBonds", new[] { "UserId" });
            DropIndex("dbo.Premiums", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.Payments", new[] { "PremiumId" });
            DropIndex("dbo.Payments", new[] { "PackageId" });
            DropTable("dbo.PrizeBonds");
            DropTable("dbo.Users");
            DropTable("dbo.Premiums");
            DropTable("dbo.Payments");
            DropTable("dbo.Packages");
        }
    }
}
