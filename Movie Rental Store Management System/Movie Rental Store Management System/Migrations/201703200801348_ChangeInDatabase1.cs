namespace Movie_Rental_Store_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInDatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
