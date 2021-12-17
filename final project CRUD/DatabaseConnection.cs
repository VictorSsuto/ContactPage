using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace final_project_CRUD
{
    class DatabaseConnection
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        
     //read contact
        public List<ContactCollection> getAllContacts() {
            List<ContactCollection> contact = new List<ContactCollection>();

            using (var connection = new SqlConnection(connectionString))
            {                                      //* to read all 
                SqlCommand command = new SqlCommand("Select * from UserDetail", connection);

                connection.Open();

                using (SqlDataReader sqlDataReader = command.ExecuteReader())
                {
                    if (!sqlDataReader.HasRows)
                    {
                        Console.WriteLine("No Records Found");
                    }
                    else
                    {
                        while (sqlDataReader.Read())
                        {
                            ContactCollection c = new ContactCollection((int)sqlDataReader["Id"], (string)sqlDataReader["First_name"], (string)sqlDataReader["Last_name"], (int)sqlDataReader["age"],(int)sqlDataReader["Phone_number"],
                                                            (string)sqlDataReader["Email"]);
                            contact.Add(c);
                        }
                    }
                }
            }
            return contact;

        }

      //Creates contact
        public int CreateContact(ContactCollection contact) 
        {
            int returnId = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO UserDetail ( First_Name, Last_Name, Age, Phone_Number, Email) VALUES ( @First_Name, @Last_Name, @age, @Phone_Number, @Email)";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@First_Name", contact.First_name);
            command.Parameters.AddWithValue("@Last_Name", contact.Last_name);
            command.Parameters.AddWithValue("@age", contact.Age);
            command.Parameters.AddWithValue("@Phone_Number", contact.Phone_number);
            command.Parameters.AddWithValue("@Email", contact.Email);

            try
            {
                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Contact Inserted Successfully");

                string query2 = "Select @@Identity as newId from UserDetail";
                command.CommandText = query2;
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                returnId = Convert.ToInt32(command.ExecuteScalar());


            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return returnId;

        }

        //reads the specific contact regarding the ID
        public ContactCollection getContact(int id) 
        {
            ContactCollection c = null;

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Select * from UserDetail where id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                using (SqlDataReader SqlDataReader = command.ExecuteReader())
                {
                    if (!SqlDataReader.HasRows)
                    {
                        Console.WriteLine("No contacts Found");
                    }
                    else
                    {
                        SqlDataReader.Read();
                        c = new ContactCollection((int)SqlDataReader["Id"], (string)SqlDataReader["First_name"], (string)SqlDataReader["Last_name"], (int)SqlDataReader["Age"], (int)SqlDataReader["Phone_number"],
                                                            (string)SqlDataReader["Email"]);
                    }
                }
            }
            return c;
        }





        //updates the contact using ID
        public void UpdateContact(ContactCollection contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE UserDetail set First_Name = @First_Name, Last_Name =  @Last_Name, Phone_Number = @Phone_Number,Email = @Email, Age=@age, where Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", contact.Id);
            command.Parameters.AddWithValue("@First_Name", contact.First_name);
            command.Parameters.AddWithValue("@Last_Name", contact.Last_name);
            command.Parameters.AddWithValue("@Age", contact.Age);
            command.Parameters.AddWithValue("@Phone_Number", contact.Phone_number);
            command.Parameters.AddWithValue("@Email", contact.Email);

            try
            {
                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Contact Updated ");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Details: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }

        }

        //Deletes a contact using ID 
        public void DeleteContact(ContactCollection contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "DELETE FROM UserDetail WHERE Id = @Id";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", contact.Id);

            try
            {
                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Contact Deleted ");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Details: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }

        }


    }
}
