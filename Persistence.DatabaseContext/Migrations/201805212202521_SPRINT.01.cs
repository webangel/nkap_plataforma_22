namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class SPRINT01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(nullable: false, maxLength: 100, unicode: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Categoria_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rol = c.String(nullable: false, maxLength: 100, unicode: false),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Roles_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 120, unicode: false),
                        Apellidos = c.String(nullable: false, maxLength: 120, unicode: false),
                        Email = c.String(nullable: false, maxLength: 120, unicode: false),
                        Password = c.String(nullable: false, maxLength: 120, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        Foto = c.String(maxLength: 120, unicode: false),
                        Foto2 = c.String(maxLength: 120, unicode: false),
                        Slug = c.String(nullable: false, maxLength: 100, unicode: false),
                        Dni = c.String(maxLength: 8, unicode: false),
                        Deleted = c.Boolean(nullable: false),
                        IdRol = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Usuarios_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.Slug, unique: true, name: "SlugUsers")
                .Index(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Roles");
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropIndex("dbo.Usuarios", "SlugUsers");
            DropTable("dbo.Usuarios",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Usuarios_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Roles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Roles_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Categorias",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Categoria_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
