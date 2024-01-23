<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>



        h2{
            color:white;
            font-size: 40px;
            display:flex;
            align-items: center;       
            
        }


        .row {
            display:flex;
            align-items: center;
            justify-content: center;
            margin-top: 40px;
            height:100vh;
        }


        .col-3 {
            display:flex;
            align-items: center;
            border-top-left-radius:20%;
            border-bottom-left-radius:20%;
            justify-content: center;
            border:groove;
            border-color: darkmagenta;
            height: 50vh;
        }


        .col-4 {
            border-color: darkmagenta;
            border-top-right-radius:20%;
            border-bottom-right-radius:20%;
            align-items: center;
            justify-content: flex-end;
            background-color: #A019D8;
            height: 50vh;
        }

        .mb-3{
            align-items:center;

        }

    </style>

    <script>
        function Validar() {
            const txtEmail = document.getElementById("txtEmail");
            const txtPass = document.getElementById("txtPass")
            if (txtEmail.value == "" && txtPass.value == "") {
                txtEmail.classList.add("is-invalid");
                txtPass.classList.add("is-invalid");
                alert("Debes Completar Ambos Campos");
                return false;
              
            }
            txtEmail.classList.remove("is-invalid");
            txtEmail.classList.add("is-valid");
            txtPass.classList.remove("is-invalid");
            txtPass.classList.add("is-valid");
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
        <div class="col-3">
            <img style="width:250px; height:250px; display:flex" src="https://midoshriks-school.netlify.app/assets/sing/imgs/login-form-img.png" alt="Alternate Text" />
        </div>
        <div class="col-4">
            <div class="mb-3">
                <h2>Login</h2>
                <label class="form-label">Email</label>
                <asp:TextBox TextMode="Email" runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" ClientIDMode="Static"  ID="txtPass" />
            </div>
            <asp:button  ID="btnIngresar" Text="Login" class="btn btn-success" runat="server" OnClick="btnIngresar_Click" OnClientClick="return Validar()"/>
            <asp:button ID="btnSalir" Text="Salir" class="btn btn-warning" runat="server" OnClick="btnSalir_Click"  />
        </div>
    </div>
</asp:Content>
