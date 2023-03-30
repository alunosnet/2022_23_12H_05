﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_AB_Projeto
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["M17_AB"];
            if (cookie != null)
                div_aviso.Visible = false;
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            HttpCookie novo = new HttpCookie("M17_AB");
            novo.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(novo);
            div_aviso.Visible = false;
        }
    }
}