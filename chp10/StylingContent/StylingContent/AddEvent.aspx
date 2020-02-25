<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="StylingContent.AddEvent" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet"  href="/Styles/Page.css" type="text/css" />
    <script src="Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* Validation for day on month based on month */
            var daysInMonth = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
            maxDaysInMonth = function () {
                return daysInMonth[$('#<%=monthSelect.ClientID%> option:selected').index()];
            }

            /* Add custom validator to Validator(validation rule) library methods */
            $.validator.addMethod('timespan', function (value, element) {
                return value != '0:00:00' && value.match(/[0-9]:[0-5][0-9]:[0-5][0-9]/);
            }); 
            /* Configure Form Validation */
            $('form').validate({
                errorLablelContainer: '#<%=errorDiv.ClientID%>', // This is a container to place all the validation errors.
                wrapper: 'li', // This is a wrapper for each validation error
                rules: {
                    <%=yearInput.UniqueID%>: { //the UniqueID returns the generated name attribute value for the input element.
                        required: true,
                        range: [2010, 2012]
                    },
                    <%=swimTimeInput.UniqueID%>: {
                        required: true,
                        timespan: true
                    },
                    <%=cycleTimeInput.UniqueID%>: {
                        required: true,
                        timespan: true
                    },
                    <%=runTimeInput.UniqueID%>: {
                        required: true,
                        timespan: true
                    },
                    <%=dayInput.UniqueID%>: {
                        required: true,
                        range: function () { return [1, maxDaysInMonth()] }
                    }
                },
                messages: {
                    <%=yearInput.UniqueID%>: "Please enter a year from 2010 to 2012",
                    <%=swimTimeInput.UniqueID%>: "Please enter a swin time such as 1:34:52",
                    <%=cycleTimeInput.UniqueID%>: "Please enter a cycle time such as 1:3:52",
                    <%=runTimeInput.UniqueID%>: "Please enter a run time such as 1:34:52",
                    <%=dayInput.UniqueID%>: {
                        required: "Please enter a day",
                        range: jQuery.validator.format("Please enter a day between 1 and {1}")  // {1}  represents the upper limit value of the range specified
                    }
                }
            });
            $('#<%=monthSelect.ClientID%>').change(function () {
                $('#<%=dayInput.ClientID%>').valid();
            }); // calling the valid() method on an input element performs validation on the input element.
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="error" id="errorDiv" runat="server"></div>
    <div class="standardDiv">
        <div class="columnDiv elementDiv">
            <p>Month:</p>
            <p>Day:</p>
            <p>Year:</p>
            <p>Athlete</p>
        </div>
        <div class="columnDiv elementDiv">
            <p>
                <select id="monthSelect" runat="server" />
            </p>
            <p>
                <input type="text" id="dayInput" runat="server" />
            </p>
            <p>
                <input type="text" id="yearInput" runat="server" />
            </p>
            <p>
                <select id="athleteSelect" runat="server" />
            </p>
        </div>
    </div>
    <div class="standardDiv">
        <div class="columnDiv elementDiv">
            <p>Event Type:</p>
            <p>Swim:</p>
            <p>Cycle:</p>
            <p>Run:</p>
        </div>
        <div class="columnDiv elementDiv">
            <p>
                <select id="eventTypeSelect" runat="server" />
            <p>
                <input type="text" id="swimTimeInput" runat="server" placeholder="00:35:33" />
            </p>
            <p>
                <input type="text" id="cycleTimeInput" runat="server" placeholder="00:35:57" />
            </p>
            <p>
                <input type="text" id="runTimeInput" runat="server" placeholder="00:21:20" />
            </p>
        </div>
    </div>
    <div class="clear" style="text-align: center">
        <p>
           <input type="submit" value="Add" />
        </p>
    </div>
</asp:Content>
