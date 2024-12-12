using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace File_Upload
{
    public partial class File_uploadForm : System.Web.UI.Page
    {
        string ConStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                //Showimg();
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {

            string FileName = fileupload.FileName;
            fileupload.PostedFile.SaveAs(Server.MapPath("/ImageUpload/" + FileName));
            string Fpath = "/ImageUpload/" + FileName.ToString();

            SqlConnection con = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand("_UploadFile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FileNames", FileName);
            cmd.Parameters.AddWithValue("@PatnName", Fpath);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Showimg(string fname)
        {
            img.ImageUrl = ("/ImageUpload/" + fname);
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtimgid.Text.Trim());

            string fileNames = string.Empty;

            using (SqlConnection con = new SqlConnection(ConStr))
            {
                string query = "SELECT FileNames,PatnName FROM File_upload WHERE ID = @ID ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        fileNames = reader["FileNames"].ToString();
                        Showimg(fileNames);
                    }
                }
            }
        }
    }
}