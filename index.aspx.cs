using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Portfolio
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TBDT6GT\\SQLEXPRESS;Initial Catalog=portfolioDB;Integrated Security=True");

                using (connection)
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT SkillName, SkillPercentage, IconClass FROM Skills", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        SkillsRepeater.DataSource = dt;
                        SkillsRepeater.DataBind();
                    }


                    connection.Close();

                }

            }
        }
    }
}