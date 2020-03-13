<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wizard.aspx.cs" Inherits="WebControlsApp.Wizard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0">
                <WizardSteps>
                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                        <asp:Label ID="Label1" runat="server" Text="First Name"> </asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Step2">
                        <asp:Label ID="Label2" runat="server" Text="Surname"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep3" runat="server" Title="Step3">
                        <asp:Label ID="Label3" runat="server" Text="Email Adress"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
        </div>
    </form>
</body>
</html>
