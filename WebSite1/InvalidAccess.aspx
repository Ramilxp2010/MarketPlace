<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvalidAccess.aspx.cs" Inherits="InvalidAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invalid Access</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1> Invalid Access. Please close the window and try again.</h1> <br />
        </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    alert(" Operation not allowed either you opened this webpage in a new tab or a new window. ");
    window.close();
</script>
</html>
