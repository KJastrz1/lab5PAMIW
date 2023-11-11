using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P05Shop.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "TotalPrice" },
                values: new object[,]
                {
                    { 16, new DateTime(2016, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), 18.3m },
                    { 17, new DateTime(2014, 11, 28, 0, 0, 0, 0, DateTimeKind.Local), 38.01m },
                    { 18, new DateTime(2014, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), 36.02m },
                    { 19, new DateTime(2017, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), 83.24m },
                    { 20, new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), 45.66m },
                    { 21, new DateTime(2018, 9, 17, 0, 0, 0, 0, DateTimeKind.Local), 62.33m },
                    { 22, new DateTime(2015, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), 83.16m },
                    { 23, new DateTime(2017, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), 74.16m },
                    { 24, new DateTime(2019, 4, 24, 0, 0, 0, 0, DateTimeKind.Local), 90.99m },
                    { 25, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), 23.82m },
                    { 26, new DateTime(2014, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 47.76m },
                    { 27, new DateTime(2017, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), 46.25m },
                    { 28, new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), 40.39m },
                    { 29, new DateTime(2014, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 24.51m },
                    { 30, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), 52.61m },
                    { 31, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), 41.06m },
                    { 32, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Local), 91.08m },
                    { 33, new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Local), 32.77m },
                    { 34, new DateTime(2020, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), 52.62m },
                    { 35, new DateTime(2014, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), 71.72m },
                    { 36, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), 23.99m },
                    { 37, new DateTime(2015, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), 79.21m },
                    { 38, new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Local), 32.33m },
                    { 39, new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), 58.09m },
                    { 40, new DateTime(2014, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 25.09m },
                    { 41, new DateTime(2017, 2, 15, 0, 0, 0, 0, DateTimeKind.Local), 84.05m },
                    { 42, new DateTime(2014, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), 67.52m },
                    { 43, new DateTime(2013, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), 90.16m },
                    { 44, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Local), 48.66m },
                    { 45, new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), 60.5m },
                    { 46, new DateTime(2017, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 25.16m },
                    { 47, new DateTime(2019, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), 46.95m },
                    { 48, new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), 36.2m },
                    { 49, new DateTime(2014, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), 66.32m },
                    { 50, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), 41.25m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 712.021981759007m, new DateTime(2023, 3, 19, 18, 6, 46, 341, DateTimeKind.Local).AddTicks(8622), "Gorgeous Wooden Chair" },
                    { 2, "7", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 839.010165513032m, new DateTime(2023, 9, 29, 14, 45, 19, 978, DateTimeKind.Local).AddTicks(1118), "Handcrafted Steel Shoes" },
                    { 3, "1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 198.083692779804m, new DateTime(2023, 1, 18, 9, 39, 3, 251, DateTimeKind.Local).AddTicks(3138), "Handmade Granite Table" },
                    { 4, "1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 160.643399712929m, new DateTime(2023, 8, 19, 21, 52, 33, 610, DateTimeKind.Local).AddTicks(4521), "Handmade Wooden Table" },
                    { 5, "0", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 359.887736376788m, new DateTime(2023, 2, 19, 23, 10, 45, 340, DateTimeKind.Local).AddTicks(702), "Intelligent Steel Salad" },
                    { 6, "8", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 181.360829243139m, new DateTime(2023, 9, 3, 10, 58, 18, 449, DateTimeKind.Local).AddTicks(7986), "Handcrafted Rubber Bike" },
                    { 7, "1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 938.297015022625m, new DateTime(2023, 4, 4, 10, 10, 30, 859, DateTimeKind.Local).AddTicks(8036), "Unbranded Steel Car" },
                    { 8, "3", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 223.882037785315m, new DateTime(2023, 6, 28, 1, 24, 58, 548, DateTimeKind.Local).AddTicks(261), "Tasty Plastic Cheese" },
                    { 9, "0", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 249.172251003875m, new DateTime(2022, 12, 17, 17, 24, 14, 4, DateTimeKind.Local).AddTicks(7787), "Handcrafted Fresh Sausages" },
                    { 10, "1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 905.322284099796m, new DateTime(2023, 10, 9, 9, 6, 23, 466, DateTimeKind.Local).AddTicks(445), "Fantastic Frozen Gloves" },
                    { 11, "3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 842.480734222792m, new DateTime(2023, 8, 8, 2, 20, 27, 607, DateTimeKind.Local).AddTicks(7609), "Generic Steel Ball" },
                    { 12, "1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 928.928430071533m, new DateTime(2023, 8, 16, 6, 52, 24, 381, DateTimeKind.Local).AddTicks(6317), "Ergonomic Rubber Car" },
                    { 13, "6", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 706.948686653259m, new DateTime(2023, 7, 16, 12, 5, 53, 301, DateTimeKind.Local).AddTicks(2296), "Generic Steel Pizza" },
                    { 14, "3", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 306.262494314584m, new DateTime(2023, 1, 10, 1, 18, 31, 788, DateTimeKind.Local).AddTicks(8607), "Small Metal Sausages" },
                    { 15, "2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 378.222576259273m, new DateTime(2023, 7, 31, 18, 24, 24, 818, DateTimeKind.Local).AddTicks(5857), "Fantastic Soft Pants" },
                    { 16, "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 461.718092748764m, new DateTime(2022, 11, 18, 10, 19, 13, 285, DateTimeKind.Local).AddTicks(4718), "Gorgeous Frozen Towels" },
                    { 17, "7", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 126.128098112125m, new DateTime(2023, 6, 28, 0, 40, 44, 863, DateTimeKind.Local).AddTicks(4206), "Tasty Steel Cheese" },
                    { 18, "8", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 530.970371435383m, new DateTime(2023, 6, 25, 2, 23, 26, 222, DateTimeKind.Local).AddTicks(7261), "Gorgeous Granite Cheese" },
                    { 19, "9", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 913.003066283186m, new DateTime(2022, 11, 18, 13, 41, 25, 802, DateTimeKind.Local).AddTicks(610), "Sleek Rubber Chicken" },
                    { 20, "5", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 940.814879371698m, new DateTime(2023, 4, 11, 15, 12, 10, 284, DateTimeKind.Local).AddTicks(3856), "Intelligent Wooden Salad" },
                    { 21, "4", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 479.41424090062m, new DateTime(2023, 6, 20, 2, 35, 4, 472, DateTimeKind.Local).AddTicks(6236), "Handcrafted Wooden Sausages" },
                    { 22, "7", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 320.499838554068m, new DateTime(2023, 1, 30, 22, 2, 26, 742, DateTimeKind.Local).AddTicks(4061), "Sleek Granite Car" },
                    { 23, "6", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 478.915239043029m, new DateTime(2023, 6, 1, 15, 52, 34, 60, DateTimeKind.Local).AddTicks(7630), "Small Wooden Car" },
                    { 24, "2", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 910.785444308438m, new DateTime(2023, 7, 3, 8, 28, 53, 290, DateTimeKind.Local).AddTicks(803), "Sleek Steel Shirt" },
                    { 25, "3", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 802.238750720974m, new DateTime(2023, 7, 19, 9, 57, 44, 853, DateTimeKind.Local).AddTicks(7254), "Incredible Frozen Mouse" },
                    { 26, "7", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 150.818741621831m, new DateTime(2023, 5, 14, 3, 34, 4, 977, DateTimeKind.Local).AddTicks(2524), "Incredible Wooden Chair" },
                    { 27, "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 721.773541800572m, new DateTime(2023, 2, 2, 15, 37, 40, 973, DateTimeKind.Local).AddTicks(4099), "Gorgeous Plastic Chips" },
                    { 28, "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 688.245783060904m, new DateTime(2023, 4, 27, 18, 3, 36, 84, DateTimeKind.Local).AddTicks(9324), "Incredible Fresh Bacon" },
                    { 29, "7", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 553.558320945389m, new DateTime(2023, 7, 21, 4, 34, 30, 78, DateTimeKind.Local).AddTicks(694), "Incredible Soft Computer" },
                    { 30, "4", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 663.536718269594m, new DateTime(2022, 11, 15, 5, 29, 53, 294, DateTimeKind.Local).AddTicks(2486), "Handcrafted Rubber Bike" },
                    { 31, "2", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 922.479030014704m, new DateTime(2023, 10, 11, 3, 55, 42, 491, DateTimeKind.Local).AddTicks(645), "Handcrafted Concrete Tuna" },
                    { 32, "3", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 255.49067058018m, new DateTime(2023, 7, 21, 23, 43, 8, 430, DateTimeKind.Local).AddTicks(1080), "Gorgeous Wooden Fish" },
                    { 33, "7", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 955.272407213818m, new DateTime(2023, 4, 29, 0, 12, 9, 680, DateTimeKind.Local).AddTicks(6967), "Handcrafted Frozen Keyboard" },
                    { 34, "8", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 151.982358236323m, new DateTime(2022, 11, 25, 17, 27, 57, 519, DateTimeKind.Local).AddTicks(4566), "Intelligent Plastic Chair" },
                    { 35, "9", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 434.299358334532m, new DateTime(2022, 12, 13, 22, 20, 15, 514, DateTimeKind.Local).AddTicks(4299), "Unbranded Wooden Pizza" },
                    { 36, "4", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 57.7988712865854m, new DateTime(2023, 1, 2, 16, 54, 13, 47, DateTimeKind.Local).AddTicks(6103), "Gorgeous Rubber Bacon" },
                    { 37, "7", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 883.980300599234m, new DateTime(2023, 3, 31, 8, 27, 26, 443, DateTimeKind.Local).AddTicks(4269), "Handcrafted Rubber Shirt" },
                    { 38, "7", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 822.452619476455m, new DateTime(2023, 1, 10, 6, 29, 6, 762, DateTimeKind.Local).AddTicks(5648), "Rustic Granite Shoes" },
                    { 39, "7", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 22.2432652671092m, new DateTime(2023, 4, 6, 14, 7, 21, 322, DateTimeKind.Local).AddTicks(801), "Sleek Granite Chair" },
                    { 40, "2", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 158.364214679396m, new DateTime(2023, 6, 24, 10, 53, 37, 945, DateTimeKind.Local).AddTicks(8572), "Incredible Rubber Soap" },
                    { 41, "7", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 533.504530191656m, new DateTime(2023, 8, 6, 17, 59, 0, 94, DateTimeKind.Local).AddTicks(625), "Awesome Soft Fish" },
                    { 42, "8", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 265.709933652407m, new DateTime(2023, 7, 29, 5, 9, 59, 523, DateTimeKind.Local).AddTicks(5990), "Intelligent Cotton Tuna" },
                    { 43, "2", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 294.402654204239m, new DateTime(2023, 1, 20, 20, 56, 13, 79, DateTimeKind.Local).AddTicks(4976), "Refined Soft Bike" },
                    { 44, "5", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 741.648888164036m, new DateTime(2023, 1, 24, 18, 36, 38, 238, DateTimeKind.Local).AddTicks(2611), "Handmade Cotton Bacon" },
                    { 45, "5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 825.239833488706m, new DateTime(2023, 1, 2, 14, 43, 1, 308, DateTimeKind.Local).AddTicks(4135), "Small Soft Tuna" },
                    { 46, "1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 305.894089151124m, new DateTime(2023, 5, 7, 19, 25, 12, 867, DateTimeKind.Local).AddTicks(7651), "Practical Frozen Computer" },
                    { 47, "4", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 778.911179241683m, new DateTime(2023, 1, 10, 14, 24, 47, 170, DateTimeKind.Local).AddTicks(798), "Rustic Wooden Mouse" },
                    { 48, "2", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 318.709401070936m, new DateTime(2023, 2, 22, 11, 17, 4, 596, DateTimeKind.Local).AddTicks(441), "Handcrafted Metal Mouse" },
                    { 49, "6", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 463.195345650052m, new DateTime(2023, 4, 7, 15, 59, 8, 197, DateTimeKind.Local).AddTicks(9705), "Handcrafted Rubber Salad" },
                    { 50, "6", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 717.609017980569m, new DateTime(2023, 8, 25, 5, 8, 7, 377, DateTimeKind.Local).AddTicks(8395), "Incredible Plastic Shoes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
