<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="BattleOfTheMachines.WebForms.Users.Tutorial" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new machine</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MachineName" CssClass="col-md-2 control-label">MachineName</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MachineName" CssClass="form-control" />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="OnClick" Text="Create new machine" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

