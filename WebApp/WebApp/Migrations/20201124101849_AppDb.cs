using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApp.Migrations
{
    public partial class AppDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    tag_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    user_login = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    user_password_salt = table.Column<int>(type: "integer", nullable: false),
                    user_password_hash = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    product_decimal_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    product_creation_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(2)"),
                    product_created_by = table.Column<int>(type: "integer", nullable: false),
                    product_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    product_deletion_date = table.Column<DateTime>(type: "date", nullable: true),
                    product_deleted_by = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "product_creator",
                        column: x => x.product_created_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "product_deleter",
                        column: x => x.product_deleted_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchased_products",
                columns: table => new
                {
                    purchased_product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    purchased_product_vendor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    purchased_product_vendor_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    purchased_product_short_description = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    purchased_product_full_description = table.Column<string>(type: "text", nullable: true),
                    purchased_product_doc_link = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    purchased_product_creation_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(2)"),
                    purchased_product_created_by = table.Column<int>(type: "integer", nullable: false),
                    purchased_product_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    purchased_product_deletion_date = table.Column<DateTime>(type: "date", nullable: true),
                    purchased_product_deleted_by = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchased_products", x => x.purchased_product_id);
                    table.ForeignKey(
                        name: "purchased_product_creator",
                        column: x => x.purchased_product_created_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "purchased_product_deleter",
                        column: x => x.purchased_product_deleted_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    request_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    request_description = table.Column<string>(type: "text", nullable: false),
                    request_creation_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(2)"),
                    request_created_by = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.request_id);
                    table.ForeignKey(
                        name: "request_author",
                        column: x => x.request_created_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "themes",
                columns: table => new
                {
                    theme_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    theme_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    theme_description = table.Column<string>(type: "text", nullable: false),
                    theme_creation_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(2)"),
                    theme_created_by = table.Column<int>(type: "integer", nullable: false),
                    theme_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    theme_deletion_date = table.Column<DateTime>(type: "date", nullable: true),
                    theme_deleted_by = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_themes", x => x.theme_id);
                    table.ForeignKey(
                        name: "theme_creator",
                        column: x => x.theme_created_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "theme_deleter",
                        column: x => x.theme_deleted_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_tags",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_tags", x => new { x.tag_id, x.product_id });
                    table.ForeignKey(
                        name: "product_has_tags",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tag_refers_to_products",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_composition",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    purchased_product_id = table.Column<int>(type: "integer", nullable: false),
                    purchased_product_amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_composition", x => new { x.purchased_product_id, x.product_id });
                    table.ForeignKey(
                        name: "product_consist_of_purchased_products",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "purchased_products_included_in_products",
                        column: x => x.purchased_product_id,
                        principalTable: "purchased_products",
                        principalColumn: "purchased_product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "request_composition",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "integer", nullable: false),
                    purchased_product_id = table.Column<int>(type: "integer", nullable: false),
                    purchased_product_amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request_composition", x => new { x.purchased_product_id, x.request_id });
                    table.ForeignKey(
                        name: "purchased_products_included_in_request",
                        column: x => x.purchased_product_id,
                        principalTable: "purchased_products",
                        principalColumn: "purchased_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "request_consist_of_purchased_products",
                        column: x => x.request_id,
                        principalTable: "requests",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "theme_composition",
                columns: table => new
                {
                    theme_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    product_amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theme_composition", x => new { x.product_id, x.theme_id });
                    table.ForeignKey(
                        name: "product_included_in_themes",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "theme_consist_of_products",
                        column: x => x.theme_id,
                        principalTable: "themes",
                        principalColumn: "theme_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_composition_product_id",
                table: "product_composition",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_tags_product_id",
                table: "product_tags",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_creator",
                table: "products",
                column: "product_created_by");

            migrationBuilder.CreateIndex(
                name: "IX_product_deleter",
                table: "products",
                column: "product_deleted_by");

            migrationBuilder.CreateIndex(
                name: "product_decimal_number",
                table: "products",
                column: "product_decimal_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "product_id",
                table: "products",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchased_product_creator",
                table: "purchased_products",
                column: "purchased_product_created_by");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_product_deleter",
                table: "purchased_products",
                column: "purchased_product_deleted_by");

            migrationBuilder.CreateIndex(
                name: "purchased_product_id",
                table: "purchased_products",
                column: "purchased_product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_request_composition_request_id",
                table: "request_composition",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_request_author",
                table: "requests",
                column: "request_created_by");

            migrationBuilder.CreateIndex(
                name: "request_id",
                table: "requests",
                column: "request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "request_name",
                table: "requests",
                column: "request_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tag_id",
                table: "tags",
                column: "tag_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tag_name",
                table: "tags",
                column: "tag_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_theme_composition_theme_id",
                table: "theme_composition",
                column: "theme_id");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship1",
                table: "themes",
                column: "theme_created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship2",
                table: "themes",
                column: "theme_deleted_by");

            migrationBuilder.CreateIndex(
                name: "theme_id",
                table: "themes",
                column: "theme_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "theme_name",
                table: "themes",
                column: "theme_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "users",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_login",
                table: "users",
                column: "user_login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_composition");

            migrationBuilder.DropTable(
                name: "product_tags");

            migrationBuilder.DropTable(
                name: "request_composition");

            migrationBuilder.DropTable(
                name: "theme_composition");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "purchased_products");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "themes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
