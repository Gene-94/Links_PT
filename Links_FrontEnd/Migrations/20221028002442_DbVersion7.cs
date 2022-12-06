using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho_Final.Migrations
{
    public partial class DbVersion7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoDisponivel",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ValidadeSaldo",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Origem",
                table: "Messages",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "Destino",
                table: "Messages",
                newName: "From");

            migrationBuilder.RenameColumn(
                name: "Data_Envio",
                table: "Messages",
                newName: "SentDate");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Id_Mensagem",
                table: "Messages",
                newName: "MsgId");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Clients",
                newName: "Vat");

            migrationBuilder.RenameColumn(
                name: "NrContribuinte",
                table: "Clients",
                newName: "Postal");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clients",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Morada",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Clients",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "CodPostal",
                table: "Clients",
                newName: "Addr");

            migrationBuilder.RenameColumn(
                name: "NrCliente",
                table: "Clients",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "Validade",
                table: "Cards",
                newName: "ValidUntil");

            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Cards",
                newName: "Credit");

            migrationBuilder.RenameColumn(
                name: "Nr_Cliente",
                table: "Cards",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "Nr_Cartao",
                table: "Cards",
                newName: "CardNr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Messages",
                newName: "Origem");

            migrationBuilder.RenameColumn(
                name: "SentDate",
                table: "Messages",
                newName: "Data_Envio");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Messages",
                newName: "Destino");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "MsgId",
                table: "Messages",
                newName: "Id_Mensagem");

            migrationBuilder.RenameColumn(
                name: "Vat",
                table: "Clients",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Postal",
                table: "Clients",
                newName: "NrContribuinte");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Clients",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "Morada");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Clients",
                newName: "Localidade");

            migrationBuilder.RenameColumn(
                name: "Addr",
                table: "Clients",
                newName: "CodPostal");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "NrCliente");

            migrationBuilder.RenameColumn(
                name: "ValidUntil",
                table: "Cards",
                newName: "Validade");

            migrationBuilder.RenameColumn(
                name: "Credit",
                table: "Cards",
                newName: "Saldo");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Cards",
                newName: "Nr_Cliente");

            migrationBuilder.RenameColumn(
                name: "CardNr",
                table: "Cards",
                newName: "Nr_Cartao");

            migrationBuilder.AddColumn<float>(
                name: "SaldoDisponivel",
                table: "Clients",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidadeSaldo",
                table: "Clients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
