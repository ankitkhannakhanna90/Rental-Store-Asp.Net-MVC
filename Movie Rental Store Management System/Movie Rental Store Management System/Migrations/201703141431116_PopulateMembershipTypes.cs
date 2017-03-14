namespace Movie_Rental_Store_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate)VALUES('Pay As You Go',0,1,0)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate)VALUES('Monthly',30,3,10)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate)VALUES('Quarterly',60,6,15)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate)VALUES('Annually',120,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
