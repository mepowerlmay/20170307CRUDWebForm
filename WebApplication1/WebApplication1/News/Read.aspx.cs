using Business.Service;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.App_Code;

namespace WebApplication1.News
{
    public partial class Read : BasePage
    {
        private MemberService service { get; set; }

        public Read()
        {
            service = new MemberService();

        }
        protected void Page_Load(object sender, EventArgs e)
        {         

            string ID = Request.QueryString["ID"];
            if (ID != "0" && !string.IsNullOrEmpty(ID))
            {
                MemberModel model = service.Get(ID);
                labUserName.Text = model. UserName;
                labGender.Text = model.Gender;
                
                
            }
            else
            {
                       ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "buttonStartupBySM", "alert('查無資料');", true);
                
                Response.Redirect("~/News/Index.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/News/Index.aspx");
        }
    }
}