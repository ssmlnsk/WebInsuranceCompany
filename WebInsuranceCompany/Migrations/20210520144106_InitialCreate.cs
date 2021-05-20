using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebInsuranceCompany.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupOfClients",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfClients", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Requirements = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibilities = table.Column<string>(type: "NVARCHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    RiskID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    AverageProbability = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.RiskID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "INT", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    PassportData = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    GroupID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_GroupOfClients_GroupID",
                        column: x => x.GroupID,
                        principalTable: "GroupOfClients",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "INT", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    PassportData = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    PostID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPolicy",
                columns: table => new
                {
                    TypeOfPolicyID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Conditions = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    RiskID1 = table.Column<int>(type: "INT", nullable: false),
                    RiskID2 = table.Column<int>(type: "INT", nullable: false),
                    RiskID3 = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPolicy", x => x.TypeOfPolicyID);
                    table.ForeignKey(
                        name: "FK_TypeOfPolicy_Risk_RiskID1",
                        column: x => x.RiskID1,
                        principalTable: "Risk",
                        principalColumn: "RiskID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeOfPolicy_Risk_RiskID2",
                        column: x => x.RiskID2,
                        principalTable: "Risk",
                        principalColumn: "RiskID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeOfPolicy_Risk_RiskID3",
                        column: x => x.RiskID3,
                        principalTable: "Risk",
                        principalColumn: "RiskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "INT", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "DATE", nullable: false),
                    DateOfFinish = table.Column<DateTime>(type: "DATE", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    PaymentAmount = table.Column<int>(type: "INT", nullable: false),
                    PaymentMark = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    MarkOfEnd = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    ClientID = table.Column<int>(type: "INT", nullable: true),
                    TypeOfPolicyID = table.Column<int>(type: "INT", nullable: false),
                    EmployeeID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolicyID);
                    table.ForeignKey(
                        name: "FK_Policy_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_TypeOfPolicy_TypeOfPolicyID",
                        column: x => x.TypeOfPolicyID,
                        principalTable: "TypeOfPolicy",
                        principalColumn: "TypeOfPolicyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_GroupID",
                table: "Client",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PostID",
                table: "Employee",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ClientID",
                table: "Policy",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_EmployeeID",
                table: "Policy",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_TypeOfPolicyID",
                table: "Policy",
                column: "TypeOfPolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfPolicy_RiskID1",
                table: "TypeOfPolicy",
                column: "RiskID1");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfPolicy_RiskID2",
                table: "TypeOfPolicy",
                column: "RiskID2");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfPolicy_RiskID3",
                table: "TypeOfPolicy",
                column: "RiskID3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TypeOfPolicy");

            migrationBuilder.DropTable(
                name: "GroupOfClients");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Risk");
        }
    }
}
