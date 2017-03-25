namespace Movie_Rental_Store_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRentalForm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewRentals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.NewRentals", "MovieId", "dbo.Movies");
            DropIndex("dbo.NewRentals", new[] { "CustomerId" });
            DropIndex("dbo.NewRentals", new[] { "MovieId" });
            RenameColumn(table: "dbo.NewRentals", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.NewRentals", name: "MovieId", newName: "Movie_Id");
            AddColumn("dbo.NewRentals", "DateRented", c => c.DateTime(nullable: false));
            AddColumn("dbo.NewRentals", "DateReturned", c => c.DateTime());
            AlterColumn("dbo.NewRentals", "Customer_Id", c => c.Int());
            AlterColumn("dbo.NewRentals", "Movie_Id", c => c.Int());
            CreateIndex("dbo.NewRentals", "Customer_Id");
            CreateIndex("dbo.NewRentals", "Movie_Id");
            AddForeignKey("dbo.NewRentals", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.NewRentals", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.NewRentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.NewRentals", new[] { "Movie_Id" });
            DropIndex("dbo.NewRentals", new[] { "Customer_Id" });
            AlterColumn("dbo.NewRentals", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.NewRentals", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.NewRentals", "DateReturned");
            DropColumn("dbo.NewRentals", "DateRented");
            RenameColumn(table: "dbo.NewRentals", name: "Movie_Id", newName: "MovieId");
            RenameColumn(table: "dbo.NewRentals", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.NewRentals", "MovieId");
            CreateIndex("dbo.NewRentals", "CustomerId");
            AddForeignKey("dbo.NewRentals", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewRentals", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
