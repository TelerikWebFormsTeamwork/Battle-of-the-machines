<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Users.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <% if (User.Identity.IsAuthenticated)
           {
               Response.Write($"<h1>{this.User.Identity.GetUserId()}</h1>");
           }%>
</asp:Content>
