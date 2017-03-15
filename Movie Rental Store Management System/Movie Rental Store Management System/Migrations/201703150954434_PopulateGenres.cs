namespace Movie_Rental_Store_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name)VALUES('Action')");
            Sql("INSERT INTO Genres (Name)VALUES('Adventure')");
            Sql("INSERT INTO Genres (Name)VALUES('Comedy')");
            Sql("INSERT INTO Genres (Name)VALUES('Mystery')");
            Sql("INSERT INTO Genres (Name)VALUES('Horror')");
            Sql("INSERT INTO Genres (Name)VALUES('Fantasy')");
            Sql("INSERT INTO Genres (Name)VALUES('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
