<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="CatalogoWeb.Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mb-3 {
            position: page;
            display: flex;
            align-items: stretch;
            justify-content: space-evenly;
            background-color: #ccbaf8;
            color: black;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            border-top-right-radius: 10px;
            border-top-left-radius: 10px;
            margin-bottom: 20px;
            margin-top: 20px;
            width: 100vh;
        }

        .contenedor {
            display: flex;
            justify-content: space-between;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
            border-top-right-radius: 20px;
            border-top-left-radius: 20px;
            border: solid;
            padding: 10px,5px,5px,10px;
            background-color: #36165f;
            color: white;
            flex-direction: column;
            align-items: normal;
            margin-bottom: 50px;
        }

        .contenedor-btn {
            display: flex;
            justify-content: flex-end;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="mananger" runat="server"></asp:ScriptManager>

    <div class="col-6">
        <h1>Panel de Control </h1>
        <p>Administra el control de la aplicativo </p>
    </div>

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox ID="ChkUsuarios" Text="Usuarios" runat="server" AutoPostBack="true" OnCheckedChanged="ChkUsuarios_CheckedChanged" />
            <asp:CheckBox ID="ChkMarcas" Text="Marcas" runat="server" AutoPostBack="true" OnCheckedChanged="ChkMarcas_CheckedChanged" />
            <asp:CheckBox ID="ChkCategorias" Text="Categorias" runat="server" AutoPostBack="true" OnCheckedChanged="ChkCategorias_CheckedChanged" />
            <asp:CheckBox ID="ChkArticulos" Text="Articulos" runat="server" AutoPostBack="true" OnCheckedChanged="ChkArticulos_CheckedChanged" />
        </div>
    </div>

    <%--Grid Marcas --%>

    <%if (ChkMarcas.Checked)
        { %>
    <div class="contenedor">
        <h2>Listado de Marcas</h2>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="dgvMarcas" AutoGenerateColumns="false" DataKeyNames="Id" runat="server" CssClass="table active">
                    <Columns>
                        <asp:BoundField HeaderText="Marcas" DataField="Descripcion" />
                    </Columns>
                </asp:GridView>
                <div class="contenedor-btn">
                    <asp:Button runat="server" Text="Nueva Marca" CssClass="btn btn-success btn-sm" />
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%}


    %>


    <%--Grid Usuarios --%>

    <%if (ChkUsuarios.Checked)
        {%>
    <div class="contenedor">
        <h2>Usuarios</h2>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="dgvUsuarios" runat="server" DataKeyNames="id"
                    CssClass="table" AutoGenerateColumns="false"
                    AllowPaging="True" PageSize="5"
                    OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Email" DataField="email" />
                        <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                        <asp:CheckBoxField HeaderText="Admin" DataField="admin" />
                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%}%>





    <%-- Grid Categorias --%>
    <%if (ChkCategorias.Checked)
        { %>
    <div class="contenedor">
        <div class="categorias">
            <h2>Categorias</h2>
            <asp:GridView ID="dgvCategorias" runat="server" DataKeyNames="Id"
                CssClass="table" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Categorias" DataField="Descripcion" />
                </Columns>
            </asp:GridView>
            <div class="contenedor-btn">
                <asp:Button runat="server" Text="Nueva Categoria " CssClass="btn btn-success btn-sm" />
            </div>
        </div>
    </div>
    <%}
    %>




    <%--Grid Articulos --%>
    <%if (ChkArticulos.Checked)
        { %>
    <div class="contenedor">
        <h2>Articulos</h2>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="dgvArticulos" AutoGenerateColumns="false" runat="server" DataKeyNames="Id" CssClass="table active blockquote text-light-emphasis text-bg-info"
                    OnPageIndexChanging="GridView_PageIndexChanging1"
                    OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                    AllowPaging="true" PageSize="3">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Código" DataField="Codigo" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />
                        <asp:CommandField HeaderText="Acción"
                            ShowSelectButton="true" SelectText="✍" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" CssClass="btn btn-outline-success btn-xg" runat="server" />
    </div>
    <%}
    %>
</asp:Content>
