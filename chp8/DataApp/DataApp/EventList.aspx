<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="DataApp.EventList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event List</title>
    <style type="text/css">
        *.standardDiv  {
            float:left;
            padding: 10px;
        }
        select {
            width: 120px;
        }
        label {
            vertical-align: top;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="resultsTable" runat="server" rules="cols">
            <tr>
                <th>Date</th>
                <th>Athlete</th>
                <th>Event Type</th>
                <th>Swim</th>
                <th>Cycle</th>
                <th>Run</th>
                <th>Overall</th>
                <th>Rank</th>
                <th>Ref Rank</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </table>
        <div class="standardDiv">
            <label>Event Type:</label>
            <select id="eventSelector" runat="server">
                <option>All</option>
            </select>
        </div>
        <div class="standardDiv">
            <input type="submit" value="Submit" />
        </div>
        <div>
            <a href="/AddEvent.aspx">Add New Event</a>
        </div>
    </form>
</body>
</html>
