﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropdownMenu.ascx.cs" Inherits="BattleOfTheMachines.WebForms.Controls.DropdownMenu" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<div class="btn-group">
    <asp:HyperLink runat="server" CssClass="btn" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/" + UnitType + "/Details", UnitId) %>' Text="Details" />
    <a href="bootstrap-elements.html" data-target="#" class="btn dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></a>
    <ul class="dropdown-menu">
        <li><asp:HyperLink runat="server" CssClass="btn" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/" + UnitType + "/Edit", UnitId) %>' Text="Edit" /></li>
        <li><asp:HyperLink runat="server" CssClass="btn" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/" + UnitType + "/Delete", UnitId) %>' Text="Delete" /></li>
    </ul>
</div>
