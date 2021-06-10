<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditZones.aspx.cs" Inherits="ZaksCms.Template.Zones.EditZones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Edit Zone</h1>
    <hr />
    <div class="row">
        <div class="col-2">
            <label class="h4" style="font-family:Helvetica">Zone Name</label>
        </div>
        <div class="col-4">
            <asp:TextBox runat="server" placeholder="Zonename" ID="zonenametxt" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <asp:Button runat="server" ID="EditZonebtn" OnClick="EditZonebtn_Click" CssClass="btn btn-dark" Text="Edit Zone" />
    </div>
</asp:Content>
