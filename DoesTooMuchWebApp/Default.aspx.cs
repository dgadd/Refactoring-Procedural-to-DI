using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Support.OriginalCode;

namespace DoesTooMuchWebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateGymMembership_Click(object sender, EventArgs e)
        {
            var proceduralCode = new ProceduralCode();
            lblMessage.Text = proceduralCode.CreateGymMembership();
        }
    }
}
