<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListZones.aspx.cs" Inherits="ZaksCms.Template.Zones.ListZones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
        <div class="page-content-wrapper ">
            <div class="row">
                <div class="col-sm-12">
                    <div class="page-title-box">
                        <div class="row">
                            <div class="form-group col-6">
                                <h4 class="page-title">List Widget</h4>
                            </div>
                            <div class="form-group col-6">
                                <li>
                                    <a href="/AddZone" class="waves-effect">
                                        <span><h4 class="page-title">Add Zone</h4></span>
                                    </a>
                                </li>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 col-sm-12">
                        <div class="card m-b-30">
                            <div class="card-body table-responsive">

                                <div class="">
                                    <table id="datatable" class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Zonename</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptZones" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("ZoneID")%></td>
                                                        <td><%#Eval("ZoneName")%></td>
                                                        <td>
                                                            <div class="input-group-append">
                                                                <button type="button" class="btn btn-primary dropdown-toggle dropdown-toggle-split" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                    <span class="sr-only">Toggle Dropdown</span>
                                                                    Actions
                                                                </button>
                                                                <div class="dropdown-menu">
                                                                    <li>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="dropdown-item" CommandArgument='<%#Eval("ZoneID") %>' OnClick="btnEdit_Click">Edit</asp:LinkButton></li>
                                                                    <li>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="dropdown-item" CommandArgument='<%#Eval("ZoneID") %>' OnClick="btnDelete_Click">Delete</asp:LinkButton></li>

                                                                </div>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>


                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- container -->

                </div>
            </div>
        </div>
    </div>
</asp:Content>
