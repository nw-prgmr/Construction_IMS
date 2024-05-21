using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace ConstructionMaterialManagementSystem
{
    public partial class frmHome : Form
    {
        MySqlConnection cn = new MySqlConnection();

        public frmHome()
        {
            InitializeComponent();
            cn.ConnectionString = "server = localhost; user id = root; password=; database = construction_ims;";
            cn.Open();
            LoadChart();
        }

        private void LoadChart()
        {
            // Modify the SQL query to select only the top 5 products
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT pName, pStock FROM tbl_products ORDER BY pStock DESC LIMIT 5", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Top 5 Products");

            // Clear any existing series
            chart1.Series.Clear();

            // Create a new series for each product
            foreach (DataRow row in ds.Tables["Top 5 Products"].Rows)
            {
                Series series = new Series(row["pName"].ToString());
                series.Points.Add(Convert.ToDouble(row["pStock"]));
                series.ChartType = SeriesChartType.Column;

                // Add spacing between the bars
                series["PointWidth"] = "0.6";

                chart1.Series.Add(series);
            }

            // Remove labels from the x-axis
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        }

        //private void LoadOrderCount()
       // {
            // Create a new SQL command
         //   MySqlCommand cmd = new MySqlCommand("SELECT COUNT(moID) FROM tbl_myorder", cn);

            // Execute the command and get the number of orders
          //  int orderCount = Convert.ToInt32(cmd.ExecuteScalar());

            // Assign the number of orders to the label's text property
         //  lblOrderCount.Text = "Number of Orders: " + orderCount.ToString();
      //  }







        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void lblOrderCount_Click(object sender, EventArgs e)
        {

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            int orderCount = GetOrderCount(startDate, endDate);
            lblOrderCount.Text = orderCount.ToString();
        }
        private int GetOrderCount(DateTime startDate, DateTime endDate)
        {
            int count = 0;

            try // Wrap database interaction in a try-catch block for error handling
            {
                cn.Open(); // Open the connection
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = cn;
                    command.CommandText = @"SELECT COUNT(*) FROM [Order]
                                         WHERE OrderDate BETWEEN @startDate AND @endDate";
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (MySqlException ex) // Catch potential database exceptions
            {
                // Handle database errors gracefully (e.g., display error message)
                Console.WriteLine("Error connecting to database: " + ex.Message);
            }
            finally // Ensure the connection is closed even if an exception occurs
            {
                cn.Close();
            }

            return count;
        }


        private void btnCustomDate_Click(object sender, EventArgs e)
        {

        }

        private void dgvUnderstock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadUnderstockedMaterials()
        {
            // Define the understock threshold
            int understockThreshold = 50; // Change this value based on your needs

            // Create a new SQL command to select the understocked materials
            MySqlCommand cmd = new MySqlCommand("SELECT pName, pStock FROM tbl_products WHERE pStock < @understockThreshold", cn);
            cmd.Parameters.AddWithValue("@understockThreshold", understockThreshold);

            // Create a new MySqlDataAdapter
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            // Create a new DataTable
            DataTable dt = new DataTable();

            // Fill the DataTable with the result of the SQL query
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No understocked materials found.");
            }
            else
            {
                // Set the DataTable as the DataSource of your DataGridView
                dgvUnderstock.DataSource = dt;

            }
        }

    }
}