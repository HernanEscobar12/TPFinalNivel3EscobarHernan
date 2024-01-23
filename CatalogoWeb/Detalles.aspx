<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="CatalogoWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1>Detalles</h1>
        <div class="row">
            <h5><%#Eval("Nombre")%> </h5>
        </div>
        <div class="col-5 m-3">
            <div class="mb-3">
                <asp:Label Text="Codigo" ID="lblCodigo" runat="server" />
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" Enabled="false" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" ID="lblNombre" runat="server" />
                <asp:TextBox runat="server" ID="txt2Nombre" CssClass="form-control" Enabled="false" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" ID="lblPrecio" runat="server" />
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" Enabled="false" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripcion" ID="lblDescripcion" runat="server" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Enabled="false" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Volver" ID="btnCancelar" CssClass="btn btn-outline-dark" runat="server" OnClick="btnCancelar_Click" />
                <%if(Negocio.Seguridad.SesionActiva(Session["UsuarioActivo"]))
                {%>
                   <asp:CheckBox Text="★" ID="chkFavorito" CssClass="btn btn-outline-warning" OnCheckedChanged="chkFavorito_CheckedChanged" AutoPostBack="true" ForeColor="Black" runat="server" />                    
                <%}
                %>
            </div> 
        </div>

        <div class="col-6 m-3">

            <updatepanel>
                <div class="mb-3">

                    <div class="mb-3">
                        <asp:Label Text="Marca" ID="lblMarca" runat="server" />
                        <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" Enabled="false" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Categoria" ID="lblCategoria" runat="server" />
                        <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" Enabled="false" />
                    </div>

                    <asp:Image ID="imgUrl" ImageUrl="www" runat="server"
                        BorderColor="Black" BorderStyle="Double" Width="350px" Height="350px" CssClass="mt-3" />
                </div>
            </updatepanel>

        </div>
    </div>
</asp:Content>
