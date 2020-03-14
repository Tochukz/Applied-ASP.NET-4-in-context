<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="EmailApp.Mail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mail</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <asp:Panel CssClass="container" runat="server">
        <asp:Panel Cssclass="row" runat="server">
            <asp:Panel Cssclass="col-sm-6" runat="server">
                <h3>Send Mails Anytime</h3>
                <asp:Panel CssClass="col-sm-offset-3 col-sm-9" runat="server">
                    <asp:Label ID="MessageLabel" Font-Bold="true" runat="server"></asp:Label>
                </asp:Panel>                
                <form id="form1" class="form-horizontal" runat="server">
                     <asp:Panel CssClass="form-group" runat="server">
                        <asp:Panel CssClass="col-sm-3"  runat="server">Sender Email</asp:Panel>
                        <asp:Panel CssClass="col-sm-8"  runat="server">
                            <asp:TextBox CssClass="form-control"    ID="SenderEmail" runat="server"></asp:TextBox>
                        </asp:Panel>
                         <asp:Panel CssClass="col-sm-1" runat="server">
                             <asp:RequiredFieldValidator ID="SenderFieldRequiredValidator" Display="Dynamic"
                                    ControlToValidate="SenderEmail" Text="*" ForeColor="Red" ErrorMessage="Sender Email is required" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="SenderFieldRegularExpressionValidator" 
                                    ControlToValidate="SenderEmail" runat="server" ErrorMessage="Your Email Invalid" Text="*"
                                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                         </asp:Panel>
                    </asp:Panel>
                    <asp:Panel CssClass="form-group" runat="server">
                        <asp:Panel CssClass="col-sm-3"  runat="server">Recipient Email</asp:Panel>
                        <asp:Panel CssClass="col-sm-8"  runat="server">
                            <asp:TextBox CssClass="form-control"  ID="RecipientEmail" runat="server"></asp:TextBox>                                                     
                        </asp:Panel>
                        <asp:Panel CssClass="col-sm-1" runat="server">
                            <asp:RequiredFieldValidator ID="RecipientFieldValidator" Display="Dynamic"
                                    ControlToValidate="SenderEmail" Text="*" ForeColor="Red" ErrorMessage="Recipient Email is required" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator  ID="RecipientEmailRegularExpressionValidator" 
                                    ControlToValidate="RecipientEmail"  runat="server" ForeColor="Red" ErrorMessage="Recipient Email is invalid" Text="*"
                                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                        </asp:Panel>
                    </asp:Panel>
                     <asp:Panel CssClass="form-group" runat="server">
                        <asp:Panel CssClass="col-sm-3"  runat="server">Subject</asp:Panel>
                        <asp:Panel CssClass="col-sm-8"  runat="server">
                            <asp:TextBox CssClass="form-control"  ID="EmailSubject" runat="server"></asp:TextBox>                            
                        </asp:Panel>
                         <asp:Panel CssClass="col-sm-1" runat="server">
                             <asp:RequiredFieldValidator ID="EmailSubjectRequiredFieldValidator" runat="server" ErrorMessage="Please enter your subject" ControlToValidate="EmailSubject" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         </asp:Panel>
                    </asp:Panel>
                     <asp:Panel CssClass="form-group" runat="server">
                        <asp:Panel CssClass="col-sm-3"  runat="server">Body</asp:Panel>
                        <asp:Panel CssClass="col-sm-8"  runat="server">
                            <asp:TextBox CssClass="form-control"  ID="EmailBody" TextMode="MultiLine" runat="server" Rows="5"></asp:TextBox>                           
                        </asp:Panel>
                        <asp:Panel CssClass="col-sm-1" runat="server">
                             <asp:RequiredFieldValidator ID="EmailBodyRequiredFieldValidator" runat="server" ErrorMessage="Please type your email body" ControlToValidate="EmailBody" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel CssClass="col-sm-offset-3 col-sm-9" runat="server">
                         <asp:Button CssClass="btn btn-primary" Text="Send" runat="server"></asp:Button>
                    </asp:Panel>
                    <asp:Panel CssClass="col-sm-offset-3 col-sm-9" runat="server">
                        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" HeaderText="Please fix the following error:" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="MessageSummary" CssClass="col-sm-offset-3 col-sm-9" runat="server"></asp:Panel>
                </form>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</body>
</html>
