using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo1 : System.Web.UI.Page
{
    public string GetWindowName()
    {
        return Session["WindowName"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}