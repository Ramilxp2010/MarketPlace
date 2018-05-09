<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo2.aspx.cs" Inherits="Demo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo 2</title>
    <script language="javascript" type="text/javascript">
        if(window.name != "<%=GetWindowName()%>")
        {
            window.name = "invalidAccess";
            window.open("InvalidAccess.aspx", "_self");
        }
    </script>
</head>
<body bgcolor="lime">
    <form id="form1" runat="server">
     <div>
     <h1>Page 2</h1>
            Try to Open the Link given below either in new window or tab.<br />
            <img src="image/img.jpg" alt="Image" align="right"  />
            <br />
            <asp:HyperLink ID="hlDemo1" runat="server" NavigateUrl="~/Demo1.aspx">Page 1</asp:HyperLink>
            &nbsp; &nbsp;<asp:HyperLink ID="hlDemo2" runat="server" NavigateUrl="~/Demo2.aspx">Page 2</asp:HyperLink>
            &nbsp; &nbsp;
            <asp:HyperLink ID="hlDemo3" runat="server" NavigateUrl="~/Demo3.aspx">Page 3</asp:HyperLink>
        </div>
    </form>
</body>
</html>
