<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplicationLab8D.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </h2>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar" />
    </p>
    <p>&nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
