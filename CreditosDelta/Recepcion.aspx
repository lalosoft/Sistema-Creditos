<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Recepcion.aspx.cs" Inherits="CreditosDelta.Recepcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Recepcion</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Inicio.aspx">Inicio</a>
        </li>
        <li class="breadcrumb-item active">Registro de Crédito</li>
    </ol>

    <h1>Registro de Crédito</h1>
    <hr />

    <div class="container">
        <div class="card card-register mx-auto mt-5 bg-info">
            <div class="card-header" style="color:white;">Nuevo Crédito</div>
                <div class="card-body">
                    <section>
                        <div class="form-group">
                            <label style="color: #fff">Fecha</label>
                            <div class="form-group">
                                <input type="text" class="form-control" id="txtFecha" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label style="color: #fff">Clave Cliente</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtClaveCte" CssClass="form-control" runat="server" required="required" autofocus="autofocus" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label style="color: #fff">Qué Solicita??</label>
                            <asp:DropDownList ID="listSolicitaCte" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Selected="True">Seleccione Uno</asp:ListItem>
                                <asp:ListItem Value="Credito">Credito</asp:ListItem>
                                <asp:ListItem Value="Activacion Cuenta">Activación de Cuenta</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label style="color: #fff">Pago Cliente</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtPago" CssClass="form-control" runat="server" required="required" autofocus="autofocus" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label style="color: #fff">Total Pedido</label>
                            <div class="form-group">
                                <asp:TextBox ID="txtMontoPed" CssClass="form-control" runat="server" required="required" autofocus="autofocus" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-danger btn-block" OnClick="btnGuardar_Click" />
                    </section>
                </div>
            </div>
            <hr />
            
            <div class="card-body">
            <div class="table-responsive">
                <table id="tbl_creditos" class="table table-bordered" widht="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Fecha Registro</th>
                            <th>Cliente</th>
                            <th>Que Solicita??</th>
                            <th>Pago Cliente</th>
                            <th>Total Pedido</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>ID</th>
                            <th>Fecha Registro</th>
                            <th>Cliente</th>
                            <th>Que Solicita??</th>
                            <th>Pago Cliente</th>
                            <th>Total Pedido</th>
                            <th>Status</th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <!-- llenado con ajax -->
                    </tbody>
                </table>
            </div>
        </div>
        <div class="card-footer small text-muted">
            <asp:Label ID="lblFchRecep" runat="server"></asp:Label>
        </div>  

        </div>

    <script>
        var myVar = setInterval(myTimer, 1000);

        function myTimer()
        {
            var d = new Date();
            document.getElementById("txtFecha").value = d.getDate() + '/' + (d.getMonth() + 1).toString() + '/' + d.getFullYear() + ' ' + d.toLocaleTimeString();
        }
    </script>
</asp:Content>