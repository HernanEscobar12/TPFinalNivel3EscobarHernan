<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CatalogoWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Validator {
            color: white;
            font-size: 12px;
            font-family:'Microsoft Sans Serif';
        }



        h2 {
            color: white;
            font-size: 30px;
            display: flex;
            align-items: center;
        }


        .row {
            align-items: center;
            justify-content: center;
            margin-top: 30px;
             
        }


        .col-3 {
            background-color: darkslateblue;
            display: flex;
            align-items: center;
            border-top-left-radius: 10%;
            border-bottom-left-radius: 10%;
            justify-content: center;
            border: groove;
            border-color: white;
            height: 100vh;
        }


        .col-4 {
            border-color: gold;
            border-top-right-radius: 5%;
            border-bottom-right-radius: 5%;
            align-items: center;
            justify-content: flex-end;
            background-color: #A019D8;
            height: 100vh;
        }

        .mb-3 {
            font-size: 20px;
            color: white;
            border-block-color: darkblue;
            align-items: center;
        }
    </style>

    <script>
        function validar() {

            //capturar el control. 
            const txtPassword = document.getElementById("txtPassword");
            const txtRepeatPass = document.getElementById("txtRepeatPass");
            if (txtPassword.value == txtRepeatPass.value && txtPassword.value != "" && txtRepeatPass.value != "") {
                txtRepeatPass.classList.add("is-valid");
                txtRepeatPass.classList.remove("is-invalid");
                txtPassword.classList.add("is-valid");
                return true;
            }
            txtRepeatPass.classList.remove("is-valid");
            txtRepeatPass.classList.add("is-invalid");
            txtPassword.classList.remove("is-valid");
            txtPassword.classList.add("is-invalid")
            alert("Las contaseñas no coinciden");
            return false;

        }
    </script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3">
            <img style="width: 350px; height: 350px; display: flex" src="https://cdni.iconscout.com/illustration/premium/thumb/sign-up-8694031-6983270.png" alt="Sign-Up" />
        </div>
        <div class="col-4">
            <h2>Creá tu perfil</h2>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtNombre" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
            </div>
            <div class="mb-3">
                <label class="form-label">* Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
<%--                <asp:RequiredFieldValidator ErrorMessage="Email es Requerido" CssClass="Validator" ControlToValidate="txtEmail" runat="server" />--%>
<%--                <asp:RegularExpressionValidator ErrorMessage="Formato email por favor" CssClass="Validator" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>

            </div>
            <div class="mb-3">
                <label class="form-label">* Password</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <div class="mb-3">
                <label class="form-label">* Repetir Password</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtRepeatPass" TextMode="Password" />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-sm btn-success" ID="btnRegistrarse" OnClientClick="return validar()" OnClick="btnRegistrarse_Click" runat="server" />
            <asp:Button Text="Cancelar" CssClass="btn btn-sm btn-info" ID="btnSalir" OnClick="btnSalir_Click" runat="server" /> 
        </div>
    </div>
</asp:Content>






