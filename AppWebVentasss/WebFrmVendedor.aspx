<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFrmVendedor.aspx.cs" Inherits="AppWebVentasss.WebFrmVendedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtapellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="DNI"></asp:Label>
            <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label4" runat="server" Text="Comision"></asp:Label>
            <asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
            <br />
             <br />
            <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="EDITAR" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" />
            <br />
             <br />
            <asp:Label ID="Label5" runat="server" Text="Traer por comision:"></asp:Label><asp:DropDownList ID="ddlComision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlComision_SelectedIndexChanged" ></asp:DropDownList>
            
             <br />
            <asp:Label ID="Label6" runat="server" Text="ID:"></asp:Label> 
            <asp:TextBox ID="txtTraerID" runat="server"></asp:TextBox><asp:Button ID="btnTraerID" runat="server" Text="TRAER POR ID" OnClick="btnTraerID_Click" />
            <br /> <br />
            <asp:Button ID="btnMostrarTodos" runat="server" Text="MOSTRAR TODOS" OnClick="btnMostrarTodos_Click"  />
            <br />
             <br />
            <asp:GridView ID="gridVendedor" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
