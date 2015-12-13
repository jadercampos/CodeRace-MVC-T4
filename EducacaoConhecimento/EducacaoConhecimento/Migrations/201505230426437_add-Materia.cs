namespace EducacaoConhecimento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMateria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MateriaId);
            
            CreateTable(
                "dbo.NivelUsuario",
                c => new
                    {
                        NivelUsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        PontuacaoInicial = c.Int(nullable: false),
                        PontuacaoFinal = c.Int(nullable: false),
                        Peso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NivelUsuarioId);
            
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        PerguntaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 400),
                        MateriaId = c.Int(nullable: false),
                        Dificuldade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PerguntaId)
                .ForeignKey("dbo.Materia", t => t.MateriaId, cascadeDelete: true)
                .Index(t => t.MateriaId);
            
            CreateTable(
                "dbo.Resposta",
                c => new
                    {
                        RespostaId = c.Int(nullable: false, identity: true),
                        PerguntaId = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 400),
                        Correta = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RespostaId)
                .ForeignKey("dbo.Pergunta", t => t.PerguntaId, cascadeDelete: true)
                .Index(t => t.PerguntaId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        CodUsuario = c.String(nullable: false, maxLength: 100),
                        Pontuacao = c.Int(nullable: false),
                        Avatar = c.String(maxLength: 100),
                        NivelUsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodUsuario)
                .ForeignKey("dbo.NivelUsuario", t => t.NivelUsuarioId, cascadeDelete: true)
                .Index(t => t.NivelUsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profile", "NivelUsuarioId", "dbo.NivelUsuario");
            DropForeignKey("dbo.Resposta", "PerguntaId", "dbo.Pergunta");
            DropForeignKey("dbo.Pergunta", "MateriaId", "dbo.Materia");
            DropIndex("dbo.Profile", new[] { "NivelUsuarioId" });
            DropIndex("dbo.Resposta", new[] { "PerguntaId" });
            DropIndex("dbo.Pergunta", new[] { "MateriaId" });
            DropTable("dbo.Profile");
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
            DropTable("dbo.NivelUsuario");
            DropTable("dbo.Materia");
        }
    }
}
