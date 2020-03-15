<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingCustomControl.aspx.cs" Inherits="CustomWebControls.UsingCustomControl" %>

<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="cc1" %>
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
            <cc1:ResultsControl ID="ResultsControl1" runat="server" />
        </div>
    </form>
</body>
</html>
