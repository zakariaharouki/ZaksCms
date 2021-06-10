<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZaksCms.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/css/bootstrap-grid.css" />
    <link rel="stylesheet" href="../assets/css/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/Site.css" />
</head>
<body>
    <div class="sidenav">
         <div class="login-main-text">
            <h2>Application<br/> Login Page</h2>
            <p>Login or register from here to access.</p>
         </div>
      </div>
  <div class="main">
    <form method="post" runat="server">
        <div class=" container">
            <div class=" row">
                <div class="col-2">
                    <label>Email</label>
                </div>
                <div class="col-4">
                    <asp:TextBox runat="server" placeholder="Email" ID="emailtxt" CssClass="form-control"/>
                </div>
            </div><br />
            <div class="row">
                <div class="col-2">
                    <label>Password</label>
                </div>
                <div class="col-4">
                    <asp:TextBox runat="server" ID="txtPassword" placeholder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
            </div><br />
            <div class="row">
                <div class="col-2"></div>
                <div class="col-2">
                    <asp:Button runat="server" ID="loginbtn" OnClick="loginbtn_Click" CssClass="btn btn-dark" Text="Login"/>
                </div>
                <div class="col-2">
                        <asp:Button runat="server" ID="Registerbtn" OnClick="Registerbtn_Click" CssClass="btn btn-outline-success" Text="Register"/>
                
                </div>
            </div>
        </div>
    </form>
      </div>
</body>
</html>