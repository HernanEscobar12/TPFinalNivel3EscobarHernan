<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb.Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">

    <style>
        .containerHome {
            margin-top: 40px;
            margin-bottom: 20px;
        }


        .carousel-inner {
            border-bottom-left-radius: 25px;
            border-bottom-right-radius: 25px;
            border-top-left-radius: 25px;
            border-top-right-radius: 25px;
        }


        .container-categorias {
            /*background-image: url("https://images3.alphacoders.com/133/1339251.png");*/
            background-color: #5d2ca0;
            height: 45vh;
            border: dashed;
            border-block-start-color: darkblue;
            border-block-end-color: cornsilk;
            border-bottom-left-radius: 40px;
            border-bottom-right-radius: 40px;
            border-top-left-radius: 40px;
            border-top-right-radius: 40px;
            display: grid;
            justify-items: center;
            margin-top:40px;
            border: double;
            border-block-color: black;
            color-interpolation: revert-layer;
        }

        .row-cols-md-4 {
            margin-top: 40px;
            margin-bottom:40px;
            background-color: #300e5d;
            border-block-start-width: 10px;
            border-radius: 20px;
        }

        .container-titular {
            align-items: center;
            align-content: center;
            justify-content: center;
        }

        h4 {
            font-size: 40px;
            color: white;
        }

        .categoria-img {
            max-width: 1340px;
            box-sizing: border-box;
            min-height: 0px;
            min-width: 0px;
        }


        .div-card {
            padding: 10px;
            display: flex;
            justify-content: center;
            list-style: none;
            align-items: center;
            display: flex;
        }

        .card-body {
            border-bottom-right-radius: 10px;
            border-bottom-Left-radius: 10px;
            border-block-color: black;
            border: groove;
            color: black;  
            background-color: #9761eb;
            font-size: 18px;
        }

        .card-title{
            font-size:25px;
        }

        .card-text{
            font-size:18px;
        }

        .img {
            height: 180px;
        }

        .categoria-img {
            margin-bottom: 40px;
        }
    </style>


    <%-- Banner - carouselExampleAutoplaying --%>
    <div class="containerHome w-100%">
        <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="Image/Banner/shop-shop.png" class="d-block w-100" alt="PlayStation-5">
                </div>
                <div class="carousel-item">
                    <img src="Image/Banner/shop no.png" class="d-block w-100" alt="Smartphones">
                </div>
                <div class="carousel-item">
                    <img src="Image/Banner/laptop-shop.png" class="d-block w-100" alt="Audio-sonido">
                </div>
                <div class="carousel-item">
                    <img src="Image/Banner/shopcel.png" class="d-block w-100" alt="Smart-Tv">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </div>


        <%--</ Filtro Por Categorias  >--%>
    <div class="container-categorias">
        <div class="container-titular">
            <h4>Categorías</h4>
        </div>
        <div class="categoria-img">
            <ul class="div-card">
                <li>
                    <asp:ImageButton ID="Celu" CommandArgument="Celu" CssClass="img" ImageUrl="https://cdn.icon-icons.com/icons2/24/PNG/256/smartphone_phone_phone_android_xperia_mobile_2515.png" OnClick="Filtro" runat="server" /></li>
                <li>
                    <asp:ImageButton ID="Tele" CommandArgument="Tele" CssClass="img" ImageUrl="https://cdn.icon-icons.com/icons2/1050/PNG/256/TFT1_icon-icons.com_76604.png" runat="server" OnClick="Filtro" /></li>
                <li>
                    <asp:ImageButton ID="Media" CommandArgument="Media" CssClass="img" ImageUrl="https://cdn.icon-icons.com/icons2/12/PNG/256/games_game_playstation3_playstation_1761.png" OnClick="Filtro" runat="server" /></li>
                <li>
                    <asp:ImageButton ID="Audio" CommandArgument="Audio" CssClass="img" ImageUrl="https://images.vexels.com/media/users/3/136896/isolated/preview/2829103922d5c1b1d53297fc6998ec86-caja-de-altavoces.png" OnClick="Filtro" runat="server" /></li>
            </ul>
        </div>
    </div>


    <%-- Catalogo  --%>
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
                            <asp:Button ID="btnDetalles" Text="Detalles" CssClass="btn btn-warning" CommandArgument='<%# Eval("Id")%>' CommandName="ArticuloId" OnClick="btnDetalles_Click" runat="server" BorderStyle="NotSet" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
