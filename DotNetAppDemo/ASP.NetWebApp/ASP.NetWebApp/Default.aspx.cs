using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NetWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GreetButton_Click(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = "Hello " + TextInput.Text;
        }

        protected void m_btnGreet_Click(object sender, EventArgs e)
        {
            m_lblGreetText.Text = "Hello " + m_txtName.Text;
        }
    }
}