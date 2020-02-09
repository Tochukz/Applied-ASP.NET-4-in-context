<%@ Page CodeFile="Default.aspx.cs" Inherits="SimplePages.Default" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>
    <div>
        Here are some numbers I like: 
        <ul id="numberList" runat="server" />
    </div>
    <div id="thingsListDiv" runat="server" />
    <div>
        Here is an image:  
        <img id="image" runat="server" />
    </div>
    <div>
        <a id="secondPageLink" runat="server" />
    </div>
</body>
</html>

 <!--The name assigned to an id attribute is transformed into a C# class field and camel case is the standard form for field names-->
 <!--Each HTML element that we want to modify in our C# code must also have the runat attribute with the value of server.-->