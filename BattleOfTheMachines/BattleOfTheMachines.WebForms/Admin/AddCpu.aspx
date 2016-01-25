<%@ Page Title="Add cpu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCpu.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Admin.AddCpu" %>

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
                        <legend>Create a new CPU component</legend>
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="model" CssClass="col-md-2 control-label">Model</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="model" CssClass="form-control" Placeholder="Model"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="model"
                                    CssClass="text-danger" ErrorMessage="The model field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="cores" class="col-md-2 control-label">Cores</label>
                            <div class="col-md-10">
                                <input type="number" class="form-control" id="cores" runat="server" min="0" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="coreSpeed" class="col-md-2 control-label">Core speed</label>
                            <div class="col-md-10">
                                <input type="number" class="form-control" id="coreSpeed" runat="server" step="any" min="0" required>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="cpuImage" CssClass="col-md-2 control-label">Image</asp:Label>
                            <div class="col-md-10">
                                <input type="text" readonly="" class="form-control" placeholder="Browse...">
                                <asp:FileUpload runat="server" ID="cpuImage"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-2">
                                <asp:Button Text="Add" runat="server" OnClick="AddCpu_Click" CssClass="btn btn-primary"/>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
