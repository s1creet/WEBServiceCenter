using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServiceCenter.Models;

#nullable disable

namespace ServiceCenter.Data
{
    public partial class ServiceCenterContext : DbContext
    {
        public ServiceCenterContext()
        {
        }

        public ServiceCenterContext(DbContextOptions<ServiceCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ВидыНеисправностей> ВидыНеисправностейs { get; set; }
        public virtual DbSet<Должности> Должностиs { get; set; }
        public virtual DbSet<Заказы> Заказыs { get; set; }
        public virtual DbSet<Запчасти> Запчастиs { get; set; }
        public virtual DbSet<ОбслуживаемыеМагазины> ОбслуживаемыеМагазиныs { get; set; }
        public virtual DbSet<РемонтируемыеМодели> РемонтируемыеМоделиs { get; set; }
        public virtual DbSet<Сотрудники> Сотрудникиs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ServiceCenter.db; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ВидыНеисправностей>(entity =>
            {
                entity.HasKey(e => e.КодВида);

                entity.ToTable("Виды_неисправностей");

                entity.Property(e => e.КодВида)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_вида");

                entity.Property(e => e.Запчасть2кодЗапчасти)
                    .HasColumnType("INT")
                    .HasColumnName("Запчасть_2Код_запчасти");

                entity.Property(e => e.Запчасть3кодЗапчасти)
                    .HasColumnType("INT")
                    .HasColumnName("Запчасть_3Код_запчасти");

                entity.Property(e => e.КодЗапчасти)
                    .HasColumnType("INT")
                    .HasColumnName("Код_запчасти");

                entity.Property(e => e.КодМодели)
                    .HasColumnType("INT")
                    .HasColumnName("Код_модели");

                entity.Property(e => e.МетодыРемонта)
                    .HasColumnType("INT")
                    .HasColumnName("Методы_ремонта");

                entity.Property(e => e.Описание).HasColumnType("INT");

                entity.Property(e => e.Симптомы).HasColumnType("INT");

                entity.Property(e => e.ЦенаРаботы)
                    .HasColumnType("INT")
                    .HasColumnName("Цена_работы");

                entity.HasOne(d => d.Запчасть2кодЗапчастиNavigation)
                    .WithMany(p => p.ВидыНеисправностейЗапчасть2кодЗапчастиNavigations)
                    .HasForeignKey(d => d.Запчасть2кодЗапчасти)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Запчасть3кодЗапчастиNavigation)
                    .WithMany(p => p.ВидыНеисправностейЗапчасть3кодЗапчастиNavigations)
                    .HasForeignKey(d => d.Запчасть3кодЗапчасти)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодЗапчастиNavigation)
                    .WithMany(p => p.ВидыНеисправностейКодЗапчастиNavigations)
                    .HasForeignKey(d => d.КодЗапчасти)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодМоделиNavigation)
                    .WithMany(p => p.ВидыНеисправностейs)
                    .HasForeignKey(d => d.КодМодели)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.КодДолжности);

                entity.ToTable("Должности");

                entity.Property(e => e.КодДолжности)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_должности");

                entity.Property(e => e.НаименованиеДолжности)
                    .HasColumnType("INT")
                    .HasColumnName("Наименование_должности");

                entity.Property(e => e.Обязанности).HasColumnType("INT");

                entity.Property(e => e.Оклад).HasColumnType("INT");

                entity.Property(e => e.Требования).HasColumnType("INT");
            });

            modelBuilder.Entity<Заказы>(entity =>
            {
                entity.ToTable("Заказы");

                entity.Property(e => e.ЗаказыId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Заказы_ID");

                entity.Property(e => e.ДатаВозврата)
                    .HasColumnType("INT")
                    .HasColumnName("Дата_возврата");

                entity.Property(e => e.ДатаЗаказа)
                    .HasColumnType("INT")
                    .HasColumnName("Дата_заказа");

                entity.Property(e => e.КодВида)
                    .HasColumnType("INT")
                    .HasColumnName("Код_вида");

                entity.Property(e => e.КодВидаНеисправности)
                    .HasColumnType("INT")
                    .HasColumnName("Код_вида_неисправности");

                entity.Property(e => e.КодМагазина)
                    .HasColumnType("INT")
                    .HasColumnName("Код_магазина");

                entity.Property(e => e.КодСотрудника)
                    .HasColumnType("INT")
                    .HasColumnName("Код_сотрудника");

                entity.Property(e => e.ОтметкаОГарантии)
                    .HasColumnType("INT")
                    .HasColumnName("Отметка_о_гарантии");

                entity.Property(e => e.СерийныеНомер)
                    .HasColumnType("INT")
                    .HasColumnName("Серийные_номер");

                entity.Property(e => e.СкорГарантииРемонта)
                    .HasColumnType("INT")
                    .HasColumnName("Скор_гарантии_ремонта");

                entity.Property(e => e.ФиоЗаказчика)
                    .HasColumnType("INT")
                    .HasColumnName("ФИО_заказчика");

                entity.Property(e => e.Цена).HasColumnType("INT");

                entity.HasOne(d => d.КодВидаNavigation)
                    .WithMany(p => p.Заказыs)
                    .HasForeignKey(d => d.КодВида)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодМагазинаNavigation)
                    .WithMany(p => p.Заказыs)
                    .HasForeignKey(d => d.КодМагазина)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany(p => p.Заказыs)
                    .HasForeignKey(d => d.КодСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Запчасти>(entity =>
            {
                entity.HasKey(e => e.КодЗапчасти);

                entity.ToTable("Запчасти");

                entity.Property(e => e.КодЗапчасти)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_запчасти");

                entity.Property(e => e.Наименования).HasColumnType("INT");

                entity.Property(e => e.Функции).HasColumnType("INT");

                entity.Property(e => e.Цена).HasColumnType("INT");
            });

            modelBuilder.Entity<ОбслуживаемыеМагазины>(entity =>
            {
                entity.HasKey(e => e.КодМагазина);

                entity.ToTable("Обслуживаемые_магазины");

                entity.Property(e => e.КодМагазина)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_магазина");

                entity.Property(e => e.Адрес).HasColumnType("INT");

                entity.Property(e => e.Наименование).HasColumnType("INT");

                entity.Property(e => e.Телефон).HasColumnType("INT");
            });

            modelBuilder.Entity<РемонтируемыеМодели>(entity =>
            {
                entity.HasKey(e => e.КодМодели);

                entity.ToTable("Ремонтируемые_модели");

                entity.Property(e => e.КодМодели)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_модели");

                entity.Property(e => e.Наименование).HasColumnType("INT");

                entity.Property(e => e.Особенности).HasColumnType("INT");

                entity.Property(e => e.Производитель).HasColumnType("INT");

                entity.Property(e => e.ТехническиеХарантеристики)
                    .HasColumnType("INT")
                    .HasColumnName("Технические_харантеристики");

                entity.Property(e => e.Тип).HasColumnType("INT");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.КодСотрудника);

                entity.ToTable("Сотрудники");

                entity.Property(e => e.КодСотрудника)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Код_сотрудника");

                entity.Property(e => e.Адрес).HasColumnType("INT");

                entity.Property(e => e.КодДолжности)
                    .HasColumnType("INT")
                    .HasColumnName("Код_должности");

                entity.Property(e => e.ПаспортныеДанные)
                    .HasColumnType("INT")
                    .HasColumnName("Паспортные_данные");

                entity.Property(e => e.Пол).HasColumnType("INT");

                entity.Property(e => e.Телефон).HasColumnType("INT");

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудникиs)
                    .HasForeignKey(d => d.КодДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
