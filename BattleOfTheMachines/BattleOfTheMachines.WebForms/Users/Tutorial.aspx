<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Users.Tutorial" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    

    <h1>Tutorial</h1>
            <% if (User.Identity.IsAuthenticated)
           {
               Response.Write($"<h3>{this.User.Identity.GetUserId()}</h3>");
           }%>
</asp:Content>

