using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DeleteStoreProceduresAndInsertThemAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCoverType");

            migrationBuilder.Sql(@"CREATE PROC usp_GetCoatingTypes
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.CoatingTypes 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetCoatingType
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.CoatingTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCoatingType
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.CoatingTypes
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteCoatingType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.CoatingTypes 
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateCoatingType
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.CoatingTypes(Name)
                                    VALUES (@Name)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoatingTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoatingType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCoatingType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCoatingType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCoatingType");
        }
    }
}
