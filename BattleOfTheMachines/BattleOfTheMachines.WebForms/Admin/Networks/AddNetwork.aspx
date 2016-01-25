<%@ Page Title="Add Network" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNetwork.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Admin.Networks.AddNetwork" %>

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
                        <legend>Create a new Network component</legend>
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="type" CssClass="col-md-2 control-label">Type</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="type" CssClass="form-control" Placeholder="Type"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="type"
                                    CssClass="text-danger" ErrorMessage="The type field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="speed" class="col-md-2 control-label">Speed</label>
                            <div class="col-md-10">
                                <input type="number" class="form-control" id="speed" runat="server" min="0" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="networkImage" CssClass="col-md-2 control-label">Image</asp:Label>
                            <div class="col-md-10">
                                <input type="text" readonly="" class="form-control" placeholder="Browse...">
                                <asp:FileUpload runat="server" ID="networkImage"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                                    ControlToValidate="networkImage" ErrorMessage="File Required!">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-2">
                                <asp:Button Text="Add" runat="server" OnClick="AddNetwork_Click" CssClass="btn btn-primary"/>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
