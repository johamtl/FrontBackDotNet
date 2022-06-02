using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;// not using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using FrontBackClassLib;

//sqlClient 
// --SqlConnection
// --sqlCommand (DEFINE SQL COMMAND)
// --sqlDataReader (read EXECUTED SQLCOMMAND RESULT)

//using(...) block - manage resources --dispose method is called right after the block is done
//BinaryReader, BinaryWriter,DataTable, etc in Using() block

//Auto format : Ctrl+K, Ctrl+D

namespace ASPNETCOREWEBAPI.Data
{
    public class mySQL
    {
        private static string sqlconn = "Data Source=REGIS003;Initial Catalog=DotNet;Integrated Security=True; TrustServerCertificate=True ";
        static void mysqlConnection(string[] args)
        {
        }
        public static void searchById(string id)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                string searchString = "SELECT NAME FROM [DotNet].[dbo].[Users] WHERE ID =" + id;
                SqlCommand cmd = new SqlCommand(searchString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    Console.ReadLine();
                }
                reader.Close();
                conn.Close();
            }
        }

        public static List<Dog> searchDogById(int id) //passed
        {
            List<Dog> dogs = new List<Dog>();
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                string searchString = "SELECT * FROM Dogs1 WHERE ID =" + id;
                SqlCommand cmd = new SqlCommand(searchString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int weight = reader.GetInt32(0);    // Weight int
                    string name = reader.GetString(1);  // Name string
                    string breed = reader.GetString(2); // Breed string
                    int cid = reader.GetInt32(3);    // Weight int

                    dogs.Add(new Dog() { Id = cid, Weight = weight, Name = name, Breed = breed });

                }
                reader.Close();
                conn.Close();
                return dogs;
            }
        }
        public static void TryCreateDogTable() // tested
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "CREATE TABLE Dogs1 (Weight INT, Name TEXT, Breed TEXT, Id INT)", conn))
                    {
                        cmd.ExecuteNonQuery(); // different from cmd.ExecuteReader()
                    }
                }
                catch
                {
                    Console.WriteLine("Table not created.");
                }
            }
        }

        /// <summary>
        /// Insert dog data into the SQL database table.
        /// </summary>
        /// <param name="weight">The weight of the dog.</param>
        /// <param name="name">The name of the dog.</param>
        /// <param name="breed">The breed of the dog.</param>
        public static bool AddDog(int weight, string name, string breed, int id) //tested
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO Dogs1 VALUES(@Weight, @Name, @Breed, @Id)", conn))
                    {
                        command.Parameters.Add(new SqlParameter("Weight", weight)); //use Parameter to insert data. 
                        command.Parameters.Add(new SqlParameter("Name", name)); //One of the best practices
                        command.Parameters.Add(new SqlParameter("Breed", breed));
                        command.Parameters.Add(new SqlParameter("Id", id));

                        //if parameter is empty: var parameters = new SqlParameter[] { };
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Read in all rows from the Dogs1 table and store them in a List.
        /// </summary>
        public static List<Dog> DisplayDogs()// tested
        {
            List<Dog> dogs = new List<Dog>();
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1", conn))
                {
                    SqlDataReader reader = command.ExecuteReader(); //Use SqlDataAdapter if you want to bind table to controls
                    while (reader.Read())
                    {
                        int weight = reader.GetInt32(0);    // Weight int
                        string name = reader.GetString(1);  // Name string
                        string breed = reader.GetString(2); // Breed string
                        int id = reader.GetInt32(3); // Breed string

                        dogs.Add(new Dog() { Weight = weight, Name = name, Breed = breed, Id = id });
                    }
                }
            }
            return dogs;
        }

        /// <summary>
        /// Delete a dog record from the Dogs1 table by id.
        /// </summary>
        public static bool DeleteDog(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlconn))
                {
                    conn.Open();

                    string deleteString = "DELETE FROM Dogs1 WHERE ID = " + id;

                    using (SqlCommand command = new SqlCommand(deleteString, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }

            catch (SystemException ex)
            {
                return false;
            }
        }
    }
}
