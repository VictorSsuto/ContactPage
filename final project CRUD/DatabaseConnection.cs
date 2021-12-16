﻿using System;
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
        
        //read all contacts 
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
                            ContactCollection c = new ContactCollection((int)sqlDataReader["Id"], (string)sqlDataReader["First_Name"], (string)sqlDataReader["Last_Name"], (string)sqlDataReader["Phone_Number"],
                                                            (string)sqlDataReader["Email"]);
                            contact.Add(c);
                        }
                    }
                }
            }
            return contact;

        }

        //adds contact
        public int InsertContact(ContactCollection contact) 
        {
            int returnId = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO UserDetail ( First_Name, Last_Name, Phone_Number, Email) VALUES ( @First_Name, @Last_Name, @Phone_Number, @Email)";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@First_Name", contact.First_Name);
            command.Parameters.AddWithValue("@Last_Name", contact.Last_Name);
            command.Parameters.AddWithValue("@Phone_Number", contact.Phone_Number);
            command.Parameters.AddWithValue("@Email", contact.Email);

            try
            {
                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Contact Inserted Successfully");

                string query2 = "Select @@Identity as newId from Contact_Information";
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


        public ContactCollection getContact(int id) // reads/views specefic contact corespnsding to chosen Id, Works in conjunction with Updating a contact based on it's Id
        {
            ContactCollection c = null;

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Select * from UserDetail where id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                using (SqlDataReader SqlDataReader = command.ExecuteReader())
                {
                    if (!sdr.HasRows)
                    {
                        Console.WriteLine("No contacts Found");
                    }
                    else
                    {
                        SqlDataReader.Read();
                        c = new ContactCollection((int)SqlDataReader["id"], (string)SqlDataReader["First_Name"], (string)SqlDataReader["Last_Name"], (string)SqlDataReader["Phone_Number"], (string)SqlDataReader["Email"]);

                    }
                }
            }
            return c;
        }






        public void UpdateContact(ContactCollection contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE UserDetail set First_Name = @First_Name, Last_Name = @Last_Name, Phone_Number = @Phone_Number,Email = @Email where Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", contact.Id);
            command.Parameters.AddWithValue("@First_Name", contact.First_Name);
            command.Parameters.AddWithValue("@Last_Name", contact.Last_Name);
            command.Parameters.AddWithValue("@Phone_Number", contact.Phone_Number);
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


        public void DeleteContact(ContactCollection contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            // string query = "UPDATE Contact_Information set First_Name = @First_Name, Last_Name = @Last_Name, Phone_Number = @Phone_Number,Email = @Email where Id = @Id";
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