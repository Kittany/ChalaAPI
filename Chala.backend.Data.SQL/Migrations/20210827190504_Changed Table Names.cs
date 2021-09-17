using Microsoft.EntityFrameworkCore.Migrations;

namespace Chala.backend.Data.SQL.Migrations
{
    public partial class ChangedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Schedule_ScheduleId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Tags_TagId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Routine_Tags_TagId",
                table: "Routine");

            migrationBuilder.DropForeignKey(
                name: "FK_Routine_Users_UserId",
                table: "Routine");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Users_UserId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Users_UserId",
                table: "TodoTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine",
                table: "Routine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "TodoTask",
                newName: "TodoTasks");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Routine",
                newName: "Routines");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_TodoTask_UserId",
                table: "TodoTasks",
                newName: "IX_TodoTasks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_UserId",
                table: "Schedules",
                newName: "IX_Schedules_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Routine_UserId",
                table: "Routines",
                newName: "IX_Routines_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Routine_TagId",
                table: "Routines",
                newName: "IX_Routines_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_TagId",
                table: "Events",
                newName: "IX_Events_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_ScheduleId",
                table: "Events",
                newName: "IX_Events_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTasks",
                table: "TodoTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routines",
                table: "Routines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Schedules_ScheduleId",
                table: "Events",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Tags_TagId",
                table: "Events",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_Tags_TagId",
                table: "Routines",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Schedules_ScheduleId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Tags_TagId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Routines_Tags_TagId",
                table: "Routines");

            migrationBuilder.DropForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_UserId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTasks",
                table: "TodoTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routines",
                table: "Routines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "TodoTasks",
                newName: "TodoTask");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Routines",
                newName: "Routine");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_TodoTasks_UserId",
                table: "TodoTask",
                newName: "IX_TodoTask_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_UserId",
                table: "Schedule",
                newName: "IX_Schedule_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Routines_UserId",
                table: "Routine",
                newName: "IX_Routine_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Routines_TagId",
                table: "Routine",
                newName: "IX_Routine_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TagId",
                table: "Event",
                newName: "IX_Event_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_ScheduleId",
                table: "Event",
                newName: "IX_Event_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine",
                table: "Routine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Schedule_ScheduleId",
                table: "Event",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Tags_TagId",
                table: "Event",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routine_Tags_TagId",
                table: "Routine",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routine_Users_UserId",
                table: "Routine",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Users_UserId",
                table: "Schedule",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Users_UserId",
                table: "TodoTask",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
