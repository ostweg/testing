namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        ISBN = c.Int(nullable: false),
                        RentPriceCHF = c.Double(nullable: false),
                        LanguageISO = c.String(),
                        Customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .Index(t => t.Customer_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Salary = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalDate = c.DateTime(nullable: false),
                        returned = c.Boolean(nullable: false),
                        Book_Id = c.Int(),
                        Customers_id = c.Int(),
                        Employee_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Customers", t => t.Customers_id)
                .ForeignKey("dbo.Employees", t => t.Employee_id)
                .Index(t => t.Book_Id)
                .Index(t => t.Customers_id)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.Rentals", "Customers_id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Customer_id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Employee_id" });
            DropIndex("dbo.Rentals", new[] { "Customers_id" });
            DropIndex("dbo.Rentals", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Customer_id" });
            DropTable("dbo.Rentals");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Books");
        }
    }
}
