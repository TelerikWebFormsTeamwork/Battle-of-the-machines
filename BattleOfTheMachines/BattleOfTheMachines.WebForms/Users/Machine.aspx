<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Machine.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Users.Machine" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <% if (!this.HasMachine)
       {
        %>
           <h1>Your MachineKey's dead. Sorry! :(</h1>
       <%} else { %>

    <table>
        <tr>
            <td><asp:Image runat="server" Width="100px" Height="100px" ID="processor"/></td>
            <td rowspan="2"><asp:Image runat="server" Height="400px" ImageUrl="~/Images/machine.png"/></td>
            <td><asp:Image runat="server" Width="100px" Height="100px" ID="network"/></td>
        </tr>
        <tr>
            <td><asp:Image runat="server" Width="100px" Height="100px" ID="ram"/></td>
            <td><asp:Image runat="server" Width="100px" Height="100px" ID="graphics"/></td>
        </tr>
    </table>

    <% } %>
      
</asp:Content>