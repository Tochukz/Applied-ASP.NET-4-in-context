<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandlingErrors.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Handling</title>
   <style type="text/css">
       label {display: block}
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 250px">
            <b>Select Exception Type:</b>
            <label for="ArgumentOutOfRangeException">
                <input type="radio" name="exceptionType" id="ArgumentOutOfRangeExceptionControl" value="ArgumentOutOfRangeException" runat="server"  checked="true"/>
                ArgumentOutOfRangeException
            </label>
            <label for="InvalidOperationException">
                <input type="radio" name="exceptionType" id="InvalidOperationExceptionControl" value="InvalidOperationException" runat="server" />
                InvalidOperationException
            </label>
            <label for="NotImplementedException">
                <input type="radio" name="exceptionType" id="NotImplementedExceptionControl" value="NotImplementedException" runat="server"/>
                NotImplementedException
            </label>

            <input type="submit" id="button" value="Submit" />
        </div>
    </form>
</body>
</html>
