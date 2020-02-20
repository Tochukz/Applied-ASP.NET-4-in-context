<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TraceDemo.Default" Trace="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trace Demo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Number: <input type="text" id="numericValue" runat="server" />
            <input type="submit" value="Add" />
            <div style="clear:both; margin:2px">
                Running total <span id="runningTotal" runat="server" />
             </div>
        </div>
    </form>
</body>
</html>
