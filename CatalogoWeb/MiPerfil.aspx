<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="CatalogoWeb.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titular {
            margin-top: 10px;
            margin-bottom: 10px;
            font-size: 18px;
        }

        .row-datos {
            width: 100%;
            height: 70vh;
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

    <script>
        function validar() {

            //capturar el control.
            const txtApellido = document.getElementById("txtApellido");
            const txtNombre = document.getElementById("txtNombre");
            if (txtApellido.value == "" && txtNombre.value == "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            txtApellido.classList.add("is-valid");
            txtNombre.classList.remove("is-invalid");
            txtNombre.classList.add("is-valid");
            return true;

        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="titular">
        <h1>Mi Perfil</h1>
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
    <div class="row-btn">
        <div class="col-md-5">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClientClick="return validar()" OnClick="btnGuardar_Click" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
