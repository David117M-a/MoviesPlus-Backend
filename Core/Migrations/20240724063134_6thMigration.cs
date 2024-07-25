using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class _6thMigration : Migration
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

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "ActorMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "ActorsId",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_ActorsId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ActorMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "ActorMovie",
                newName: "ActorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_ActorId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_ActorsId");

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
