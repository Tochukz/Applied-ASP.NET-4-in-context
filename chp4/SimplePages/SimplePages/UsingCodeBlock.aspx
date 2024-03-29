﻿<%@ Page Language="c#" %>
<script runat="server">
    protected string GetImageName() {
        return "Images/triathlon.png";
    }
    protected string GetImageAlt() {
        return "Triathlon Symbol";
    }
</script>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Using Code Block</title>
</head>
<body>
     <div>
        Here are some numbers I like: 
        <ul>
            <%
               for(int i = 0; i < 5; i++) {
                 Response.Write(string.Format("<li>{0}</li>\n", i));  
               }
            %>
        </ul>
    </div>
    <div>
        Here are Images:  
        <img src="Images/triathlon.png" alt="Triathlon Symbols" />
    </div>
    <div>
        Repeat Image
        <img src="<% =GetImageName() %>" alt="<% =GetImageAlt() %>" />        
    </div>
     <div>
        Repeat Image yet again
        <%
          Response.Write(string.Format("<img src=\"{0}\" alt=\"{1}\">", GetImageName(), GetImageAlt()));
        %>
     </div>
    <div>
        <a href="ThirdPage.html"> This is a link to another page</a>
    </div>
    <div>
       THe directory where the temporal class files is generated is: 
       <%
          =System.Web.HttpRuntime.CodegenDir
       %>
    </div>
</body>
</html>