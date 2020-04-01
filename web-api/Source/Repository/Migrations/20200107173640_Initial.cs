﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Repository.Extensions;

namespace Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Persons", table => new
                                         {
                                             Id = table.Column<Guid>(),
                                             Name = table.Column<string>(maxLength: 15,
                                                                         nullable: true),
                                             Age = table.Column<int>(maxLength: 5)
                                         },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Persons", x => x.Id);
                                         });
            
            migrationBuilder.Sql("CREATE SCHEMA History");
            migrationBuilder.AddTemporalTableSupport("Persons", "History");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Persons");
            migrationBuilder.DropTable("Persons", "History");
        }
    }
}
