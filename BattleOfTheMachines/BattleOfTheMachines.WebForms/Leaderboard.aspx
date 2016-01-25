<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Leaderboard" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="LeaderboardView"
        SelectMethod="Leaderboard_GetData"
        ItemType="BattleOfTheMachines.Data.Models.ViewModels.Leader"
        DataKeyNames="Name"
        AllowPaging="True" AllowSorting="True"
        PageSize="50"
        AutoGenerateColumns="false">
        <LayoutTemplate>
            <div class="sort-link">
                <asp:LinkButton runat="server" ID="SortByName" CommandName="Sort" CssClass="btn btn-sm btn-primary" CommandArgument="Name">Sort by Name</asp:LinkButton>
                <asp:LinkButton runat="server" ID="SortByPosition" CommandName="Sort" CssClass="btn btn-sm btn-primary" CommandArgument="Position">Sort by Position</asp:LinkButton>
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <asp:Label runat="server"><%# Item.Name %></asp:Label>
                <asp:Label runat="server"><%# Item.Power %></asp:Label>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <h5 class="content-empty">No items available</h5>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPagerJokes" PagedControlID="LeaderboardView" PageSize="10" runat="server">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ButtonCssClass="btn btn-primary btn-xs" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" ButtonCssClass="btn btn-primary btn-xs" />
        </Fields>
    </asp:DataPager>
</asp:Content>