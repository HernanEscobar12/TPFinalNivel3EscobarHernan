<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="CatalogoWeb.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
          .titular {
      margin-top: 10px;
      margin-bottom: 10px;
      font-size: 18px;
  }

  .row-datos {
      width: 100%;
      height: 100vh;
      border-radius: 20px;
      background-color: #f0eafd;
      margin-top: 10px;
      margin-bottom: 2px;
      display: flex;
      justify-content: space-evenly;
      align-items: center
  }

  .form-label {
      font-size: x-large;
      font-family:Arial;
  }

  .form-control{
      font-size:18px;
      font-family:Dubai;
  }

  .col-md-4 {
      justify-content: space-evenly;
      align-items: center
  }

  .row-botton {
      align-items: flex-start;
      margin-bottom: 40px;
  }

  .Validator {
      color: red;
      font-size: 10px;
      font-family: 'Times New Roman';
      border-block-color: blueviolet
  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    
    <div class="titular">
        <h1>User</h1>
    </div>
    <div class="row-datos">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8">
             </asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
                <div class="row-btn">
        <div class="col-md-5">
            <asp:Button Text="Eliminar" CssClass="btn btn-primary" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />
            <a href="/">Regresar</a>
        </div>
        <%if (ConfirmaEliminacion)
            { %>
        <div class="mb-3">
            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" runat="server" />
        </div>
        <%} %>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>