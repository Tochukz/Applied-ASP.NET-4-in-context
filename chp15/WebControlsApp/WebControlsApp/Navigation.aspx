<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navigation.aspx.cs" Inherits="WebControlsApp.Navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Navigation</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" onmenuitemclick="Menu1_MenuItemClick" Orientation="Horizontal" StaticSubMenuIndent="16px">
                <Items>
                    <asp:MenuItem Text="First Menu Item">
                        <asp:MenuItem Text="Inner Item 1" />
                        <asp:MenuItem Text="Inner Item 2" />
                    </asp:MenuItem>
                    <asp:MenuItem Text="SecondMenut Item" />
                    <asp:MenuItem Text="Third Menu Item">
                        <asp:MenuItem Text="Inner Item 3" Enabled="false" />
                        <asp:MenuItem Text="Inner Item 4" />
                    </asp:MenuItem>
                </Items>
            </asp:Menu>

            <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ShowLines="true">
                <Nodes>
                    <asp:TreeNode Text="First Item" Value="First Item">
                        <asp:TreeNode Text="Child Node 1" Value="Child Node 1"></asp:TreeNode>
                        <asp:TreeNode Text="Child Node 2" Value="Child Node 2"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Checked="true" Text="Second Item" Value="Second Item" />
                    <asp:TreeNode Checked="true" Text="Third Item" Value="Third Item">
                        <asp:TreeNode Text="Child Node 1" Value="Child Node 3"></asp:TreeNode>
                        <asp:TreeNode Text="Child Node 2" Value="Child Node 4"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
            
            <!--Site Map seems to work only on the Default.aspx page-->
            <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>

            <div id="results" runat="server"></div>
        </div>
    </form>
</body>
</html>
