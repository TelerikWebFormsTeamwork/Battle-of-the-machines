<%@ Page Title="Quest Details" Language="C#" MasterPageFile="~/Admin/Admin.master" CodeBehind="Details.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Admin.Quests.Details" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="col-md-6">
            <p>&nbsp;</p>

            <asp:FormView runat="server"
                ItemType="BattleOfTheMachines.Data.Models.Quest" DataKeyNames="Id"
                SelectMethod="GetItem"
                OnItemCommand="ItemCommand" RenderOuterTable="false">
                <EmptyDataTemplate>
                    Cannot find the Quest with Id <%: Request.QueryString["Id"] %>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <fieldset class="form-horizontal">
                        <legend>Quest Details</legend>
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
                                <strong>Name</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Name" ID="Name" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>Description</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Description" ID="Description" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>DurationInMinutes</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="DurationInMinutes" ID="DurationInMinutes" Mode="ReadOnly" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2 text-right">
                                <strong>Specialization</strong>
                            </div>
                            <div class="col-sm-4">
                                <asp:DynamicControl runat="server" DataField="Specialization" ID="Specialization" Mode="ReadOnly" />
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

