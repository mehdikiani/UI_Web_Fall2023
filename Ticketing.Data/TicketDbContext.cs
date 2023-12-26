using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Data.EntityConfigurations;

namespace Ticketing.Data
{
    public class TicketDbContext : DbContext
    {
        //public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<Section> Sections { get; set; }
        public DbSet<LandingPage> LandingPages { get; set; }
        public TicketDbContext(
            DbContextOptions<TicketDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var ticketConfig = modelBuilder.Entity<Ticket>()
            //       .HasKey(t => t.Id)
            //       .HasName("Tickets");
            modelBuilder.ApplyConfiguration(new TicketConfig());
            modelBuilder.ApplyConfiguration(new SectionConfig());
            modelBuilder.Entity<LandingPage>()
                        .HasData(
                            new LandingPage
                            {
                                Id = 1,
                                Section1 = "ایجاد تجربه‌های خدمات شخصی‌شده که طنین‌انداز می‌شوند - اپلیکیشن ما، صدای برند شما",
                                Section2 = "بازخورد مثبت مشتریان ما همچنان سرازیر می شود، و همه اینها به لطف اپلیکیشن باورنکردنی خدمات مشتری شماست. مدیریت سوالات را بسیار کارآمدتر کرده است",
                            },
                            new LandingPage
                            {
                                Id = 2,
                                Section1 = "لبخند مشتری ماموریت ماست – ارائه برتری در هر تعامل آنلاین",
                                Section2 = "فقط می‌خواستم پاسخ فوق‌العاده‌ای را که از زمان اجرای اپلیکیشن شما از مشتریانمان داشته‌ایم به اشتراک بگذارم. آنها از پشتیبانی سریع و شخصی که دریافت می‌کنند قدردانی می‌کنند و این قطعاً تصویر برند ما را تقویت می‌کند. بسیار قدردانی می شود"
                            },
                            new LandingPage
                            {
                                Id = 3,
                                Section1 = "ارتباط بی‌دردسر، خدمات بی‌نظیر – اپلیکیشن ما پشتیبانی مشتری را دوباره تعریف می‌کند",
                                Section2 = "مشتریان ما از زمانی که اپلیکیشن شما را ادغام کردیم، خدمات استثنایی را که دریافت کرده‌اند ستایش می‌کنند. تاثیر قابل توجهی در رابطه ما با آنها گذاشته است. ما بیش از حد راضی هستیم"
                            },
                            new LandingPage
                            {
                                Id = 4,
                                Section1 = "استانداردهای خدمات برند خود را با پلتفرم پشتیبانی مشتری پیشرفته ما ارتقا دهید",
                                Section2 = "من فقط باید تماس می گرفتم و به شما اطلاع می دادم که چقدر از اپلیکیشن خدمات مشتری شما قدردانی می کنیم. این نه تنها فرآیندهای ما را ساده کرده است، بلکه سطح رضایت مشتری ما را نیز افزایش داده است. با تشکر از شما برای این ابزار ارزشمند"
                            },
                            new LandingPage
                            {
                                Id = 5,
                                Section1 = "با اپلیکیشن بصری و مشتری محور ما در آینده خدمات مشتری پیمایش کنید",
                                Section2 = "من سال‌ها در این صنعت بوده‌ام، و اپلیکیشن شما بهترین ابزار خدمات مشتری است که من با آن برخورد کرده‌ام. رابط کاربری بصری است و ویژگی ها دقیقاً همان چیزی است که ما به آن نیاز داشتیم. آفرین"
                            },
                            new LandingPage
                            {
                                Id = 6,
                                Section1 = "تبدیل پشتیبانی مشتری به تجربه های فراموش نشدنی، یک تعامل در یک زمان",
                                Section2 = "می‌خواستم لحظه‌ای وقت بگذارم و از اپلیکیشن شگفت‌انگیز خدمات مشتری شما تشکر کنم. این اپلیکیشن فوق العاده است"
                            },
                            new LandingPage
                            {
                                Id = 7,
                                Section1 = "توانمند سازی عملیات خدمات مشتری خود با تعاملات یکپارچه و راه حل های کارآمد - جایی که نوآوری با رضایت روبرو می شود",
                                Section2 = "اپلیکیشن خدمات مشتری شما یک سرویس بسیار کاراست! همچنین بسیار کاربر پسند و کارآمد است"
                            }
                        );
        }

    }
}
