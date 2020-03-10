<%@ Page Title="Triathlon Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="StylingContent.EventList" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Styles/Page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('td a').addClass('tableLink').css('text-decoration', 'none');

            $('td').filter(function () {
                return $(this).text() == 1;
            }).css({ 'color': 'green', 'font-weight': 'bold' });

            /* Style the first row*/
            //$('tr:has(th)').css({ 'background-color': '#007F7F', 'color': '#ffffff' });
            $('tr').first().css({ 'background-color': '#007F7F', 'color': '#ffffff' });

            /* Style every other row that is even*/
            //$('tr:has(td):even').css('background-color', '#11B1B1');
            // $('tr:odd').css('background-color', '#11B1B1');

            /* respond to selections to filter the content and submit the form */
            $('#<%=eventSelector.ClientID%>').change(function () {
                //$('form').submit();

                // instead of sending the selectedOption to the server to do the filter, we do the filter on the client
                var selectedOption = $('#<%=eventSelector.ClientID%>').find('option:selected').text();
                if (selectedOption == 'All') {
                    // ensure all rows are visible
                    $('tr:has(td)').show();
                } else {
                    $('tr:has(td)').hide();
                    $("td:nth-child(3):contains('" + selectedOption + "')").parent().show();
                }
            });
            $('input:submit').hide();

            /* Convert all links in the page to buttons */

            /* var counter = 0;
            $('a').each(function () {
                var labelText = $(this).text();
                var targetURL = $(this).attr('href');
                var buttonID = 'newButton' + counter++;

                /* create the button */
               // $(this).replaceWith("<button id='" + buttonID + "'>" + labelText + "</button>");

                // select the newly created button and bind to it
               /* $('#' + buttonID).click(function () {
                    window.location = targetURL;
                    // we return false to stop the browser default handling of the event which is to submit the form. And also stop futher propagation of the event.
                    return false;
                })
             }); */

            // Highlight the row when the user hover with his mouse
            $('tr:has(td)').hover(
                function () {
                    $(this).find('td').css({ 'background-color': '#007F7F', 'color': '#ffffff', 'cursor': 'pointer' });
                },
                function () {
                    $(this).find('td').css({ 'background-color': '', 'color': '' });
                }
            ).click(function () {
                $(this).find('td button:contains("Edit")').click();
            });

            /* Converting a link to jQuery UI Button */
            $('a').button().css('color', '#ffffff');
            $('td a').css('font-size', 'smaller');

        /* Replace the select element with a combo box. This is powered by the combobox.js script*/
            // This is not working as expected
            //$("#<%=eventSelector.ClientID%>").combobox();
            //$("#comboBoxInput").css('height', $('#comboBoxButton').height() - 2).width('100px');


        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table id="resultsTable" runat="server" rules="cols">
        <tr>
            <th>Date</th>
            <th>Athlete</th>
            <th>Event Type</th>
            <th>Swim</th>            
            <th>Cycle</th>
            <th>Run</th>
            <th>Overall</th>
            <th>Rank</th>
            <th>Ref Rank</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
    </table>
    <div class="standardDiv">
        <label>Event Type:</label>
        <select id="eventSelector" runat="server">
            <option>All</option>
        </select>
    </div>

    <div class="standardDiv">
        <input type="submit" value="Submit" />
    </div>
    <div class="standardDiv">
        <a href="AddEvent.aspx">Add New Event</a>
    </div>
</asp:Content>
