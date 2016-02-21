using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichiersZip
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (HttpPostedFile item in FileUpload1.PostedFiles)
            {
                ListBox1.Items.Add(item.FileName);
            }














            //string tab = FileUpload1.PostedFile.FileName.ToString();
            //string[] tabSep = new string[] { "," };
            //string[] tabResult;
            //tabResult = tab.Split(tabSep, StringSplitOptions.None);

            //foreach (string item in tabResult)
            //{
            //    ListBox1.Items.Add(item);
            //}
            //Label1.Text = FileUpload1.PostedFile.FileName.ToString();
        }
    }
}