<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebApplication1.News.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta name="description" content="The description of my page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label>
      <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </div>

         <div>
        <asp:Label ID="Label2" runat="server" Text="性別"></asp:Label>
             <asp:TextBox ID="txtGener" runat="server"></asp:TextBox>
             <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>

        <div>
            <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnEdit_Click" />
            <asp:Button ID="btnEdit" runat="server" Text="編輯" OnClick="btnEdit_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"   />

        </div>
    </form>
</body>
</html>
