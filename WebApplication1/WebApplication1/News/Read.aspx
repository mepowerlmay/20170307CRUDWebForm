<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="WebApplication1.News.Read" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="labUserName" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="labGender" runat="server" ></asp:Label>
              <br />
       <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"   />
    </div>
    </form>
</body>
</html>
