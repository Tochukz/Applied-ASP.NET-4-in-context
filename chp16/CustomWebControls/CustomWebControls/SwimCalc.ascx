<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SwimCalc.ascx.cs" Inherits="CustomWebControls.SwimCalc" %>
<style type="text/css">
    span.swimcalc {
        text-align: right;
        margin: 5px;
        width: 100px;
        height: 20px;
        float: left;
        clear: left;
    }
    input.swimcalcInput {
        margin: 5px;
    }
</style>
<div>
    <asp:Label CssClass="swimcalc" ID="Lable1" runat="server" Text="Laps:"></asp:Label>
    <asp:TextBox CssClass="swimcalcInput" ID="LapsText" runat="server">1</asp:TextBox>
</div>
<div>
    <asp:Label CssClass="swimcalc" ID="Lable2" runat="server" Text="Length:"></asp:Label>
    <asp:TextBox CssClass="swimcalcInput" ID="LengthText" runat="server">20</asp:TextBox>
</div>
<div>
    <asp:Label CssClass="swimcalc" ID="Lable3" runat="server" Text="Minutes:"></asp:Label>
    <asp:TextBox CssClass="swimcalcInput" ID="MinText" runat="server">60</asp:TextBox>
</div>
<div>
    <asp:Label CssClass="swimcalc" ID="Label4" runat="server" Text="Cals/Hr:"></asp:Label>
    <asp:TextBox CssClass="swimcalcInput" ID="CalsText" runat="server">1070</asp:TextBox>
</div>