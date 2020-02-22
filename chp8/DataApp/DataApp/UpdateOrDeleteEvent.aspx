<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateOrDeleteEvent.aspx.cs" Inherits="DataApp.UpdateOrDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update or Delete</title>
     <style type="text/css">
        .error {
            color: red;
        }
        body {
            width: 960px;
        }
        .col {
            float: left;  
        }
        .col > div {
            width: 100px;
            float: left;
 
        }
        .col > div:first-child p{
            font-weight: bold;
        }
        .col > div:nth-child(2) {
            width: 200px
        } 
        .col > div select, .col > div input {
            width: 170px;
        }
        type[submit] {
            background: blue;
        }
        .footer {
            clear: both;
            width: 600px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="error" id="errorDiv" runat="server"></div>
        <div class="col">
            <div>
                <p>Month:</p>
                <p>Day:</p>
                <p>Year:</p>
                <p>Athlete</p>
            </div>
            <div class="inner-col">
                <p>
                   <select id="monthSelect" runat="server" />
                </p>
                <p>
                    <input type="text" id="dayInput" runat="server" />
                </p>
                <p>
                    <input type="text" id="yearInput" runat="server" />
                </p>
                <p>
                    <select id="athleteSelect" runat="server" />
                </p>
            </div>
        </div>
        <div class="col">
            <div>
                <p>Event Type:</p>
                <p>Swim:</p>
                <p>Cycle:</p>
                <p>Run:</p>
            </div>
            <div>
                <p>
                   <select id="eventTypeSelect" runat="server" />
                <p>
                    <input type="text" id="swimTimeInput" runat="server" placeholder="00:35:33" />
                </p>
                <p>
                    <input type="text" id="cycleTimeInput" runat="server" placeholder="00:35:57" />
                </p>
                <p>
                    <input type="text" id="runTimeInput" runat="server" placeholder="00:21:20" />
                </p>
            </div>
        </div>
        <div class="footer">
             <p>
                 <input type="submit" id="button" runat="server" value="Add" />
             </p>
        </div>
        <input type="hidden" id="keyInput" runat="server"  />
        <input type="hidden" id="modeInput" runat="server" />
    </form>
</body>
</html>
