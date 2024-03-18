using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Skeppsgarden.Data.Migrations
{
    /// <inheritdoc />
    public partial class FreshDbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BedTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hyperlinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hyperlinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Image = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViewTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MenuItemTypeId = table.Column<int>(type: "integer", nullable: false),
                    Ingredients = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuItemsTypes_MenuItemTypeId",
                        column: x => x.MenuItemTypeId,
                        principalTable: "MenuItemsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomNumber = table.Column<int>(type: "integer", nullable: false),
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    BedTypeId = table.Column<int>(type: "integer", nullable: false),
                    ExtraBedId = table.Column<int>(type: "integer", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequested = table.Column<bool>(type: "boolean", nullable: false),
                    Images = table.Column<string>(type: "text", nullable: false),
                    ViewTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BedTypes_BedTypeId",
                        column: x => x.BedTypeId,
                        principalTable: "BedTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_ExtraTypes_ExtraBedId",
                        column: x => x.ExtraBedId,
                        principalTable: "ExtraTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_ViewTypes_ViewTypeId",
                        column: x => x.ViewTypeId,
                        principalTable: "ViewTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedDates_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "integer", nullable: false),
                    NumberOfNights = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    SpecialRequirements = table.Column<string>(type: "text", nullable: true),
                    NotesToCustomer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalReservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricalReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "integer", nullable: false),
                    NumberOfNights = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    SpecialRequirements = table.Column<string>(type: "text", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "integer", nullable: false),
                    NumberOfNights = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    SpecialRequirements = table.Column<string>(type: "text", nullable: true),
                    NotesToCustomer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsFacilityTypes",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    FacilityTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsFacilityTypes", x => new { x.RoomId, x.FacilityTypeId });
                    table.ForeignKey(
                        name: "FK_RoomsFacilityTypes_FacilityTypes_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsFacilityTypes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsUtilityTypes",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    UtilityTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsUtilityTypes", x => new { x.RoomId, x.UtilityTypeId });
                    table.ForeignKey(
                        name: "FK_RoomsUtilityTypes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsUtilityTypes_UtilityTypes_UtilityTypeId",
                        column: x => x.UtilityTypeId,
                        principalTable: "UtilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Enjoy the serenity of casting your line into calm waters and embracing the art of fishing. Whether you're a seasoned angler or a novice adventurer, fishing offers a tranquil escape into nature's embrace. Feel the excitement as you wait for the tug on your line, surrounded by the picturesque beauty of lakes, rivers, or the vast ocean. Discover the joy of reeling in your catch and creating cherished memories amidst serene landscapes.", "~/images/activities/fishing.jpg", "Fishing", "" },
                    { 2, "Explore scenic landscapes and picturesque routes on an exhilarating cycling adventure. Feel the wind in your face as you pedal through tranquil countryside and challenging trails. Discover hidden gems and breathtaking vistas while embracing the freedom of the open road. Cycling offers invigorating experiences for enthusiasts of all levels.", "~/images/activities/cycling.jpg", "Cycling", "" },
                    { 3, "Experience the freedom of hiking amidst nature's wonders. Explore winding trails through forests, mountains, and valleys. Whether you prefer a leisurely walk or a challenging ascent, hiking offers a chance to connect with the wilderness. Immerse yourself in the sights and sounds of nature as you uncover hidden treasures along the way. Embrace the adventure and serenity of hiking.", "~/images/activities/hiking.jpg", "Hiking", "" },
                    { 4, "Sail away on an unforgettable coastal journey with a scenic cruise. Experience the beauty of our coastline from the comfort of a boat as you glide through tranquil waters and soak in breathtaking views. Whether you crave relaxation or adventure, our cruise promises an unforgettable experience for all. Discover hidden gems and picturesque landscapes as you sail along our stunning shores.", "~/images/activities/cruise.jpg", "Cruise", "" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03f23900-4a30-49e1-aae0-d498b0f2a6b6", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6a0d484a-08ef-467c-ab1f-b6fb11239452", 0, "b49330bf-722f-489d-a2d2-a5e0d0473e6b", "skeppsgarden@test.bg", false, false, null, null, "SKEPPSGARDEN-TEST", "AQAAAAIAAYagAAAAEKvM6AMxkSe1wIHzsCIrBV9ZQxwuKz4yl68vNaZbHwaESgV+NlzKgzTidGZ2kiB8mw==", null, false, "FODyy1DST0mx6ZlCHac8wA==", false, "skeppsgarden-test" });

            migrationBuilder.InsertData(
                table: "BedTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Double" },
                    { 3, "BunkBed" },
                    { 4, "SofaBed" },
                    { 5, "Cot" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "End", "Image", "Location", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("0405f662-4ae3-4536-b789-645052a5e771"), "Enjoy an evening filled with laughter as comedians take the stage for an open mic stand-up session.", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5708), "~/images/events/comedy.jpg", "Main Stage Skeppsgården", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5704), "Stand-up Open Mic" },
                    { new Guid("0480cafd-5f9b-408e-844b-371adde89559"), "Witness a beautiful union at the grand Mr. and Mrs. Skeppsgården Wedding on the Main Stage, filled with love and joy.", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5727), "~/images/events/wedding.jpg", "Main Stage Skeppsgården", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5726), "Mr. and Mrs. Skeppsgården Wedding" },
                    { new Guid("297de154-9adf-4cbb-bad1-1cf41675f051"), "Unconventional and ironically entertaining, join the Boring Conference for a unique experience on the Main Stage at Skeppsgården.", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5716), "~/images/events/conference.jpg", "Main Stage Skeppsgården", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5716), "Boring Conference" },
                    { new Guid("8f53e3b6-129d-4fed-9030-625284d3cfb4"), "Immerse yourself in the soulful tunes of Irish folk music, performed live on the Main Stage at Skeppsgården.", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5714), "~/images/events/concert.jpg", "Main Stage Skeppsgården", new DateTime(2024, 2, 25, 10, 26, 0, 802, DateTimeKind.Utc).AddTicks(5713), "Irish Folk Music" }
                });

            migrationBuilder.InsertData(
                table: "ExtraTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Double" },
                    { 3, "BunkBed" },
                    { 4, "SofaBed" },
                    { 5, "Cot" }
                });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PetFriendly" },
                    { 2, "FreeParking" },
                    { 3, "SwimmingPool" },
                    { 4, "FreeWifi" },
                    { 5, "FlatScreenTV" },
                    { 6, "Lounge" },
                    { 7, "CaravanParking" },
                    { 8, "Garden" },
                    { 9, "Toiletries" },
                    { 10, "Towels" },
                    { 11, "Bedsheets" },
                    { 12, "Laundry" },
                    { 13, "OutdoorFurniture" },
                    { 14, "Wardrobe" },
                    { 15, "Shower" },
                    { 16, "SittingArea" },
                    { 17, "BoardGames" },
                    { 18, "SharedRefrigerator" },
                    { 19, "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "LocalPlaces",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Valdemarsvik is a locality situated alongside the bay of Valdemarsviken, which connects to the Baltic Sea, and is the seat of Valdemarsvik Municipality in Östergötland County, Sweden. The coastal area is a popular summer destination, particularly with Swedish tourists.", "~/images/local-places/Valdemarsvik.jpg", "Valdemarsvik", "https://www.valdemarsvik.se/visit/" },
                    { 2, "Gamleby is the second largest locality situated in Västervik Municipality, Kalmar County, Sweden with 2,775 inhabitants in 2010. It is situated about 20 km north-west of Västervik, in the area known as Tjust.", "~/images/local-places/Gamleby.jpg", "Gamleby", "https://www.gamleby.se/turist.html" },
                    { 3, "Loftahammar is a locality situated in Västervik Municipality, Kalmar County, Sweden with 404 inhabitants in 2010. It is a coastal town located on a peninsula and has roots dating back to the mid-13th century, with a population that grows by several thousand during the summer months.", "~/images/local-places/Loftahammar.jpg", "Loftahammar", "https://loftahammar.com/pa-besok/" },
                    { 4, "Tindered is a popular destination in Småland, Sweden, where visitors can enjoy a variety of activities and amenities. At Tindered Lantkök, the on-site restaurant and café, guests can enjoy fika, home-baked goods, daily specials, and à la carte dishes, as well as visit the farm shop for gifts, locally produced items, newspapers, and ice cream.", "~/images/local-places/Tindered.jpg", "Tindered", "https://www.tindered.se/" },
                    { 5, "Västervik is a city and the seat of Västervik Municipality, Kalmar County, Sweden, with 36,747 inhabitants in 2021. It is one of three coastal towns with a notable population size in the province of Småland and is known as the archipelago town in Småland, where visitors can experience tranquility, nature, fun events and at the same time put a golden edge on their existence.", "~/images/local-places/Vastervik.jpg", "Västervik", "https://www.vastervik.com/" },
                    { 6, "Vimmerby is a city and the seat of Vimmerby Municipality, Kalmar County, Sweden with 10,934 inhabitants in 2010. It is one of the oldest cities in Sweden and received its charter as early as the fourteenth century, with its main street, Storgatan, still retaining its medieval shape.", "~/images/local-places/Vimmerby.jpg", "Vimmerby", "https://www.vimmerby.com/" },
                    { 7, "Norrköping is a city in the province of Östergötland in eastern Sweden and the seat of Norrköping Municipality, Östergötland County, about 160 km southwest of the national capital Stockholm. The city has a population of 95,618 inhabitants in 2016, out of a municipal total of 130,050, making it Sweden’s tenth largest city and eighth largest municipality.", "~/images/local-places/Norrkoping.jpg", "Norrköping", "https://www.norrkoping.se/" },
                    { 8, "Kolmården is a densely forested rocky ridge that separates the Swedish provinces of Södermanland and Östergötland, and historically formed the border between the land of the Swedes and the land of the Geats. It is also home to Kolmården Wildlife Park, one of Scandinavia’s most exciting experiences, covering 1.5 square kilometers and home to countless animal species, thrilling rides, and magical shows.", "~/images/local-places/Kolmarden.jpg", "Kolmården", "https://www.kolmarden.com/" },
                    { 9, "Söderköping is a locality and the seat of Söderköping Municipality, Östergötland County, Sweden with 6,951 inhabitants in 2010. It is a charming small town with a rich history, located at the mouth of the river Storån on the Baltic Sea coast, and is known for its well-preserved medieval town center and beautiful natural surroundings.", "~/images/local-places/Soderkoping.jpg", "Söderköping", "https://visit.soderkoping.se/sv/" },
                    { 10, "Sweden is a Scandinavian nation with thousands of coastal islands and inland lakes, along with vast boreal forests and glaciated mountains. Its principal cities, eastern capital Stockholm and southwestern Gothenburg and Malmö, are all coastal. Stockholm is built on 14 islands. It has more than 50 bridges, as well as the medieval old town, Gamla Stan, royal palaces and museums such as open-air Skansen.", "~/images/local-places/VisitSweden.jpg", "Visit Sweden", "https://visitsweden.com/" }
                });

            migrationBuilder.InsertData(
                table: "MenuItemsTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "MainCourse" },
                    { 3, "Vegetarian" },
                    { 4, "KidMenu" },
                    { 5, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Description", "Image" },
                values: new object[] { new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9"), "Skeppsgården's restaurant is a place where you can enjoy a delicious meal with a beautiful view of the lake. The restaurant is open for breakfast, lunch and dinner. We offer a variety of dishes, including vegetarian and vegan options. We also have a bar with a wide selection of drinks and cocktails.", "~/images/restaurant/restaurant.jpg" });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Double" },
                    { 3, "Family" }
                });

            migrationBuilder.InsertData(
                table: "UtilityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Balcony" },
                    { 2, "Porch" },
                    { 3, "Terrace" },
                    { 4, "Bathroom" },
                    { 5, "Kitchen" },
                    { 6, "CommonLivingRoom" }
                });

            migrationBuilder.InsertData(
                table: "ViewTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "LakeView" },
                    { 2, "GardenView" },
                    { 3, "MixedView" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "03f23900-4a30-49e1-aae0-d498b0f2a6b6", "6a0d484a-08ef-467c-ab1f-b6fb11239452" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Ingredients", "MenuItemTypeId", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("0d65328d-cd69-4891-8a02-7f0499f838a3"), "Broccoli, breadcrumbs, eggs", 1, "Broccoli Bites", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("29fd21df-e695-4d7c-9141-85d8980a0786"), "Mozzarella, breadcrumbs, eggs", 1, "Mozzarella Sticks", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("2d31aeb3-9bb3-4bd1-944e-e94d266d8ae3"), "Burger bun, beef patty, cheese, lettuce, tomatoes, onions", 2, "Burger", 12, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("34ca2a60-3374-4b6e-b5df-bc72a5ee401f"), "Pizza dough, tomato sauce, cheese, mushrooms", 3, "Vegetarian Pizza", 15, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("416f4e4c-2164-4e10-b1ba-2517e2d9b247"), "Burger bun, beef patty, cheese", 4, "Kid Burger", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("459bd294-337e-4971-b3e2-5ee3d695f421"), "Bananas, apples, oranges, kiwis, strawberries", 5, "Fruit salad", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("51f397f7-e0f6-4b58-9d52-f57374083832"), "Pizza dough, tomato sauce, cheese", 4, "Kid Pizza", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("547a6a05-0612-4c8c-a9fc-25a475309a0b"), "Chocolate cake, chocolate sauce, whipped cream", 5, "Chocolate cake", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("61bc953f-7287-4e34-97c4-50acec1c6cac"), "Potatoes, oil", 1, "Waffle fries", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("6abb637c-c833-4612-b711-1d02737574a0"), "Pizza dough, tomato sauce, cheese, ham, mushrooms", 2, "Pizza", 15, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("a099c942-4e83-45e2-93ad-520bff6de197"), "Pasta, tomato sauce, cheese", 2, "Pasta", 10, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("a1b57b59-4322-45c8-ae49-0dad4a7bac53"), "Pasta, tomato sauce, cheese", 4, "Kid Pasta", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("c7879264-b976-4997-82f4-201df8de64c1"), "Beef steak, potatoes, vegetables", 2, "Steak", 20, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("ceeb4283-761e-4af2-99f0-dc800a7a1d1f"), "Chicken breast, potatoes, vegetables", 2, "Chicken", 15, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("d0625867-b22a-4724-8467-af4c166479d7"), "Ice cream, chocolate sauce, whipped cream", 5, "Ice cream", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("d4919923-ff55-4d19-8c2a-9ded03398616"), "Cheesecake, chocolate sauce, whipped cream", 5, "Cheesecake", 5, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("e3246552-4cbf-4a71-a7ad-2a936441cfa7"), "Shrimp, breadcrumbs, eggs", 1, "Popcorn Shrimp", 10, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("f5708deb-a6ff-41e9-b516-6d8b157333ef"), "Burger bun, veggie patty, cheese, lettuce, tomatoes, onions", 3, "Vegetarian Burger", 12, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("f8926aa7-5155-49db-9329-a3ac3db81ac9"), "Pasta, tomato sauce, cheese", 3, "Vegetarian Pasta", 10, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") },
                    { new Guid("fa41c886-ffdf-4213-8f54-87d04080b01b"), "Lettuce, tomatoes, cucumbers, olives, feta cheese", 3, "Salad", 8, new Guid("023e64ca-0b90-4977-8fba-bfbfeaf794a9") }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedTypeId", "Capacity", "ExtraBedId", "Images", "IsAvailable", "IsRequested", "Rate", "RoomNumber", "RoomTypeId", "ViewTypeId" },
                values: new object[,]
                {
                    { new Guid("462311ac-09ec-4c65-be8d-a7ba24d9c304"), 2, 4, 3, "room4.1, room4.2, room4.3", true, false, 1300, 4, 3, 3 },
                    { new Guid("863e9ef3-7684-4afe-9e47-fa9834692ea3"), 2, 2, null, "room5.1, room5.2, room5.3", true, false, 1100, 5, 2, 2 },
                    { new Guid("8cae901b-6b04-4ada-8353-76f10e080009"), 2, 2, null, "room3.1, room3.2, room3.3", true, false, 1200, 3, 2, 3 },
                    { new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"), 2, 4, 4, "room1.1, room1.2, room1.3", true, false, 1200, 1, 3, 3 },
                    { new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"), 2, 2, null, "room2.1, room2.2, room2.3", true, false, 1200, 2, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomsFacilityTypes",
                columns: new[] { "FacilityTypeId", "RoomId" },
                values: new object[,]
                {
                    { 1, new Guid("8cae901b-6b04-4ada-8353-76f10e080009") },
                    { 2, new Guid("8cae901b-6b04-4ada-8353-76f10e080009") },
                    { 3, new Guid("8cae901b-6b04-4ada-8353-76f10e080009") },
                    { 4, new Guid("8cae901b-6b04-4ada-8353-76f10e080009") },
                    { 5, new Guid("8cae901b-6b04-4ada-8353-76f10e080009") },
                    { 1, new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc") },
                    { 2, new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc") },
                    { 3, new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc") },
                    { 4, new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc") },
                    { 5, new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc") },
                    { 2, new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918") },
                    { 3, new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918") },
                    { 4, new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918") },
                    { 5, new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918") },
                    { 6, new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918") }
                });

            migrationBuilder.InsertData(
                table: "RoomsUtilityTypes",
                columns: new[] { "RoomId", "UtilityTypeId" },
                values: new object[,]
                {
                    { new Guid("462311ac-09ec-4c65-be8d-a7ba24d9c304"), 4 },
                    { new Guid("462311ac-09ec-4c65-be8d-a7ba24d9c304"), 5 },
                    { new Guid("462311ac-09ec-4c65-be8d-a7ba24d9c304"), 6 },
                    { new Guid("863e9ef3-7684-4afe-9e47-fa9834692ea3"), 4 },
                    { new Guid("863e9ef3-7684-4afe-9e47-fa9834692ea3"), 6 },
                    { new Guid("8cae901b-6b04-4ada-8353-76f10e080009"), 4 },
                    { new Guid("8cae901b-6b04-4ada-8353-76f10e080009"), 6 },
                    { new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"), 4 },
                    { new Guid("9abfbe73-72ea-41f7-8c5b-ba90f49ac3cc"), 6 },
                    { new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"), 4 },
                    { new Guid("e8a3dd6d-b138-4cbe-81d4-fcb0df444918"), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlockedDates_RoomId",
                table: "BlockedDates",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalReservations_CustomerId",
                table: "HistoricalReservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalReservations_RoomId",
                table: "HistoricalReservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuItemTypeId",
                table: "MenuItems",
                column: "MenuItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RoomId",
                table: "Requests",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BedTypeId",
                table: "Rooms",
                column: "BedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ExtraBedId",
                table: "Rooms",
                column: "ExtraBedId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ViewTypeId",
                table: "Rooms",
                column: "ViewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsFacilityTypes_FacilityTypeId",
                table: "RoomsFacilityTypes",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsUtilityTypes_UtilityTypeId",
                table: "RoomsUtilityTypes",
                column: "UtilityTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlockedDates");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HistoricalReservations");

            migrationBuilder.DropTable(
                name: "Hyperlinks");

            migrationBuilder.DropTable(
                name: "LocalPlaces");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RoomsFacilityTypes");

            migrationBuilder.DropTable(
                name: "RoomsUtilityTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MenuItemsTypes");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FacilityTypes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "UtilityTypes");

            migrationBuilder.DropTable(
                name: "BedTypes");

            migrationBuilder.DropTable(
                name: "ExtraTypes");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "ViewTypes");
        }
    }
}
