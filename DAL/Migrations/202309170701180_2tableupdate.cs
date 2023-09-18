namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2tableupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "PremiumId", "dbo.Premiums");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropIndex("dbo.Payments", new[] { "PremiumId" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            RenameColumn(table: "dbo.Payments", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Payments", "Payment_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Premiums", "PackageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "UserId");
            CreateIndex("dbo.Premiums", "PackageId");
            AddForeignKey("dbo.Premiums", "PackageId", "dbo.Packages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Payments", "PremiumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PremiumId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Premiums", "PackageId", "dbo.Packages");
            DropIndex("dbo.Premiums", new[] { "PackageId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            AlterColumn("dbo.Payments", "UserId", c => c.Int());
            DropColumn("dbo.Premiums", "PackageId");
            DropColumn("dbo.Payments", "Payment_date");
            RenameColumn(table: "dbo.Payments", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Payments", "User_Id");
            CreateIndex("dbo.Payments", "PremiumId");
            AddForeignKey("dbo.Payments", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Payments", "PremiumId", "dbo.Premiums", "Id", cascadeDelete: true);
        }
    }
}
