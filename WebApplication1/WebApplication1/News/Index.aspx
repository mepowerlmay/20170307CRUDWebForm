<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />

            <asp:Panel ID="panelList" runat="server"></asp:Panel>

            <asp:Panel ID="panel" runat="server"></asp:Panel>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    
                    
                    <asp:BoundField DataField="UserName" HeaderText="姓名" />
                    <asp:BoundField DataField="Gender" HeaderText="性別" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:Button ID="Button4" runat="server" Text="讀取" CommandName="cmdRead"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                            <asp:Button ID="Button2" runat="server" Text="編輯" CommandName="cmdEdit"  CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                            <asp:Button ID="Button3" runat="server" Text="刪除" CommandName="cmdDelte"  CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                            
                        </ItemTemplate>
                    </asp:TemplateField>    
                </Columns>

            </asp:GridView>

        </div>
    </form>
</body>
</html>
