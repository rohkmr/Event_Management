namespace EventDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        IsPrivate = c.Boolean(nullable: false),
                        Duration = c.Single(),
                        Description = c.String(maxLength: 50),
                        OtherDetails = c.String(maxLength: 500),
                        InvitedEmails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Event");
        }
    }
}
