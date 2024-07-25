using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActorMovie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_ActorsId",
                table: "ActorMovie",
                column: "ActorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_MoviesId",
                table: "ActorMovie",
                column: "MoviesId",
                principalTable: "Actors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_MoviesId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.DropIndex(
                name: "IX_ActorMovie_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActorMovie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                table: "ActorMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
