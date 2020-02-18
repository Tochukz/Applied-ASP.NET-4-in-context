<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SwimCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Swim Calculator</title>
    <style type="text/css">
        div.label {
            margin: 5px;
            height: 20px;
        }
        input.textinput {
            margin: 2px;
            width: 75px;
            height: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:200px;">
            <div style="width:auto; min-width:50%; float:left; text-align:right">
                <div class="label">Laps:</div>
                <div class="label">Pool Length</div>
                <div class="label">Minutes:</div>
                <div class="label">Calories/Hour:</div>
            </div>

            <div id="inputs" style="width:auto; float:left">
                <div>
                    <input class="textinput" id="lapsInput" type="text" runat="server" />
                </div>
                <div>
                    <input class="textinput" id="lengthInput" type="text" runat="server" />
                </div>
                <div>
                    <input class="textinput" id="minsInput" type="text" runat="server" />
                </div>
                <div>
                    <input class="textinput" id="calsInput" type="text" runat="server" />
                </div>
            </div>

            <div style="text-align:center; clear:both;">
                <input id="button" value="Calculate" type="submit" />
            </div>
            <div id="results" runat="server" style="float:left; width:123px" enableviewstate="false" />
            <div id="oldResults" runat="server" style="float:left; width:123px; padding-left:2px" enableviewstate="false" />
        </div>
    </form>
</body>
</html>
<!-- ASP.NET by default, adds the InnerHtml value assigned to the div controls (in the code-behimd) to the ViewState
    This results in an overhead and the information gets send on a round trip to the browser.
    To prevent the default behaviour, the enableviewstate attribute is applied and given a value of false
  -->