namespace Movie_Rental_Store_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewRentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRentals", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.NewRentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.NewRentals", new[] { "MovieId" });
            DropIndex("dbo.NewRentals", new[] { "CustomerId" });
            DropTable("dbo.NewRentals");
        }
    }
}
