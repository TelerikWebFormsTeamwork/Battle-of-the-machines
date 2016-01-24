<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Machine.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Users.Machine" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image runat="server" Width="200px" Height="200px" ID="processor"/>
    <asp:Image runat="server" Width="200px" Height="200px" ID="network"/>
    <asp:Image runat="server" Width="200px" Height="200px" ID="ram"/>
    <asp:Image runat="server" Width="200px" Height="200px" ID="graphics"/>
</asp:Content>