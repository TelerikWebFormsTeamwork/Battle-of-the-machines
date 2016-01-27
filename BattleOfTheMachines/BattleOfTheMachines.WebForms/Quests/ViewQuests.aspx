<%@ Page Title="View All Quests" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewQuests.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Quests.ViewQuests" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %>, based on their focus.</h3>
    <asp:UpdatePanel ID="TimerPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Timer ID="QuestTimer" Interval="30100" OnTick="QuestTimer_Tick" runat="server" />
            <h2 class="container">
                <asp:Label ID="TimerLabel" CssClass="col-md-7" runat="server" Visible="true" />
                <img id="TimerImage" src="/Images/loading-gears-animation.gif" alt="Quest in progress" runat="server" visible="false" class="pull-right" />
                <asp:Button ID="QuestRewardButton" Text="Get your reward" runat="server" Visible="false" CssClass="btn btn-success" OnClick="QuestRewardButton_Click" />
            </h2>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button Text="Processors" BorderStyle="None" ID="ProcessorsTab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="0" />
    <asp:Button Text="Rams" BorderStyle="None" ID="RamsTab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="1" />
    <asp:Button Text="Networks" BorderStyle="None" ID="Networkstab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="2" />
    <asp:Button Text="Graphic Cards" BorderStyle="None" ID="GraphicCardsTab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="3" />


    <asp:MultiView ID="Multiview1" runat="server" ActiveViewIndex="0">
        <asp:View ID="processorsView" runat="server">
            <div class="panel text-center">
                <h2>Quests, straining the CPU</h2>
            </div>
            <asp:GridView runat="server" ID="processorsQuestGrid"
                ItemType="BattleOfTheMachines.Data.Models.Quest"
                SelectMethod="processorsQuestGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped"
                OnRowCommand="processorsQuestGrid_RowCommand">
                <Columns>
                    <asp:DynamicField DataField="Name" />
                    <asp:DynamicField DataField="Description" />
                    <asp:DynamicField DataField="DurationInMinutes" HeaderText="Duration (in minutes)" />
                    <asp:DynamicField DataField="PowerRequired" HeaderText="Required PC Power" />
                    <asp:ButtonField HeaderText="Start task" ButtonType="Button" Text="Do it!" ControlStyle-CssClass="btn btn-success" />
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>
        <asp:View ID="ramView" runat="server">
            <div class="panel text-center">
                <h2>Quests, straining the RAM</h2>
            </div>
            <asp:GridView runat="server" ID="ramQuestGrid"
                ItemType="BattleOfTheMachines.Data.Models.Quest"
                SelectMethod="ramQuestGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped"
                OnRowCommand="ramQuestGrid_RowCommand">
                <Columns>
                    <asp:DynamicField DataField="Name" />
                    <asp:DynamicField DataField="Description" />
                    <asp:DynamicField DataField="DurationInMinutes" HeaderText="Duration (in minutes)" />
                    <asp:DynamicField DataField="PowerRequired" HeaderText="Required PC Power" />
                    <asp:ButtonField HeaderText="Start task" ButtonType="Button" Text="Do it!" ControlStyle-CssClass="btn btn-success" />
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>

        <asp:View ID="graphicsCardView" runat="server">
            <div class="panel text-center">
                <h2>Quests, straining the Graphics Card</h2>
            </div>
            <asp:GridView runat="server" ID="graphicsCardQuestGrid"
                ItemType="BattleOfTheMachines.Data.Models.Quest"
                SelectMethod="graphicsCardQuestGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped"
                OnRowCommand="graphicsCardQuestGrid_RowCommand">
                <Columns>
                    <asp:DynamicField DataField="Name" />
                    <asp:DynamicField DataField="Description" />
                    <asp:DynamicField DataField="DurationInMinutes" HeaderText="Duration (in minutes)" />
                    <asp:DynamicField DataField="PowerRequired" HeaderText="Required PC Power" />
                    <asp:ButtonField HeaderText="Start task" ButtonType="Button" Text="Do it!" ControlStyle-CssClass="btn btn-success" />
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>

        <asp:View ID="networkView" runat="server">
            <div class="panel text-center">
                <h2>Quests, straining the Network</h2>
            </div>
            <asp:GridView runat="server" ID="networkQuestGrid"
                ItemType="BattleOfTheMachines.Data.Models.Quest"
                SelectMethod="networkQuestGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped"
                OnRowCommand="networkQuestGrid_RowCommand1">
                <Columns>
                    <asp:DynamicField DataField="Name" />
                    <asp:DynamicField DataField="Description" />
                    <asp:DynamicField DataField="DurationInMinutes" HeaderText="Duration (in minutes)" />
                    <asp:DynamicField DataField="PowerRequired" HeaderText="Required PC Power" />
                    <asp:ButtonField HeaderText="Start task" ButtonType="Button" Text="Do it!" ControlStyle-CssClass="btn btn-success" />
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>

