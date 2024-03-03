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
    public partial class admin : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DESKTOP-TBDT6GT\SQLEXPRESS;Initial Catalog=portfolioDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Skills();
            }
        }

        void Skills()
        {
            string connectionString1 = @"Data Source=DESKTOP-TBDT6GT\SQLEXPRESS;Initial Catalog=portfolioDB;Integrated Security=True";
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString1))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Skills", sqlcon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GvSkills.DataSource = dtbl;
                GvSkills.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GvSkills.DataSource = dtbl;
                GvSkills.DataBind();
                GvSkills.Rows[0].Cells.Clear();
                GvSkills.Rows[0].Cells.Add(new TableCell());
                GvSkills.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GvSkills.Rows[0].Cells[0].Text = "No Data Found...";
                GvSkills.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }
        }

        protected void GvSkills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (var sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        const string query = "INSERT INTO Skills (SkillName, SkillPercentage, IconClass) VALUES (@SkillName, @SkillPercentage, @IconClass)";
                        var sqlCmd = new SqlCommand(query, sqlCon);

                        sqlCmd.Parameters.AddWithValue("@SkillName", ((TextBox)GvSkills.FooterRow.FindControl("txtSkillNameFooter")).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@SkillPercentage", ((TextBox)GvSkills.FooterRow.FindControl("txtSkillPercentageFooter")).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@IconClass", ((TextBox)GvSkills.FooterRow.FindControl("txtIconClassFooter")).Text.Trim()); // Add this line

                        sqlCmd.ExecuteNonQuery();
                        Skills();
                        lblSuccessMessage1.Text = "New Record Added";
                        lblErrorMessage1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage1.Text = "";
                lblErrorMessage1.Text = ex.Message;
            }
        }

        protected void GvSkills_RowEditing(object sender, GridViewEditEventArgs e)
        {
             GvSkills.EditIndex = e.NewEditIndex;
              Skills();

        }

        protected void GvSkills_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvSkills.EditIndex = -1;
            Skills();
        }

        protected void GvSkills_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Check if the row index is within the valid range
                if (e.RowIndex >= 0 && e.RowIndex < GvSkills.Rows.Count)
                {
                    using (var sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        const string query = "UPDATE Skills SET SkillName=@SkillName, SkillPercentage=@SkillPercentage, IconClass=@IconClass WHERE SkillID=@id";
                        var sqlCmd = new SqlCommand(query, sqlCon);

                        // Get the new values from the GridView row
                        var newSkillName = ((TextBox)GvSkills.Rows[e.RowIndex].FindControl("txtSkillName")).Text.Trim();
                        var newSkillPercentage = ((TextBox)GvSkills.Rows[e.RowIndex].FindControl("txtSkillPercentage")).Text.Trim();
                        var newIconClass = ((TextBox)GvSkills.Rows[e.RowIndex].FindControl("txtIconClass")).Text.Trim(); 
                        var id = Convert.ToInt32(GvSkills.DataKeys[e.RowIndex].Value.ToString());

                        // Add parameters to the SQL command
                        sqlCmd.Parameters.AddWithValue("@SkillName", newSkillName);
                        sqlCmd.Parameters.AddWithValue("@SkillPercentage", newSkillPercentage);
                        sqlCmd.Parameters.AddWithValue("@IconClass", newIconClass); // Add this line
                        sqlCmd.Parameters.AddWithValue("@id", id);

                        sqlCmd.ExecuteNonQuery();
                        GvSkills.EditIndex = -1; 
                        Skills(); 
                        lblSuccessMessage1.Text = "Record Updated";
                        lblErrorMessage1.Text = "";
                    }
                }
                else
                {
                    lblSuccessMessage1.Text = "";
                    lblErrorMessage1.Text = "Row index is out of range.";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage1.Text = "";
                lblErrorMessage1.Text = ex.Message;
            }

        }

        protected void GvSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Check if the row index is within the valid range
                if (e.RowIndex >= 0 && e.RowIndex < GvSkills.Rows.Count)
                {
                    using (var sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        const string query = "DELETE FROM Skills WHERE SkillID=@Id";
                        var sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(GvSkills.DataKeys[e.RowIndex].Value.ToString()));

                        sqlCmd.ExecuteNonQuery();
                        Skills(); 
                        lblSuccessMessage1.Text = "Selected Record Deleted";
                        lblErrorMessage1.Text = "";
                    }
                }
                else
                {
                    lblSuccessMessage1.Text = "";
                    lblErrorMessage1.Text = "Row index is out of range.";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage1.Text = "";
                lblErrorMessage1.Text = ex.Message;
            }

        }
    }
}