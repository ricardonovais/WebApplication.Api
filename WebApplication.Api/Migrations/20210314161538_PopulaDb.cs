using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Api.Migrations
{
    public partial class PopulaDb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Clientes(Nome, Idade) VALUES('Cliente 01', 30)");
            mb.Sql("INSERT INTO Clientes(Nome, Idade) VALUES('Cliente 02', 31)");
            mb.Sql("INSERT INTO Clientes(Nome, Idade) VALUES('Cliente 03', 32)");
            mb.Sql("INSERT INTO Clientes(Nome, Idade) VALUES('Cliente 04', 33)");
            mb.Sql("INSERT INTO Clientes(Nome, Idade) VALUES('Cliente 05', 34)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Clientes");
        }
    }
}
