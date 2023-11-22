<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="EJERCICIO04.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Tecnicos
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
    TecnicoID: <asp:TextBox ID="tTecnicoID" class="form-control" runat="server" ></asp:TextBox>
    Nombre: <asp:TextBox ID="tNombre" class="form-control" runat="server"></asp:TextBox>
    Especialidad: <asp:TextBox ID="tEspecialidad" class="form-control" runat="server"></asp:TextBox>
 
</div>

    <br />
    <br />
    <br />

</div>
<div class="container text-center">

    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar"  />
    <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Modificar" OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Consultar"  />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Borrar" OnClick="Bconsulta_Click" />


    </div>
</asp:Content>
