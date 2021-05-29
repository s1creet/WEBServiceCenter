using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceCenter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Должности",
                columns: table => new
                {
                    Код_должности = table.Column<int>(type: "INT", nullable: false),
                    Наименование_должности = table.Column<int>(type: "INT", nullable: false),
                    Оклад = table.Column<int>(type: "INT", nullable: false),
                    Обязанности = table.Column<int>(type: "INT", nullable: false),
                    Требования = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Должности", x => x.Код_должности);
                });

            migrationBuilder.CreateTable(
                name: "Запчасти",
                columns: table => new
                {
                    Код_запчасти = table.Column<int>(type: "INT", nullable: false),
                    Наименования = table.Column<int>(type: "INT", nullable: false),
                    Функции = table.Column<int>(type: "INT", nullable: false),
                    Цена = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Запчасти", x => x.Код_запчасти);
                });

            migrationBuilder.CreateTable(
                name: "Обслуживаемые_магазины",
                columns: table => new
                {
                    Код_магазина = table.Column<int>(type: "INT", nullable: false),
                    Наименование = table.Column<int>(type: "INT", nullable: false),
                    Адрес = table.Column<int>(type: "INT", nullable: false),
                    Телефон = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Обслуживаемые_магазины", x => x.Код_магазина);
                });

            migrationBuilder.CreateTable(
                name: "Ремонтируемые_модели",
                columns: table => new
                {
                    Код_модели = table.Column<int>(type: "INT", nullable: false),
                    Наименование = table.Column<int>(type: "INT", nullable: false),
                    Тип = table.Column<int>(type: "INT", nullable: false),
                    Производитель = table.Column<int>(type: "INT", nullable: false),
                    Технические_харантеристики = table.Column<int>(type: "INT", nullable: false),
                    Особенности = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ремонтируемые_модели", x => x.Код_модели);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники",
                columns: table => new
                {
                    Код_сотрудника = table.Column<int>(type: "INT", nullable: false),
                    Паспортные_данные = table.Column<int>(type: "INT", nullable: false),
                    Телефон = table.Column<int>(type: "INT", nullable: false),
                    Адрес = table.Column<int>(type: "INT", nullable: false),
                    Пол = table.Column<int>(type: "INT", nullable: false),
                    Код_должности = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.Код_сотрудника);
                    table.ForeignKey(
                        name: "FK_Сотрудники_Должности_Код_должности",
                        column: x => x.Код_должности,
                        principalTable: "Должности",
                        principalColumn: "Код_должности",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Виды_неисправностей",
                columns: table => new
                {
                    Код_вида = table.Column<int>(type: "INT", nullable: false),
                    Описание = table.Column<int>(type: "INT", nullable: false),
                    Симптомы = table.Column<int>(type: "INT", nullable: false),
                    Методы_ремонта = table.Column<int>(type: "INT", nullable: false),
                    Цена_работы = table.Column<int>(type: "INT", nullable: false),
                    Код_запчасти = table.Column<int>(type: "INT", nullable: false),
                    Код_модели = table.Column<int>(type: "INT", nullable: false),
                    Запчасть_2Код_запчасти = table.Column<int>(type: "INT", nullable: false),
                    Запчасть_3Код_запчасти = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Виды_неисправностей", x => x.Код_вида);
                    table.ForeignKey(
                        name: "FK_Виды_неисправностей_Запчасти_Запчасть_2Код_запчасти",
                        column: x => x.Запчасть_2Код_запчасти,
                        principalTable: "Запчасти",
                        principalColumn: "Код_запчасти",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Виды_неисправностей_Запчасти_Запчасть_3Код_запчасти",
                        column: x => x.Запчасть_3Код_запчасти,
                        principalTable: "Запчасти",
                        principalColumn: "Код_запчасти",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Виды_неисправностей_Запчасти_Код_запчасти",
                        column: x => x.Код_запчасти,
                        principalTable: "Запчасти",
                        principalColumn: "Код_запчасти",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Виды_неисправностей_Ремонтируемые_модели_Код_модели",
                        column: x => x.Код_модели,
                        principalTable: "Ремонтируемые_модели",
                        principalColumn: "Код_модели",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Заказы",
                columns: table => new
                {
                    Заказы_ID = table.Column<int>(type: "INT", nullable: false),
                    Дата_заказа = table.Column<int>(type: "INT", nullable: false),
                    Дата_возврата = table.Column<int>(type: "INT", nullable: false),
                    ФИО_заказчика = table.Column<int>(type: "INT", nullable: false),
                    Серийные_номер = table.Column<int>(type: "INT", nullable: false),
                    Код_вида_неисправности = table.Column<int>(type: "INT", nullable: false),
                    Отметка_о_гарантии = table.Column<int>(type: "INT", nullable: false),
                    Скор_гарантии_ремонта = table.Column<int>(type: "INT", nullable: false),
                    Цена = table.Column<int>(type: "INT", nullable: false),
                    Код_сотрудника = table.Column<int>(type: "INT", nullable: false),
                    Код_магазина = table.Column<int>(type: "INT", nullable: false),
                    Код_вида = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Заказы", x => x.Заказы_ID);
                    table.ForeignKey(
                        name: "FK_Заказы_Виды_неисправностей_Код_вида",
                        column: x => x.Код_вида,
                        principalTable: "Виды_неисправностей",
                        principalColumn: "Код_вида",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Заказы_Обслуживаемые_магазины_Код_магазина",
                        column: x => x.Код_магазина,
                        principalTable: "Обслуживаемые_магазины",
                        principalColumn: "Код_магазина",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Заказы_Сотрудники_Код_сотрудника",
                        column: x => x.Код_сотрудника,
                        principalTable: "Сотрудники",
                        principalColumn: "Код_сотрудника",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Виды_неисправностей_Запчасть_2Код_запчасти",
                table: "Виды_неисправностей",
                column: "Запчасть_2Код_запчасти");

            migrationBuilder.CreateIndex(
                name: "IX_Виды_неисправностей_Запчасть_3Код_запчасти",
                table: "Виды_неисправностей",
                column: "Запчасть_3Код_запчасти");

            migrationBuilder.CreateIndex(
                name: "IX_Виды_неисправностей_Код_запчасти",
                table: "Виды_неисправностей",
                column: "Код_запчасти");

            migrationBuilder.CreateIndex(
                name: "IX_Виды_неисправностей_Код_модели",
                table: "Виды_неисправностей",
                column: "Код_модели");

            migrationBuilder.CreateIndex(
                name: "IX_Заказы_Код_вида",
                table: "Заказы",
                column: "Код_вида");

            migrationBuilder.CreateIndex(
                name: "IX_Заказы_Код_магазина",
                table: "Заказы",
                column: "Код_магазина");

            migrationBuilder.CreateIndex(
                name: "IX_Заказы_Код_сотрудника",
                table: "Заказы",
                column: "Код_сотрудника");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_Код_должности",
                table: "Сотрудники",
                column: "Код_должности");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Заказы");

            migrationBuilder.DropTable(
                name: "Виды_неисправностей");

            migrationBuilder.DropTable(
                name: "Обслуживаемые_магазины");

            migrationBuilder.DropTable(
                name: "Сотрудники");

            migrationBuilder.DropTable(
                name: "Запчасти");

            migrationBuilder.DropTable(
                name: "Ремонтируемые_модели");

            migrationBuilder.DropTable(
                name: "Должности");
        }
    }
}
