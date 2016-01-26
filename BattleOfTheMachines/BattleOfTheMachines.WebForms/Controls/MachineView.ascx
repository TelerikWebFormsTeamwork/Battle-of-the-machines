<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachineView.ascx.cs" Inherits="BattleOfTheMachines.WebForms.Controls.MachineView" %>

<% if (!this.HasMachine)
    {
%>
<h1>Your Machine's dead. Sorry! :(</h1>
<%}
    else { %>
<div class="container">

    <div class="panel text-center">
        <h1 id="machineName" runat="server"></h1>
    </div>
    <div class="col-md-7">
        <table class="machine-table">
            <tr>
                <td>
                    <asp:Image runat="server" Width="100px" Height="100px" ID="processor" /></td>
                <td rowspan="2">
                    <asp:Image runat="server" Height="400px" ImageUrl="~/Images/machine.png" /></td>
                <td>
                    <asp:Image runat="server" Width="100px" Height="100px" ID="network" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Image runat="server" Width="100px" Height="100px" ID="ram" /></td>
                <td>
                    <asp:Image runat="server" Width="100px" Height="100px" ID="graphics" /></td>
            </tr>
        </table>
    </div>
    <div class="col-md-5 pull-right">
        <asp:HyperLink runat="server" NavigateUrl="~/Shop.aspx" CssClass="btn btn-default" BackColor="#c0c0c0" Text="UPGRADE"></asp:HyperLink>
        <table class="machine-table table">
            <tr>
                <th>Item</th>
                <th>Model</th>
                <th>Power</th>
            </tr>
            <tr>
                <td><strong>Processor</strong></td>
                <td id="processorModel" runat="server"></td>
                <td id="processorPh" runat="server"></td>
            </tr>
            <tr>
                <td><strong>Ram</strong></td>
                <td id="ramModel" runat="server"></td>
                <td id="ramPh" runat="server"></td>
            </tr>
            <tr>
                <td><strong>Network</strong></td>
                <td id="networkModel" runat="server"></td>
                <td id="networkPh" runat="server"></td>
            </tr>
            <tr>
                <td><strong>Graphics</strong></td>
                <td id="graphicsModel" runat="server"></td>
                <td id="graphicsPh" runat="server"></td>
            </tr>
        </table>
    </div>
</div>
    <% } %>
