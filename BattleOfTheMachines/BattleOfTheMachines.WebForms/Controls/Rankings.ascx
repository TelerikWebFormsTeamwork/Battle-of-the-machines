<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Rankings.ascx.cs" Inherits="BattleOfTheMachines.WebForms.Controls.Rankings" %>
<%@ OutputCache Duration="300" VaryByParam="None" %>

<div class="col-lg-6 col-lg-offset-3">
    <h1 class="text-center">Top Machines</h1>
    <hr />
    <div class="list-group">
        <asp:ListView runat="server" ItemType="BattleOfTheMachines.Data.Models.Motherboard" SelectMethod="GetTopMachines">
            <ItemTemplate>
                <div class="list-group-item">
                    <div class="row-picture">
                        <img class="circle" src="../Images/<%# ((ListViewDataItem)Container).DisplayIndex + 1 %>.jpg" alt="icon">
                    </div>
                    <div class="row-content">
                        <div class="least-content"><span class="label label-info">Power: <%# Item.Processor.Power + Item.GraphicsCard.Power + Item.Network.Power + Item.Ram.Power %></span></div>
                        <h4 class="list-group-item-heading"><%# Item.Name %></h4>

                        <p class="list-group-item-text">
                            <b>Processor: </b><%# Item.Processor.Model %>
                            <br />
                            <b>Graphics Card: </b><%# Item.GraphicsCard.Model %>
                            <br />
                            <b>Network: </b><%# Item.Network.Type %>
                            <br />
                            <b>RAM: </b><%# Item.Ram.Model %>
                            <br />
                        </p>
                    </div>
                </div>
                <div class="list-group-separator"></div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
