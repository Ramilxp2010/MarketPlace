<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default</title>
    <script language="javascript" type="text/javascript">
        if (window.name == "default") {
            var windowFeatures = 'channelmode=0, directories=0, location=0, menubar=0, resizable=0, scrollbars=1,status=1,titlebar=0,toolbar=0,top=0,left=0,width=800,height=600';
            //With windowFeatures 
            window.open("Homepage.aspx", "<%=GetWindowName()%>", windowFeatures);
            window.opener = top;
            window.close();
        }
        else if (window.name == "") {
            window.name = "default";
            window.open("Default.aspx", "_self");
        }
        else if (window.name == "invalidAccess") {
            alert("Invalid access. Please close the window, and try again.");
            window.close();
        }
        else {
            window.name = "invalidAccess";
            window.open("Default.aspx", "_self");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
