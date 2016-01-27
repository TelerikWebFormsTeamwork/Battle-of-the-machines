<%@ Page Title="Cpu Details" Language="C#" MasterPageFile="~/Admin/Admin.master" CodeBehind="Details.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Admin.Cpus.Details" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="col-md-6">
            <p>&nbsp;</p>

            <asp:FormView runat="server"
                ItemType="BattleOfTheMachines.Data.Models.Cpu" DataKeyNames="Id"
                SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    Cannot find the Cpu with Id <%: Request.QueryString["Id"] %>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Cpu Details</legend>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>Id</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Id" ID="Id" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>Model</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Model" ID="Model" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>CoreSpeed</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="CoreSpeed" ID="CoreSpeed" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>Cores</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Cores" ID="Cores" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            &nbsp;
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Back" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </fieldset>
                </ItemTemplate>
            </asp:FormView>
        </div>
        <div class="col-md-6">
            <asp:Image runat="server" Width="100%" Height="100%" ID="cpu_image" />
        </div>
    </div>
</asp:Content>

