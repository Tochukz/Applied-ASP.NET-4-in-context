<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebControlsApp.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
           <asp:BulletedList ID="BulletedList1" runat="server">
               <asp:ListItem>First Item</asp:ListItem>
               <asp:ListItem>Second Item</asp:ListItem>
               <asp:ListItem Value="Third Item Value">Third Item</asp:ListItem>
            </asp:BulletedList>

            <asp:BulletedList ID="BulletList2" BulletStyle="Numbered" runat="server"></asp:BulletedList>
       
            <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" >
                <asp:ListItem>List Item 1</asp:ListItem>
                <asp:ListItem>List Item 2</asp:ListItem>
                <asp:ListItem>List Item 3</asp:ListItem>
            </asp:ListBox>

            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Drop Down 1</asp:ListItem>
                <asp:ListItem>Drop Down 2</asp:ListItem>
                <asp:ListItem>Drop Down 3</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>

<!--
The DropDownList control allows the programmer to determine which single list item has been selected using the SelectedIndex method.
To determine the selections in a ListBox control, you need to enumerate the ListItem objects available via the Items property and check the Selected property of each one. 
-->
