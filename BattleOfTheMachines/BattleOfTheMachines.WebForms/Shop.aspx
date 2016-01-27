<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Shop" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p class="text-danger">
        <h2 class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" /></h2>
    </p>

    <div class="well well-sm"><strong>My money: </strong><span runat="server" id="money"></span></div>

    <asp:Button Text="Processors" BorderStyle="None" ID="ProcessorsTab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="0" />
    <asp:Button Text="Rams" BorderStyle="None" ID="RamsTab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="1" />
    <asp:Button Text="Networks" BorderStyle="None" ID="Networkstab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="2" />
    <asp:Button Text="Graphic Cards" BorderStyle="None" ID="GraphicCardsTab" CssClass="Initial" runat="server" OnCommand="TabCommand" CommandArgument="3" />

    <asp:MultiView ID="Multiview1" runat="server" ActiveViewIndex="0">
        <asp:View ID="processorsView" runat="server">
            <div class="panel text-center">
                <h2>Processors</h2>
            </div>

            <asp:GridView runat="server" ID="processorsGrid"
                ItemType="BattleOfTheMachines.WebForms.Models.CpuViewModel" DataKeyNames="Id"
                SelectMethod="ProcessorsGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped">
                <Columns>
                    <asp:DynamicField DataField="Cores" />
                    <asp:DynamicField DataField="CoreSpeed" />
                    <asp:DynamicField DataField="Model" />
                    <asp:DynamicField DataField="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-success" runat="server" OnCommand="BuyCommand" CommandArgument='<%# "Processor%" + Item.Id + "%" + Item.Price %>' Text="BUY" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>
        <asp:View ID="ramsView" runat="server">
            <div class="panel  text-center">
                <h2>Rams</h2>
            </div>

            <asp:GridView runat="server" ID="ramsGrid"
                ItemType="BattleOfTheMachines.WebForms.Models.RamViewModel" DataKeyNames="Id"
                SelectMethod="RamsGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped">
                <Columns>
                    <asp:DynamicField DataField="Memory" />
                    <asp:DynamicField DataField="MemorySpeed" />
                    <asp:DynamicField DataField="Model" />
                    <asp:DynamicField DataField="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-success" runat="server" OnCommand="BuyCommand" CommandArgument='<%# "Ram%" + Item.Id + "%" + Item.Price %>' Text="BUY" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>
        <asp:View ID="networksView" runat="server">
            <div class="panel  text-center">
                <h2>Networks</h2>
            </div>

            <asp:GridView runat="server" ID="networksGrid"
                ItemType="BattleOfTheMachines.WebForms.Models.NetworkViewModel" DataKeyNames="Id"
                SelectMethod="NetworksGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped">
                <Columns>
                    <asp:DynamicField DataField="Type" />
                    <asp:DynamicField DataField="Speed" />
                    <asp:DynamicField DataField="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-success" runat="server" OnCommand="BuyCommand" CommandArgument='<%# "Network%" + Item.Id + "%" + Item.Price %>' Text="BUY" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>
        <asp:View ID="graphicsView" runat="server">
            <div class="panel  text-center">
                <h2>Graphics</h2>
            </div>

            <asp:GridView runat="server" ID="graphicsGrid"
                ItemType="BattleOfTheMachines.WebForms.Models.GraphicsViewModel" DataKeyNames="Id"
                SelectMethod="GraphicsGrid_GetData"
                AllowSorting="True"
                AllowPaging="True"
                AutoGenerateColumns="False"
                PageSize="10"
                CssClass="table table-hover table-striped">
                <Columns>
                    <asp:DynamicField DataField="Model" />
                    <asp:DynamicField DataField="Cores" />
                    <asp:DynamicField DataField="CoreSpeed" />
                    <asp:DynamicField DataField="VideoMemory" />
                    <asp:DynamicField DataField="Price" />                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-success" runat="server" OnCommand="BuyCommand" CommandArgument='<%# "Graphics%" + Item.Id + "%" + Item.Price %>' Text="BUY" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerSettings Mode="NumericFirstLast"></PagerSettings>

            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
