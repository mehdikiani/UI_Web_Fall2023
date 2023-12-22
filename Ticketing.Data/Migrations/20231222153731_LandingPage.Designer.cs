﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ticketing.Data;

#nullable disable

namespace Ticketing.Data.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    [Migration("20231222153731_LandingPage")]
    partial class LandingPage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ticketing.Core.Entities.LandingPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Section1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LandingPages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Section1 = "ایجاد تجربه‌های خدمات شخصی‌شده که طنین‌انداز می‌شوند - اپلیکیشن ما، صدای برند شما",
                            Section2 = "بازخورد مثبت مشتریان ما همچنان سرازیر می شود، و همه اینها به لطف اپلیکیشن باورنکردنی خدمات مشتری شماست. مدیریت سوالات را بسیار کارآمدتر کرده است"
                        },
                        new
                        {
                            Id = 2,
                            Section1 = "لبخند مشتری ماموریت ماست – ارائه برتری در هر تعامل آنلاین",
                            Section2 = "فقط می‌خواستم پاسخ فوق‌العاده‌ای را که از زمان اجرای اپلیکیشن شما از مشتریانمان داشته‌ایم به اشتراک بگذارم. آنها از پشتیبانی سریع و شخصی که دریافت می‌کنند قدردانی می‌کنند و این قطعاً تصویر برند ما را تقویت می‌کند. بسیار قدردانی می شود"
                        },
                        new
                        {
                            Id = 3,
                            Section1 = "ارتباط بی‌دردسر، خدمات بی‌نظیر – اپلیکیشن ما پشتیبانی مشتری را دوباره تعریف می‌کند",
                            Section2 = "مشتریان ما از زمانی که اپلیکیشن شما را ادغام کردیم، خدمات استثنایی را که دریافت کرده‌اند ستایش می‌کنند. تاثیر قابل توجهی در رابطه ما با آنها گذاشته است. ما بیش از حد راضی هستیم"
                        },
                        new
                        {
                            Id = 4,
                            Section1 = "استانداردهای خدمات برند خود را با پلتفرم پشتیبانی مشتری پیشرفته ما ارتقا دهید",
                            Section2 = "من فقط باید تماس می گرفتم و به شما اطلاع می دادم که چقدر از اپلیکیشن خدمات مشتری شما قدردانی می کنیم. این نه تنها فرآیندهای ما را ساده کرده است، بلکه سطح رضایت مشتری ما را نیز افزایش داده است. با تشکر از شما برای این ابزار ارزشمند"
                        },
                        new
                        {
                            Id = 5,
                            Section1 = "با اپلیکیشن بصری و مشتری محور ما در آینده خدمات مشتری پیمایش کنید",
                            Section2 = "من سال‌ها در این صنعت بوده‌ام، و اپلیکیشن شما بهترین ابزار خدمات مشتری است که من با آن برخورد کرده‌ام. رابط کاربری بصری است و ویژگی ها دقیقاً همان چیزی است که ما به آن نیاز داشتیم. آفرین"
                        },
                        new
                        {
                            Id = 6,
                            Section1 = "تبدیل پشتیبانی مشتری به تجربه های فراموش نشدنی، یک تعامل در یک زمان",
                            Section2 = "می‌خواستم لحظه‌ای وقت بگذارم و از اپلیکیشن شگفت‌انگیز خدمات مشتری شما تشکر کنم. این اپلیکیشن فوق العاده است"
                        },
                        new
                        {
                            Id = 7,
                            Section1 = "توانمند سازی عملیات خدمات مشتری خود با تعاملات یکپارچه و راه حل های کارآمد - جایی که نوآوری با رضایت روبرو می شود",
                            Section2 = "اپلیکیشن خدمات مشتری شما یک سرویس بسیار کاراست! همچنین بسیار کاربر پسند و کارآمد است"
                        });
                });

            modelBuilder.Entity("Ticketing.Core.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("Ticketing.Core.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Ticketing.Core.Entities.Ticket", b =>
                {
                    b.HasOne("Ticketing.Core.Entities.Section", "Section")
                        .WithMany("Tickets")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Ticketing.Core.Entities.Section", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}