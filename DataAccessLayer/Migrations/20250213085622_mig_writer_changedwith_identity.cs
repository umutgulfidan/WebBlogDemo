using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_writer_changedwith_identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_SenderID",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_WriterID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WriterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Writers_WriterMail",
                table: "Writers",
                column: "WriterMail",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
