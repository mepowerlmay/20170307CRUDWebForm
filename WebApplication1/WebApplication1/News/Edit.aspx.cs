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
    public partial class Edit : BasePage
    {

        private MemberService service { get; set; }

        public Edit()
        {
            service = new MemberService();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                string ID = Request.QueryString["ID"];
                if (ID != "0" && !string.IsNullOrEmpty(ID))
                {
                    MemberModel model = service.Get(ID);
                    txtGener.Text = model.Gender;
                    txtUserName.Text = model.UserName;
                    HiddenField1.Value = ID;
                    btnAdd.Visible = false;
                }
                else
                {
                    btnEdit.Visible = false;
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/News/Index.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            MemberModel model = new MemberModel();

            model.Gender = txtGener.Text;
            model.UserName = txtUserName.Text;

            if (string.IsNullOrEmpty(HiddenField1.Value))
            {
                service.Edit(model, 0);
            }
            else
            {

                service.Edit(model, Convert.ToInt64( HiddenField1.Value));

            }
          
                
            Response.Redirect("~/News/Index.aspx");


        }
    }


}