<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="CatalogoWeb.ListaArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .titular {
            display: flex;
            align-items: center;
            justify-content: flex-start;
        }
    </style>


    <div class="titular">
        <h1 style="margin-top: 40px">Lista de Articulos</h1>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox ID="TxtFiltro" CssClass="form-control" AutoPostBack="true" runat="server" OnTextChanged="TxtFiltro_TextChanged" />
            </div>
        </div>
    </div>
    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text=" Filtro Avanzado"
                CssClass="" ID="ChkAvanzado" runat="server"
                AutoPostBack="true"
                OnCheckedChanged="ChkAvanzado_CheckedChanged" />
        </div>
        <%if (ChkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Categoria" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ForeColor="yellow" Text="Buscar" runat="server" CssClass="btn btn-dark" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <%}
%>
    </div>



    <asp:GridView ID="dgvArticulos" AllowPaging="true" AutoGenerateColumns="false" runat="server" DataKeyNames="Id" CssClass="table active blockquote text-light-emphasis text-bg-info"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />
        </Columns>
    </asp:GridView>


    <div class="row">
        <div class="col-3">
        </div>
        <div class="col-8" style="display: flex; justify-content: flex-end">
            <asp:Button ID="btnSalir" Text="Salir" OnClick="btnSalir_Click" CssClass="btn btn-outline-danger btn-xg" runat="server" />
        </div>
    </div>


</asp:Content>
