<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CatalogoWeb.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .contenedor-titular {
            margin-top:10px;
            margin-bottom:10px;
            font-size: 18px;
            display: flex;
            justify-content: flex-start;
            align-content: flex-start;
        }

        .row-cols-1 {
            margin-top: 10px;
            height: 100vh;
            display: flex;
            margin-bottom:10px;
            justify-content: center;
            align-content: center;
            align-content: center;
        }


        .row-cols-md-4{
            align-items:center;
            justify-content:flex-start;
            background-color:#f0eafd;
            height:auto;
            width:auto;
            border-radius:25px;
            margin-bottom:40px;
        }
    </style>



    <div class="contenedor-titular">
        <h1>Mis Favoritos</h1>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater runat="server" ID="IdRepeater">
            <ItemTemplate>
                <div class="">
                    <div class="card  m-3">
                        <img src="<%#Eval("ImageUrl")%>" class="card-img-top" id="imgArticulo" height="200" width="200" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%>  </h5>
                            <p class="card-text"><%#Eval("Descripcion")%> </p>
                            <asp:Label class="card-text" Text='<%#Eval("Precio", "{0:F2}")%>' ID="lblPrecio" runat="server" />
                            <br />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
