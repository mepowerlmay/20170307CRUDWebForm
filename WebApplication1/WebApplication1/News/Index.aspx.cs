using Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1
{
    public partial class WebForm1 : BasePage
    {
        private MemberService service { get; set; }

        public WebForm1() {
            service = new MemberService();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }


        }

        private void GetData()
        {
         GridView1.DataSource =   service.GetList();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/News/Edit.aspx?ID=0");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {          
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            HiddenField hidd01 = (HiddenField)row.FindControl("HiddenField1");

            switch (e.CommandName)
            {
                case "cmdRead":
                    Response.Redirect("~/News/Read.aspx?ID=" + hidd01.Value);
                    break;
                case "cmdEdit":
                    Response.Redirect("~/News/Edit.aspx?ID=" + hidd01.Value);
                    break;             
                case "cmdDelte":
                    service.Delete(hidd01.Value);
                    GetData();
                    break;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string value = DataBinder.Eval(e.Row.DataItem, "ID", null);
             HiddenField hidd01 =   (HiddenField)e.Row.FindControl("HiddenField1");
                hidd01.Value = value;
            }
        }
    }
}