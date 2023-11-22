<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="EJERCICIO04.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
    <h1>Catalogo de Equipos</h1>
        <div>

             <p>&nbsp;</p>
</div>
<div>
    <br />
    <br />
    <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />

<div class="container text-center">
    EquipoID: <asp:TextBox ID="tEquipoID" class="form-control" runat="server" ></asp:TextBox>
    TipoEquipo: <asp:TextBox ID="tTipoEquipo" class="form-control" runat="server"></asp:TextBox>
    Modelo: <asp:TextBox ID="tModelo" class="form-control" runat="server"></asp:TextBox>
    UsuariosID: <asp:TextBox ID="tUsuariosID" class="form-control" runat="server"></asp:TextBox>
</div>

    <br />
    <br />
    <br />

</div>
<div class="container text-center">

    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" />
    <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Modificar" OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Consultar"  />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Borrar" OnClick="Bconsulta_Click" />









        </div>
</div>
</asp:Content>
