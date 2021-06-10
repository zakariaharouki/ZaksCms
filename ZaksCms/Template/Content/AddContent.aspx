<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="ZaksCms.UserControl.Template.Content.AddContent" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <div class="page-content-wrapper ">

            <div class="container-fluid">

               
                <!-- end page title end breadcrumb -->

                <div class="row">
                    <div class="col-12">
                        <div class="card m-b-30">
                            <div class="card-body">
                                <div class="row">
                                <div class="col-2" style="margin-left:12px">
                                    <label class="font-weight-bold">Date</label>
                                </div>
                                    </div>
                                <div class="row">
                                    <div class="col-5" style="margin-left:12px">
                                        <asp:TextBox runat="server" ID="PublishedDate" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                <div class="form-check-group col-5">
                                    <label class="col-sm-12 font-weight-bold">Title</label> 
                                </div>
                                    <div class="col-2">
                                        <label class="col-sm-12 font-weight-bold">SubTitle</label>
                                    </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-5" style="margin-left:12px">
                                     <asp:TextBox runat="server" ID="txtContentTitle" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                        <div class="col-5">
                                             <asp:TextBox runat="server" ID="txtContentSubTitle" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                <br />
                               <div class="row">
                                    <div class="form-check-group col-5" style="margin-left:12px">
                                    <label class="font-weight-bold" >Menu</label> 
                                </div>
                                   <div class="col-4">
                                              <label class=" font-weight-bold" >Album</label> 
                                   </div>
                                </div>
                                <div class="row">
                                    <div class="col-5" style="margin-left:12px;">
                                          <asp:DropDownList ID="ddlMenuID" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-5">
                                        <asp:DropDownList ID="ddlAlbumID" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                 <div class="row">
                                    <div class="form-check-group col-5" style="margin-left:12px">
                                    <label class=" font-weight-bold" >Author</label> 
                                </div>
                                    <div class=" col-4">
                                    <label class="font-weight-bold" >Category</label> 
                                        </div>
                                </div>
                                <div class="row">
                                    <div class="col-5" style="margin-left:12px">
                                        <asp:DropDownList ID="ddlAuthorID" runat="server" CssClass="form-control"></asp:DropDownList>
                                      </div>
                                    <div class="col-5">
                                        <asp:DropDownList ID="ddlCategoryID" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                                <div class="form-group col-5" style="margin-left:12px">
                                                <label  class="font-weight-bold">Start Date & Time</label>
                                            </div>                                        
                                        <div class="col-4">
                                            <label class="col-sm-12 font-weight-bold">End Date & Time</label>
                                        </div>
                                        </div>
                                <div class="row">
                                    <div class="col-5" style="margin-left:12px">
                                                    <asp:TextBox ID="txtStartDateTime" runat="server" TextMode="DateTimeLocal" CssClass="form-control"></asp:TextBox>
                                                </div>      
                                    <div class="col-5">
                                                <asp:TextBox ID="txtEndDateTime" runat="server" TextMode="DateTimeLocal" CssClass="form-control"></asp:TextBox>
                                             
                                            </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="form-group col-4">
                                            <label class="font-weight-bold">Image 1</label>
                                            
                                        </div>
                                   <div class="form-group col-4">
                                            <label  class="font-weight-bold">Image 2</label>
                                       
                                        </div>
                                    <div class="form-group col-4">
                                            <label class="font-weight-bold">Image 3</label>
                                        
                                        </div>
                                </div>
                                <div class="row">
                                    <div class="col-4">
                                                <asp:FileUpload ID="FileUploadContentImage1" runat="server" CssClass="form-control" />
                                                <asp:Label ID="lblFileUploadContentImage1" runat="server"></asp:Label>
                                                <asp:Label ID="lblFileUploadContentImagePath1" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-4">
                                                <asp:FileUpload ID="FileUploadContentImage2" runat="server" CssClass="form-control"/>
                                                <asp:Label ID="lblFileUploadContentImage2" runat="server"></asp:Label>
                                                <asp:Label ID="lblFileUploadContentImagePath2" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-4">
                                                <asp:FileUpload ID="FileUploadContentImage3" runat="server" CssClass="form-control" />
                                                <asp:Label ID="lblFileUploadContentImage3" runat="server"></asp:Label>
                                                <asp:Label ID="lblFileUploadContentImagePath3" runat="server"></asp:Label>
                                            </div>
                                </div>
                                <div class="row">
                                     <div class="form-group col-4" style="margin-left:12px">
                                            <label class="font-weight-bold">Cover Image</label>
                                           </div>
                                    <div class="col-4">
                                        <label class="font-weight-bold">Content Zone</label>
                                    </div>
                                    </div>
                                <div class="row">
                                     <div class="col-4" style="margin-left:12px">
                                                <asp:FileUpload ID="FileUploadContentCoverImage" runat="server" CssClass="form-control" />
                                                <asp:Label ID="lblFileUploadContentCoverImage" runat="server"></asp:Label>
                                                <asp:Label ID="lblFileUploadContentCoverImagePath" runat="server"></asp:Label>
                                            </div>
                                    <div class="col-4">
                                        <asp:DropDownList runat="server" ID="ZonesDropdown"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-4">
                                            <label class="col-sm-12 font-weight-bold">Text(1)</label>
                                            <div class="col-sm-12">
                                                <asp:TextBox ID="txtCustomText1" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    <div class="form-group col-4">
                                            <label class="col-sm-12 font-weight-bold">Text(2)</label>
                                            <div class="col-sm-12">
                                                <asp:TextBox ID="txtCustomText2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    <div class="form-group col-4">
                                            <label class="col-sm-12 font-weight-bold">Text(3)</label>
                                            <div class="col-sm-12">
                                                <asp:TextBox ID="txtCustomText3" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                </div>
                                <div class="form-group col">
                                    <label class="col-sm-2 font-weight-bold">Description</label>
                                    <div class="col-sm-12">
                                      <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Columns="60" Rows="10" class="ckeditor"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-6">
                                        <label  class="col-sm-5 font-weight-bold">Meta Title</label>
                                        <div class="col-sm-12">
                                           <asp:TextBox runat="server" ID="txtMetaTitle" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group col-6">
                                        <label class="col-sm-5 font-weight-bold">Meta Keyword</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox runat="server" ID="txtMetaKeyword" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                               </div>
                                <br />
                                <div class="form-group col">
                                    <label class="col-sm-2 font-weight-bold">Meta Description</label>
                                    <div class="col-sm-12">
                                        <asp:TextBox ID="MetaDescription" runat="server" TextMode="MultiLine" Columns="60" Rows="10" class="ckeditor"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="form-check-group col-6">
                                    <label class="col-sm-12 font-weight-bold" >Language</label> 
                                    <div class="col-sm-12">
                                        <asp:DropDownList ID="ddlLanguageID" runat="server" CssClass="form-control"></asp:DropDownList>

                                    </div>
                                </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="form-group col-6">
                                        <label class="col-sm-12 font-weight-bold">Summary</label>
                                        <div class="col-sm-12">
                                            <asp:TextBox runat="server" ID="txtSummary" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-6">
                                    <label  class="col-sm-12 font-weight-bold">Published?</label>
                                    <div class="col-sm-12">
                                        <asp:CheckBox ID="chkPublished" runat="server" />
                                    </div>
                                </div>
                                </div>
                                <div class="form-group row col-2">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit_Click" CssClass="btn-primary form-control" />
                                </div>
              
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
         </div>
</asp:Content>
