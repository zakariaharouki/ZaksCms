<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ZaksCms.UserControl.Template.User.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>Register User</h1>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-2">
                <label>Firstname</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Fnametxt" CssClass=" form-control" placeholder="Firstname" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Lastname</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Lnametxt" CssClass="form-control" placeholder="Lastname" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Email</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Emailtxt" CssClass=" form-control" placeholder="Email" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Phone</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Phonetxt" CssClass=" form-control" placeholder="Phone" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Password</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Passtxt" TextMode="Password" CssClass=" form-control" placeholder="Password" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Confirm Password</label>
            </div>
            <div class="col-3">
                <input runat="server" ID="Cpasstxt" class=" form-control" placeholder="Confirm Password" type="password" onkeyup="passvalidate()"/>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2"></div>
            <div class="col-3">
                <asp:Button runat="server" ID="AddUserbtn" CssClass="btn btn-dark" Text="Register" OnClick="AddUserbtn_Click" />
            </div>
            <label id="message"></label>

        </div>
    </div>
    <script>
        function passvalidate() {
            if (document.getElementById('<%=Passtxt.ClientID%>').value ==
                document.getElementById('<%=Cpasstxt.ClientID%>').value) {
                document.getElementById('message').style.color = 'green';
                document.getElementById('<%=Cpasstxt.ClientID%>').style.borderColor = 'green';
                document.getElementById('message').innerHTML = 'matching';
                var btn = document.getElementById("<%=AddUserbtn.ClientID%>");
                btn.disabled = false;
                <%--document.getEelementById('<%=saveResto.ClientID%>').disabled = false;--%>

            } else {
                document.getElementById('message').style.color = 'red';
                document.getElementById('<%=Cpasstxt.ClientID%>').style.borderColor = 'red';
                document.getElementById('message').innerHTML = 'not matching';
                var btn = document.getElementById("<%=AddUserbtn.ClientID%>");
                btn.disabled = true;
                <%--document.getEelementById('<%=saveResto.ClientID%>').disabled = true;--%>
            }
        }
    </script>
</asp:Content>
