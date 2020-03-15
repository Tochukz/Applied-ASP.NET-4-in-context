<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Validation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation</title>
    <link href="Styles/styles.css" rel="stylesheet" />
    <script type="text/javascript">
        // Custom validation function for client side
        function CustomValidation(source, args) {
            var iVal = parseInt(args.Value);
            args.IsValid = (parseFloat(args.Value) == iVal) && iVal < 50;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                HeaderText="Please correct the following errors:" 
                                ShowMessageBox="true"
                                DisplayMode="BulletList"
                                ShowSummary="true"
                                CssClass="validation" />
        <div>          
            <asp:Label ID="Label1" runat="server" Text="Laps:" CssClass="label" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="TextBox1"
                                ErrorMessage="Enter a number of lasps between 1 and 200"
                                Text="*"
                                MaximumValue="200"
                                MinimumValue="1"
                                Type="Integer"
                                CssClass="validation"
                                Display="Dynamic" />
            <!--The RangeValidator doesn't infer the kind of data you are working with so you must provide the type through the Type property -->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TextBox1"
                                    ErrorMessage="Enter a number of laps" 
                                    Text="*"
                                    CssClass="validation"
                                    Display="Dynamic"/>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Pool Length:" CssClass="label" />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <%--
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                  ControlToValidate="TextBox2"
                                  ErrorMessage="Enter a value less than 50" 
                                  ValueToCompare="50"
                                  Operator="LessThan"    
                                  Type="Integer" 
                                  CssClass="validation"/>--%>
            <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                  ControlToValidate="TextBox2"
                                  ErrorMessage="Enter a value more than the number of minutes" 
                                  Text="*"
                                  ControlToCompare="TextBox3"
                                  Operator="GreaterThan"    
                                  Type="Integer" 
                                  CssClass="validation"/>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Minutes:" CssClass="label" />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                 ControlToValidate="TextBox3"
                                 ErrorMessage="Enter a whole number of minutes that is less than 50"
                                 Text="*"
                                 OnServerValidate="CustomValidator1_ServerValidate"
                                 ClientValidationFunction="CustomValidation"
                                 CssClass="validation"/>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Calories/Hour:" CssClass="label" />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="TextBox4"
                                            ErrorMessage="Enter a 4-digit number that starts with 1"
                                            Text="*"
                                            ValidationExpression="1\d\d\d"
                                            CssClass="validation"/>
        </div>
        <div style="clear: left">
            <asp:Button ID="Button1" runat="server" Text="Calculate" style="margin-left:100px" OnClick="Button1_Click" />
        </div>
        <div class="results">
            <asp:TextBox ID="TextBox5" runat="server" BorderStyle="None" ReadOnly="true" TextMode="MultiLine" Rows="4" Columns="30"></asp:TextBox>
        </div>
    </form>
</body>
</html>
