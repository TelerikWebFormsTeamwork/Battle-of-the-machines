<%@ Page Title="Add quest" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Admin.Quests.Insert" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="row">
        <div class="col-md-6">
            <div class="well bs-component">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Create a new quest</legend>
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="name" CssClass="col-md-2 control-label">Name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="name" CssClass="form-control" Placeholder="Name"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="name"
                                    CssClass="text-danger" ErrorMessage="The name field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="description" class="col-md-2 control-label">Description</label>
                            <div class="col-md-10">
                                <textarea class="form-control" rows="3" id="description" runat="server"></textarea>
                                <span class="help-block">Enter some cool description so users are not bored while doing the quest ;)</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="duration" class="col-md-2 control-label">Duration</label>
                            <div class="col-md-10">
                                <input type="number" class="form-control" id="duration" runat="server" min="0" Placeholder="Duration" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="partType" CssClass="col-md-2 control-label">Type</asp:Label>
                            <div class="col-md-10">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="partType">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="questImage" CssClass="col-md-2 control-label">Image</asp:Label>
                            <div class="col-md-10">
                                <input type="text" readonly="" class="form-control" placeholder="Browse...">
                                <asp:FileUpload runat="server" ID="questImage"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                                    ControlToValidate="questImage" ErrorMessage="File Required!">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-2">
                                <asp:Button Text="Add" runat="server" OnClick="AddQuest_Click" CssClass="btn btn-primary"/>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
