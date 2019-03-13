using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook
{
    public partial class Person : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\AddressBook.mdf';Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                lblSuccessMessage.Text = lblErrorMessage.Text = "";
                FillGridView();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfId.Value = "";
            txtBirthDate.Text = "";
            txtFullName.Text = txtDescription.Text = txteMAIL.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("PersonCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfId.Value == ""?0:Convert.ToInt32(hfId.Value)));
            sqlCmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@birthDate", Convert.ToDateTime(txtBirthDate.Text));
            sqlCmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@email", txteMAIL.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string personId = hfId.Value;
            Clear();
            if(personId == "")
            {
                lblSuccessMessage.Text = "Saved Successfully";
            }
            else
            {
                lblSuccessMessage.Text = "Updated Successfully";
                FillGridView();
            }
        }

        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter sqlData = new SqlDataAdapter("PersonViewAll", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            sqlCon.Close();
            gvPerson.DataSource = dataTable;
            gvPerson.DataBind();
        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if(sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter sqlData = new SqlDataAdapter("PersonViewById", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@Id", Id);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            sqlCon.Close();
            hfId.Value = Id.ToString();
            txtFullName.Text = dataTable.Rows[0]["fullName"].ToString();
            txtBirthDate.Text = dataTable.Rows[0]["birthDate"].ToString();
            txtDescription.Text = dataTable.Rows[0]["description"].ToString();
            txteMAIL.Text = dataTable.Rows[0]["email"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("PersonDeleteById", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(hfId.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully!";
        }
    }
}