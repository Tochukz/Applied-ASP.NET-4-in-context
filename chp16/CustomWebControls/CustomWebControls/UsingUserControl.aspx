<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingUserControl.aspx.cs" Inherits="CustomWebControls.UsingUserControl" %>
<%@ Register Src="~/SwimCalc.ascx" TagName="Calc" TagPrefix="Custom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <Custom:Calc ID="calc" runat="server" OnCalcPerformed="HandleCalcPerformed" EnableTextBoxAutoPostBack="true" /> 
            
            <asp:Button ID="Button1" runat="server" Text="Button" style="margin-left:110px" />
        </div>
        <div>
          <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="5" ReadOnly="true" 
                BorderStyle="None" style="margin-left: 60px; margin-top: 20px" />
        </div>
    </form>
</body>
</html>
