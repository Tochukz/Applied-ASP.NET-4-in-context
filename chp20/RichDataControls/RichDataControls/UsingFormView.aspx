<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingFormView.aspx.cs" Inherits="RichDataControls.UsingFormView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using FormView control</title>
    <style type="text/css">
        .datalabel {
            font-weight: bold; 
            text-align: right;
            padding: 3px; 
            margin-right: 2px
        }
        .datavalue {
            padding-right: 5px
        }
        .buttonrow {
            text-align: center

        }
        .hf {
            text-align: center; 
            font-weight: bold; 
            background-color: Gray; 
            color: White
        }
        table {
            border: thin solid Gray
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:FormView ID="FormView1" runat="server" DataSourceID="EntityDataSource1" DataKeyNames="ID" AllowPaging="true">
               <EditItemTemplate>
                   ID: <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' /> <br />
                   Date: <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' /> <br />
                   Athlete <asp:TextBox ID="AthleteTextBox" runat="server" Text='<%# Bind("Athlete") %>' /> <br />
                   Type <asp:TextBox ID="TypeTextBox" runat="server" Text='<%# Bind("Type") %>' /> <br />
                   SwimTime: <asp:TextBox ID="SwimTimeTextBox" runat="server" Text='<%# Bind("SwimTime") %>' /> <br />
                   CycleTime: <asp:TextBox ID="CycleTimeTextBox" runat="server" Text='<%# Bind("CycleTime") %>' /> <br />
                   RunTime: <asp:TextBox ID="RunTimeTextBox" runat="server" Text='<%# Bind("RunTime") %>' /> <br />
                   OverallTime: <asp:TextBox ID="OverallTimeTextBox" runat="server" Text='<%# Bind("OverallTime") %>' /> <br />
                   Athelete1: <asp:TextBox ID="Athlete1TextBox" runat="server" Text='<%# Bind("Athlete1") %>' /> <br />
                   Event Type: <asp:TextBox ID="EventTypeTextBox" runat="server" Text='<%# Bind("EventType") %>' /> <br />

                   <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="true" CommandName="Update" Text="Update" /> &nbsp;
                   <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel" />
               </EditItemTemplate>
               <InsertItemTemplate>
                   ID: <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Eval("ID") %>' /> <br />
                   Date: <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' /> <br />
                   Athlete <asp:TextBox ID="AthleteTextBox" runat="server" Text='<%# Bind("Athlete") %>' /> <br />
                   Type <asp:TextBox ID="TypeTextBox" runat="server" Text='<%# Bind("Type") %>' /> <br />
                   SwimTime: <asp:TextBox ID="SwimTimeTextBox" runat="server" Text='<%# Bind("SwimTime") %>' /> <br />
                   CycleTime: <asp:TextBox ID="CycleTimeTextBox" runat="server" Text='<%# Bind("CycleTime") %>' /> <br />
                   RunTime: <asp:TextBox ID="RunTimeTextBox" runat="server" Text='<%# Bind("RunTime") %>' /> <br />
                   OverallTime: <asp:TextBox ID="OverallTimeTextBox" runat="server" Text='<%# Bind("OverallTime") %>' /> <br />
                   Athelete1: <asp:TextBox ID="Athlete1TextBox" runat="server" Text='<%# Bind("Athlete1") %>' /> <br />
                   Event Type: <asp:TextBox ID="EventTypeTextBox" runat="server" Text='<%# Bind("EventType") %>' /> <br />

                   <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert" /> &nbsp;
                   <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel" />
               </InsertItemTemplate>
               <ItemTemplate>
                   <tr>
                       <td class="datalabel">
                           <span>Date:</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("Date", "{0:d}") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td class="datalabel">
                           <span>Athlete:</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("Athlete") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td class="datalabel">
                           <span>Type:</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("Type") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td class="datalabel">
                           <span>Time (Swim):</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("SwimTime") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td class="datalabel">
                           <span>Time (Cycle):</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("CycleTime") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td class="datalabel">
                           <span>Time (Run):</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("RunTime") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td class="datalabel">
                           <span>Time (Overall):</span> 
                       </td>
                       <td class="datavalue">
                           <span><%# Eval("OverallTime") %></span>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2" class="buttonrow">
                           <asp:Button ID="EditButton" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit" />
                           <asp:Button ID="DeleteButton" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" />
                           <asp:Button ID="NewButton" runat="server" CausesValidation="false" CommandName="New" Text="New" />
                       </td>
                   </tr>
               </ItemTemplate>
               <HeaderTemplate>
                   <tr>
                       <td class="hf" colspan="2">Header</td>
                   </tr>
               </HeaderTemplate>
               <FooterTemplate>
                   <tr>
                       <td class="hf" colspan="2">Footer</td>
                   </tr>
               </FooterTemplate>
               <PagerTemplate>
                   <tr>
                       <td colspan="2" class="buttonrow">
                           <asp:Button ID="PrevButton" runat="server" CausesValidation="false" CommandName="Page" CommandArgument="Prev" Text="Prev" />
                           <b><%# Container.PageIndex +1 %> of <%# Container.PageCount %></b> Events
                           <asp:Button ID="NextButton" runat="server" CausesValidation="false" CommandName="Page" CommandArgument="Next" Text="Next" />
                       </td>
                   </tr>
               </PagerTemplate>
           </asp:FormView>
        </div>
    </form>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities" DefaultContainerName="TrainingDataEntities" 
                          EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Events"></asp:EntityDataSource>
</body>
</html>
