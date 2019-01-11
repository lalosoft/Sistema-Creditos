<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CreditosDelta.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Creditos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <link href="img/logo_alien.ico" rel="shortcut icon" />

    <!-- Bootstrao core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet" />
</head>
<body class="bg-dark">
    <div class="container">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">Acceso Sistema</div>
            <div class="card-body">
                <form id="form1" runat="server">
                        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
                            <LayoutTemplate>
                                <div class="form-group">
                                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Usuario" required="required" autofocus="autofocus"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            <asp:Button ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary btn-block" runat="server" CommandName="Login"/>
                        </LayoutTemplate>
                    </asp:Login>
                </form>
                <div class="text-center">

                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
</body>
</html>