using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string GetWindowName()
    {
        Session["WindowName"] = Guid.NewGuid().ToString().Replace("-", "");
        return Session["WindowName"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}