<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomWebControls.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Web Controls</title>
    <style type="text/css">
        .auto-style1 {
            width: 8px;
            height: 14px;
        }
        .nodeStyle {
            background-repeat: repeat-x;
            float: left;
            min-height: 51px;
        }
        .textStyle {
            padding: 15px 15px 15px 30px;
            vertical-align: middle;
            float: left;
            clear: left;
            text-decoration: none;
            font-weight: bold;
            font-size: large;
            color: #ffffff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!--SiteMapPath With PathSeparatorTemplate-->
        <!--
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
            <PathSeparatorTemplate>
              <img alt="&amp;raquo;" class="auto-style1" src="Content/path_separator.gif" />
            </PathSeparatorTemplate>
        </asp:SiteMapPath>
        -->
        <!--SiteMapPath with RootNodeTemplate, NodeTemplate and CurrentNodeTemplate-->
        <asp:SiteMapPath ID="SiteMapPath2" runat="server">
            <PathSeparatorTemplate>

            </PathSeparatorTemplate>
            <RootNodeTemplate>
                <div class="nodeStyle" style="background-image: url('Content/back_1.png')">
                    <a class="textStyle" href='<%# Eval("Url") %>'>
                        <%# Eval("Title") %>
                    </a>
                </div>
            </RootNodeTemplate>
            <NodeTemplate>
                <div class="nodeStyle" style="background-image: url('Content/back_2.png')">
                    <a class="textStyle" href='<%# Eval("Url") %>'>
                        <%# Eval("Title") %>
                    </a>
                </div>
            </NodeTemplate>
            <CurrentNodeTemplate>
                <div class="nodeStyle" style="background-image: url('Content/back_final.png');">
                    <a class="textStyle" style="color: #801100" href='<%# Eval("Url") %>'>
                        <%# Eval("Title") %>
                    </a>
                </div>
                <div class="nodeStyle" style="background: #801100; width: 2px" />
            </CurrentNodeTemplate>
        </asp:SiteMapPath>

        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>First Item</asp:ListItem>
                <asp:ListItem>Second Item</asp:ListItem>
                <asp:ListItem>Third Item</asp:ListItem>
            </asp:RadioButtonList>
    </form>
</body>
</html>
