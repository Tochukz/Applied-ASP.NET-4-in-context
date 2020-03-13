<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiView.aspx.cs" Inherits="WebControlsApp.MultiView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MultiView</title>
    <style type="text/css">
        .section {
            border: solid silver 1px;
            padding: 1em;
        }
    </style>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        $('.view').hide();
        $(document).ready(function () {
            var counter = 0;
            $('#cycleButton').click(function () {
                counter = (counter + 1) % 4;
                $('.view').hide();
                $('#view' + counter).show();
                return false;
            }).click();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="section">
            <h3>MultiView WebControl</h3>
            <asp:Button ID="Button1" runat="server" Text="Cycle" OnClick="Button1_Click" />
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:Label ID="Lable1" runat="server" Text ="First Name:"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="Lable2" runat="server" Text="Surname:"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Email Address:"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </asp:View>
            </asp:MultiView>
        </div>
        <!--The view that a MultiView control displays is controlled using the ActiveViewIndex property. 
            The default value os -1, meaning that none of the views is displayed.-->

        <h3>Multiview Implemented Using jQuery</h3>
        <div  class="section">
            <p>
                <button type="button" id="cycleButton">cycleButton</button>
            </p>
            <p id="view1" class="view">
                <span>First Name:</span>
                <input type="text" name="firstname"/>
            </p>
             <p id="view2" class="view">
                <span>Surname:</span>
                <input type="text" name="surname" />
            </p>
            <p id="view3" class="view">
                <span>Email Address:</span>
                <input email="text" name="EmailAddress" />
            </p>
        </div>
    </form>
</body>
</html>
