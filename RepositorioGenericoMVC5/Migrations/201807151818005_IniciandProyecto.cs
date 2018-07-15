namespace RepositorioGenericoMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniciandProyecto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        IdNacionalidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nacionalidads", t => t.IdNacionalidad, cascadeDelete: true)
                .Index(t => t.IdNacionalidad);
            
            CreateTable(
                "dbo.Nacionalidads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreNacionalidad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "IdNacionalidad", "dbo.Nacionalidads");
            DropForeignKey("dbo.Direcciones", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Personas", new[] { "IdNacionalidad" });
            DropIndex("dbo.Direcciones", new[] { "Persona_Id" });
            DropTable("dbo.Nacionalidads");
            DropTable("dbo.Personas");
            DropTable("dbo.Direcciones");
        }
    }
}
