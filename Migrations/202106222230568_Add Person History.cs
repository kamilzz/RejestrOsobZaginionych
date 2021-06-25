namespace RejestrOsobZaginionych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonHistories",
                c => new
                    {
                        PersonHistoryId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        IsFound = c.Boolean(nullable: false),
                        LostDate = c.DateTime(nullable: false),
                        FoundDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonHistoryId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonHistories", "PersonId", "dbo.People");
            DropIndex("dbo.PersonHistories", new[] { "PersonId" });
            DropTable("dbo.PersonHistories");
        }
    }
}
