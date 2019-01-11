<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cobranza.aspx.cs" Inherits="CreditosDelta.Cobranza" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="300" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Inicio.aspx">Inicio</a>
        </li>
        <li class="breadcrumb-item active">Créditos</li>
    </ol>

    <h1>Créditos Actuales</h1>
    <hr>

    <div class="card mb-3">
        <div class="card-header">
            <i class="fas fa-table"></i>
            Creditos Delta
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table id="tbl_content" class="table table-bordered" widht="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Fecha Registro</th>
                            <th>Cliente</th>
                            <th>Que Solicita??</th>
                            <th>Pago Cliente</th>
                            <th>Total Pedido</th>
                            <th>Estatus Cobranza</th>
                            <th>Motivo</th>
                            <th>Autorizado</th>
                            <th>Estatus Vendedor</th>
                            <th>Fecha Autorizacion</th>
                             <th>Acción</th>
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
                            <th>Estatus Cobranza</!--th>
                            <th>Motivo</th>
                            <th>Autorizado</th>
                            <th>Estatus Vendedor</th>
                            <th>Fecha Autorizacion</th>
                            <th>Acción</th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <!-- llenado con ajax -->
                    </tbody>
                </table>
            </div>
        </div>
        <div class="card-footer small text-muted">
            <asp:Label ID="lblFecha" runat="server"></asp:Label>
        </div>
    </div>

    <!-- FORMULARIO MODAL -->
    <div class="modal fade" id="formModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modificar Crédito</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">x</span>
                    </button> 
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Credito</label>
                        <div class="form-group">
                            <asp:TextBox ID="txtIdCredito" CssClass="form-control" runat="server" Enabled="false" ForeColor="Blue"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Cliente</label>
                        <div class="form-group">
                            <asp:TextBox ID="txtCveCte" CssClass="form-control" runat="server" Enabled="false" ForeColor="Blue"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Status Cobranza</label>
                        <asp:DropDownList ID="listStatusCobranza" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Selected="True">Seleccione Uno</asp:ListItem>
                            <asp:ListItem Value="1">Aceptado</asp:ListItem>
                            <asp:ListItem Value="2">Pendiente</asp:ListItem>
                            <asp:ListItem Value="3">No Autorizado</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Motivo</label>
                        <div class="form-group">
                            <asp:TextBox ID="txtMotivo" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Quién Autoriza??</label>
                        <asp:DropDownList ID="listAutoriza" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Selected="True">Seleccione Uno</asp:ListItem>
                            <asp:ListItem Value="1">C.P. Gerardo</asp:ListItem>
                            <asp:ListItem Value="2">Holger</asp:ListItem>
                            <asp:ListItem Value="3">Sr. Martin</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Status Vendedor</label>
                        <asp:DropDownList ID="listStatusVend" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0" Selected="True">Seleccione Uno</asp:ListItem>
                            <asp:ListItem Value="1">Pagado</asp:ListItem>
                            <asp:ListItem Value="2">Pendiente</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                    <button class="btn btn-primary" id="btnGuardar">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <!--script>setTimeout('document.location.reload()',10000); </!--script-->
    
    
</asp:Content>
