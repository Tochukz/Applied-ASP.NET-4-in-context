<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomError.aspx.cs" Inherits="HandlingErrors.CustomError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Error Page</title>
</head>
<body>
   <div id="exceptionType" runat="server" />
   <div id="message" runat="server" />
   <a href="/Default.aspx" runat="server">Click here to start</a>
</body>
</html>
