using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLTABLE
{
    public static class SQL_Module
    {
         static SqlConnection con;
         static SqlCommand com = new SqlCommand();
         static SqlDataReader dr;

                
                
         static SQL_Module() 
         {
             try
             {
              if (Environment.MachineName.Equals("DESKTOP-A3AGJ6G"))
                 {
                       con = new SqlConnection("Data Source=DESKTOP-A3AGJ6G\\SQLEXPRESS01; Integrated Security=True; Initial Catalog=store;");
                 }
                 else
                 {
                     con = new SqlConnection("Data Source=PL1337\\SQLEXPRESS; Integrated Security=True; Initial Catalog=store;");
                 }

             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 showErrorMessage();
             }
           
             
             
             //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString.ToString();
                    
                }

         public static SqlConnection startConnection()
                {
                    try
                    {
                                 if (con.State == System.Data.ConnectionState.Open)
                                 {
                                     con.Close();
                                 }
                                 con.Open();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e);
                        showErrorMessage();
                    }

                    return com.Connection = con;
                }

         public static bool VerifyUser(string username, string password)
                 {

                     startConnection();
                            
                            com.CommandText = "select Status from Urser where UsrName='"+username+"' and Password='"+password+"'";
                            dr = com.ExecuteReader();
                     
                            if (dr.Read())
                            {
                                if(!dr["Status"].Equals("1"))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }

         public static SqlDataAdapter getUsersData()
                 {
                     startConnection();
                     
                     string CmdString = "SELECT Id, UsrName, FullName, EmailAddress FROM Urser";
 
                         SqlCommand cmd = new SqlCommand(CmdString, con);
 
                         SqlDataAdapter sda = new SqlDataAdapter(cmd);

                         return sda;
                     }

         private static void showErrorMessage()
         {
             Message message = new Message();
             message.Width = 800;
             message.Topmost = true;
             message.showMessage("Sprawdz połączene z baządanych. " + con.DataSource,MessageType.Error);
         }
    }
    
}