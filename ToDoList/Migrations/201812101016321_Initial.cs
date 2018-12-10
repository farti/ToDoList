namespace ToDoListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Checked = c.Boolean(nullable: false),
                        ToDoListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ToDoLists", t => t.ToDoListId, cascadeDelete: true)
                .Index(t => t.ToDoListId);
            
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ToDoListId", "dbo.ToDoLists");
            DropIndex("dbo.Items", new[] { "ToDoListId" });
            DropTable("dbo.ToDoLists");
            DropTable("dbo.Items");
        }
    }
}
