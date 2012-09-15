using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Resources.Constants {
    public class TableColumn {
        public TableColumns columnIDfield { get; set; }
        public string columnNamefield { get; set; }
        public ColumnDisplayType defaultDisplayTypefield { get; set; }
        public List<ColumnDisplayType> displayTypeOptionsfiels { get; set; }
        public bool displayColumnfield { get; set; }
        public bool canComparefield { get; set; }
        public uint defaultWidthfield { get; set; }

        public TableColumn() {
            this.columnIDfield = TableColumns.Undefined;
            this.columnNamefield = string.Empty;
            this.defaultDisplayTypefield = ColumnDisplayType.Name;
            this.displayTypeOptionsfiels = new List<ColumnDisplayType>();
            this.displayColumnfield = true;
            this.canComparefield = false;
            this.defaultWidthfield = 100;
        }

        /// <summary>
        /// Default Values for a Table Column
        /// </summary>
        /// <param name="id">The statistical ID associated with the column</param>
        /// <param name="name">The Name to put on the column heading</param>
        /// <param name="defaultDisplay">The default display type</param>
        /// <param name="graphical">Whether the value can be displayed graphically</param>
        /// <param name="display">Whether to display the column by default</param>
        /// <param name="width">The default with of the column</param>
        public TableColumn(TableColumns id, string name, ColumnDisplayType defaultDisplay, List<ColumnDisplayType> displayOptions, bool display, bool compare, uint width) {
            this.columnIDfield = id;
            this.columnNamefield = name;
            this.defaultDisplayTypefield = defaultDisplay;
            this.displayTypeOptionsfiels = displayOptions;
            this.displayColumnfield = display;
            this.canComparefield = compare;
            this.defaultWidthfield = width;
        }
    }

    public class Columns {
        public static List<TableColumn> PlayerTableColumns = new List<TableColumn>() {
            new TableColumn(TableColumns.Player_AgeDays, "Days", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_AgeFull, "Age", ColumnDisplayType.Name, new List<ColumnDisplayType>() { ColumnDisplayType.Name }, true, false, 80),
            new TableColumn(TableColumns.Player_AgeYears, "Years", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 20),
            new TableColumn(TableColumns.Player_Category, "Category", ColumnDisplayType.Graphical, new List<ColumnDisplayType>() { ColumnDisplayType.Name, ColumnDisplayType.Graphical }, true, false, 80),
            new TableColumn(TableColumns.Player_Defending, "Defending", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_FirstName, "Fistname", ColumnDisplayType.Name, new List<ColumnDisplayType>() { ColumnDisplayType.Name }, true, false, 80),
            new TableColumn(TableColumns.Player_Form, "Form", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_FullName, "Name", ColumnDisplayType.Name, new List<ColumnDisplayType>() { ColumnDisplayType.Name }, true, false, 150),
            new TableColumn(TableColumns.Player_Health, "Health", ColumnDisplayType.Graphical, new List<ColumnDisplayType>() { ColumnDisplayType.Name, ColumnDisplayType.Graphical }, true, false, 80),
            new TableColumn(TableColumns.Player_ID, "ID", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value }, false, false, 10),
            new TableColumn(TableColumns.Player_Keeping, "Keeper", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 80),
            new TableColumn(TableColumns.Player_LastName, "Lastname", ColumnDisplayType.Name, new List<ColumnDisplayType>() { ColumnDisplayType.Name }, true, false, 80),
            new TableColumn(TableColumns.Player_LastPosition, "LastPosition", ColumnDisplayType.Graphical, new List<ColumnDisplayType>() { ColumnDisplayType.Name, ColumnDisplayType.Graphical }, true, false, 80),
            new TableColumn(TableColumns.Player_Nationality, "Nationality", ColumnDisplayType.Graphical, new List<ColumnDisplayType>() { ColumnDisplayType.Name, ColumnDisplayType.Graphical }, true, false, 80),
            new TableColumn(TableColumns.Player_Number, "#", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value }, true, false, 30),
            new TableColumn(TableColumns.Player_Passing, "Passing", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_Playmaking, "Playmaking", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_Scoring, "Scoring", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_SetPieces, "SetPieces", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_Stamina, "Stamina", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 30),
            new TableColumn(TableColumns.Player_TSI, "TSI", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 40),
            new TableColumn(TableColumns.Player_Warnings, "Cards", ColumnDisplayType.Graphical, new List<ColumnDisplayType>() { ColumnDisplayType.Name, ColumnDisplayType.Graphical }, true, false, 40),
            new TableColumn(TableColumns.Player_Wing, "Winger", ColumnDisplayType.Value, new List<ColumnDisplayType>() { ColumnDisplayType.Value, ColumnDisplayType.Name, ColumnDisplayType.NameValue }, true, true, 40)
        };

        public const string Display = "Display";
        public const string Value = "Value";
        public const string Position = "Position";
        public const string PositionChange = "PositionChange";
        public const string TeamName = "TeamName";
        public const string Matches = "Matches";
        public const string Won = "Won";
        public const string Draw = "Draw";
        public const string Lost = "Lost";
        public const string GoalsFor = "GoalsFor";
        public const string GoalsAgainst = "GoalsAgainst";
        public const string GoalDifference = "GoalDifference";
        public const string Points = "Points";
        public const string Text = "Text";
        public const string TypeID = "TypeID";
        public const string CategoryID = "CategoryID";
        public const string EventDate = "EventDate";
        public const string MultiLevel = "MultiLevel";
        public const string NumberOfEvents = "NumberOfEvents";
        public const string Round = "Round";
        public const string MatchDate = "MatchDate";
        public const string HomeResult = "HomeResult";
        public const string HomeTeam = "HomeTeam";
        public const string Score = "Score";
        public const string AwayTeam = "AwayTeam";
        public const string AwayResult = "AwayResult";
        public const string TeamID = "TeamID";
        public const string HomeTeamID = "HomeTeamID";
        public const string AwayTeamID = "AwayTeamID";
    }
}