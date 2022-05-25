namespace Bank_PBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ClientSend", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ClientSend");
        }
    }
}
