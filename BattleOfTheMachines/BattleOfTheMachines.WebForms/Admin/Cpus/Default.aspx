<%@ Page Title="CpuList" Language="C#" MasterPageFile="~/Admin/Admin.master" CodeBehind="Default.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Admin.Cpus.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Cpus List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" CssClass="btn btn-raised btn-primary btn-lg"/>
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="Id" 
			ItemType="BattleOfTheMachines.Data.Models.Cpu"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Cpus
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="Id" CommandName="Sort" CommandArgument="Id" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Model" CommandName="Sort" CommandArgument="Model" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="CoreSpeed" CommandName="Sort" CommandArgument="CoreSpeed" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Cores" CommandName="Sort" CommandArgument="Cores" runat="Server" />
							</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
				<asp:DataPager PageSize="5"  runat="server">
					<Fields>
                        <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                        <asp:NumericPagerField ButtonType="Button"  NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                    </Fields>
				</asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
							<td>
								<asp:DynamicControl runat="server" DataField="Id" ID="Id" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Model" ID="Model" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="CoreSpeed" ID="CoreSpeed" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Cores" ID="Cores" Mode="ReadOnly" />
							</td>
                    <td>
                        <btm:dropdownMenu runat="server" UnitId="<%# Item.Id %>" UnitType="Cpus"/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

