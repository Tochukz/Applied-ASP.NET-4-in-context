<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charts.aspx.cs" Inherits="RichDataControls.Charts" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="LinqDataSource1">
                <Series>
                    <asp:Series Name="Times" XValueMember="Date" YValueMembers="Hours"></asp:Series>
                    <asp:Series Name="Distance" XValueMember="Date" YValueMembers="Distance" ChartType="Spline" BorderWidth="3" ShadowOffset="2" Color="PaleVioletRed" YAxisType="Secondary"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX>
                            <LabelStyle Format="MM-dd" />
                        </AxisX>
                        <AxisX Title="Time" Interval="1" />
                        <AxisY Title="Distance" Interval="10" Minimum="10" Maximum="40"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Text="Time & Distance" Font="Utopia, 16" />
                </Titles>
                <BorderSkin SkinStyle="Emboss" />
            </asp:Chart>
        </div>
    </form>
 <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="RichDataControls.Charts" EntityTypeName="" OrderBy="Date" TableName="Results"></asp:LinqDataSource>
</body>
</html>
