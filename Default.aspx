<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationLab8D._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        
        Jugador<br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        Fecha del juego
        <br />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        Equipo<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Goles
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
        
    </div>

</asp:Content>
