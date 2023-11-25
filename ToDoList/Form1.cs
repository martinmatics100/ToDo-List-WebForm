using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        //private readonly string connectionString;
        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myListConnection"].ConnectionString);
        }

        private async Task LoadTask()
        {

            string selectQuery = "SELECT * FROM myListTable";
            
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, sqlConnection);
            DataTable dataTable = new DataTable();
            await Task.Delay(1000);
            adapter.Fill(dataTable);

            GridView1.DataSource = dataTable;

        }


        private async Task UpdateTaskAsync(int taskId, string newTitle, string newDescription, DateTime newDateCreated, DateTime newDueDate)
        {
            try
            {
                string updateQuery = "UPDATE myListTable SET Title = @NewTitle, Description = @NewDescription, DateCreated = @NewDateCreated, DueDate = @NewDueDate WHERE ID = @TaskId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@NewTitle", newTitle);
                    cmd.Parameters.AddWithValue("@NewDescription", newDescription);
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@NewDateCreated", newDateCreated);
                    cmd.Parameters.AddWithValue("@NewDueDate", newDueDate);

                    await sqlConnection.OpenAsync(); // Open the connection asynchronously
                    await cmd.ExecuteNonQueryAsync(); // Execute the query asynchronously
                    MessageBox.Show("Updated successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        private async void AddButton_Click(object sender, EventArgs e)
        {
            // Get data from textboxes
            string title = TitleTextBox.Text.Trim();
            string description = DescriptionTextBox.Text.Trim();
            DateTime DateCreated = (DateTime)DateCreatedTextBox.Value;
            DateTime DueDate = (DateTime)DueDateTextBox.Value;
            int ID = 1;

            // If nothing is written
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    MessageBox.Show("Please enter a title");
                    TitleTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("Please enter a description");
                    DescriptionTextBox.Focus();
                }
                return;
            }

            if (selectedTaskId > 0)
            {
                await UpdateTaskAsync(selectedTaskId, title, description, DateCreated, DueDate);
                MessageBox.Show("Updated successfully");
                TitleTextBox.Text = "";
                DescriptionTextBox.Text = "";
                DateCreatedTextBox.Value = DateCreated;
                DueDateTextBox.Value = DueDate;
                selectedTaskId = 0;
                await LoadTask();
            }
            else
            {
                try
                {
                    // Query the database to find the maximum existing ID
                    string maxIdQuery = "SELECT MAX(ID) FROM myListTable";
                    using (SqlCommand getMaxIdCmd = new SqlCommand(maxIdQuery, sqlConnection))
                    {
                        await sqlConnection.OpenAsync();
                        object result = await getMaxIdCmd.ExecuteScalarAsync();

                        if (result != DBNull.Value) // Check if there are existing records
                        {
                            ID = Convert.ToInt32(result) + 1; // Increment the maximum ID
                        }
                    }

                    // Create a query to add the task to the database
                    string insertQuery = "INSERT INTO myListTable (ID, Title, Description, DateCreated, DueDate) VALUES (@ID, @Title, @Description, @DateCreated, @DueDate)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@DateCreated", DateCreated);
                        cmd.Parameters.AddWithValue("@DueDate", DueDate);

                        await cmd.ExecuteNonQueryAsync();
                        MessageBox.Show("Added successfully");

                        TitleTextBox.Text = "";
                        DescriptionTextBox.Text = "";

                        await LoadTask();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        private int selectedTaskId;
        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count > 0)
            {
                selectedTaskId = Convert.ToInt32(GridView1.SelectedRows[0].Cells["ID"].Value);

                string existingTitle = GridView1.SelectedRows[0].Cells["Title"].Value.ToString();
                string existingDescription = GridView1.SelectedRows[0].Cells["Description"].Value.ToString();
                DateTime existingDateCreated = (DateTime)(GridView1.SelectedRows[0].Cells["DateCreated"].Value);
                DateTime existingDueDate = (DateTime)(GridView1.SelectedRows[0].Cells["DueDate"].Value);

                TitleTextBox.Text = existingTitle;
                DescriptionTextBox.Text = existingDescription;
                DateCreatedTextBox.Value = existingDateCreated;
                DueDateTextBox.Value = existingDueDate;

                // Simulate an asynchronous delay (replace this with actual async work)
                await Task.Delay(1000); 
            }
            else
            {
                MessageBox.Show("Please select a task to edit");
            }
        }



        private async void LoadButton_Click(object sender, EventArgs e)
        {
            await LoadAllTaskAsync();
        }

        private async Task LoadAllTaskAsync()
        {
            try
            {
                string selectQuery = "SELECT * FROM myListTable";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, sqlConnection);
                DataTable dataTable = new DataTable();

                await Task.Run(() => adapter.Fill(dataTable)); // Execute the database query on a background thread

                GridView1.DataSource = dataTable;
               // GridView1.DataBindingComplete(); // Assuming you want to bind the data (for ASP.NET)        

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRows.Count > 0)
            {
                int selectedTaskId = Convert.ToInt32(GridView1.SelectedRows[0].Cells["ID"].Value);
                await DeleteTaskAsync(selectedTaskId);
                LoadTask();
            }
            else
            {
                MessageBox.Show("Please select a task to delete");
            }
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            if (GridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one or more tasks to delete");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected task(s) ?", "Confirm delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<int> selectedTaskIds = new List<int>();
                foreach (DataGridViewRow row in GridView1.SelectedRows)
                {
                    int taskIdToDelete = Convert.ToInt32(row.Cells["ID"].Value);
                    selectedTaskIds.Add(taskIdToDelete);
                }

                string deleteQuery = "DELETE FROM myListTable WHERE ID IN (" + string.Join(",", selectedTaskIds) + ")";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        await cmd.ExecuteNonQueryAsync(); // Use async version of ExecuteNonQuery
                        MessageBox.Show("SelectedTask(s) deleted successfully");
                        LoadTask();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }


        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string searchWord = SearchBox.Text.Trim();

            if (string.IsNullOrEmpty(searchWord))
            {
                MessageBox.Show("Please enter a search keyword");
                return;
            }

            // Call the asynchronous SearchTask method
            DataTable searchResults = await SearchTask(searchWord);

            GridView1.DataSource = searchResults;
            SearchBox.Clear();
        }

        private async Task<DataTable> SearchTask(string searchWord)
        {
            DataTable searchResults = new DataTable();
            try
            {
                string selectQuery = "SELECT * FROM myListTable WHERE Title LIKE @SearchWord OR Description LIKE @SearchWord";
                using (SqlCommand cmd = new SqlCommand(selectQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@SearchWord", "%" + searchWord + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    await Task.Delay(1000);
                    adapter.Fill(searchResults);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }
            return searchResults;
        }


    }
}