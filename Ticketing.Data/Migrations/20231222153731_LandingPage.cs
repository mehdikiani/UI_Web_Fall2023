using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticketing.Data.Migrations
{
    /// <inheritdoc />
    public partial class LandingPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandingPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LandingPages",
                columns: new[] { "Id", "Section1", "Section2" },
                values: new object[,]
                {
                    { 1, "ایجاد تجربه‌های خدمات شخصی‌شده که طنین‌انداز می‌شوند - اپلیکیشن ما، صدای برند شما", "بازخورد مثبت مشتریان ما همچنان سرازیر می شود، و همه اینها به لطف اپلیکیشن باورنکردنی خدمات مشتری شماست. مدیریت سوالات را بسیار کارآمدتر کرده است" },
                    { 2, "لبخند مشتری ماموریت ماست – ارائه برتری در هر تعامل آنلاین", "فقط می‌خواستم پاسخ فوق‌العاده‌ای را که از زمان اجرای اپلیکیشن شما از مشتریانمان داشته‌ایم به اشتراک بگذارم. آنها از پشتیبانی سریع و شخصی که دریافت می‌کنند قدردانی می‌کنند و این قطعاً تصویر برند ما را تقویت می‌کند. بسیار قدردانی می شود" },
                    { 3, "ارتباط بی‌دردسر، خدمات بی‌نظیر – اپلیکیشن ما پشتیبانی مشتری را دوباره تعریف می‌کند", "مشتریان ما از زمانی که اپلیکیشن شما را ادغام کردیم، خدمات استثنایی را که دریافت کرده‌اند ستایش می‌کنند. تاثیر قابل توجهی در رابطه ما با آنها گذاشته است. ما بیش از حد راضی هستیم" },
                    { 4, "استانداردهای خدمات برند خود را با پلتفرم پشتیبانی مشتری پیشرفته ما ارتقا دهید", "من فقط باید تماس می گرفتم و به شما اطلاع می دادم که چقدر از اپلیکیشن خدمات مشتری شما قدردانی می کنیم. این نه تنها فرآیندهای ما را ساده کرده است، بلکه سطح رضایت مشتری ما را نیز افزایش داده است. با تشکر از شما برای این ابزار ارزشمند" },
                    { 5, "با اپلیکیشن بصری و مشتری محور ما در آینده خدمات مشتری پیمایش کنید", "من سال‌ها در این صنعت بوده‌ام، و اپلیکیشن شما بهترین ابزار خدمات مشتری است که من با آن برخورد کرده‌ام. رابط کاربری بصری است و ویژگی ها دقیقاً همان چیزی است که ما به آن نیاز داشتیم. آفرین" },
                    { 6, "تبدیل پشتیبانی مشتری به تجربه های فراموش نشدنی، یک تعامل در یک زمان", "می‌خواستم لحظه‌ای وقت بگذارم و از اپلیکیشن شگفت‌انگیز خدمات مشتری شما تشکر کنم. این اپلیکیشن فوق العاده است" },
                    { 7, "توانمند سازی عملیات خدمات مشتری خود با تعاملات یکپارچه و راه حل های کارآمد - جایی که نوآوری با رضایت روبرو می شود", "اپلیکیشن خدمات مشتری شما یک سرویس بسیار کاراست! همچنین بسیار کاربر پسند و کارآمد است" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandingPages");
        }
    }
}
