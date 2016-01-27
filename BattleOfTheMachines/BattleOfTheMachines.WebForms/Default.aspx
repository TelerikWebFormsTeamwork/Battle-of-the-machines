<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BattleOfTheMachines.WebForms._Default" %>

<%@ OutputCache VaryByParam="None" Duration="300" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Battle of the Machines</h1>
        <p class="lead">Lead your PC to glory! Start from scrap and make it the most powerful computer out there. Do quests, buy parts or clock the current to achieve the unthinkable.</p>
        <p><a href="~/Users/Machine" class="btn btn-primary btn-lg" runat="server">Start battle now</a></p>
    </div>
    <div class="row">
        <btm:Rankings runat="server" />
    </div>
   
</asp:Content>
