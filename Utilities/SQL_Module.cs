using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using SQLTABLE.ObservableLists;

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
                                    dr.Close();
                                    con.Close();
                                    return true;
                                }
                                else
                                {
                                    dr.Close();
                                    con.Close();
                                    return false;
                                }
                            }
                            else
                            {
                                dr.Close();
                                con.Close();
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
         
         static public ObservableCollection<User> LoadUsersData()
         {  
             
             ObservableCollection<User> users = new ObservableCollection<User>();
             try
             {
                    string CmdString = "SELECT Id, UsrName, Password, EmailAddress FROM Urser";
 
                    SqlCommand cmd = new SqlCommand(CmdString, con);

                    if ((con.State & ConnectionState.Open) == 0)
                    {
                        con.Open(); 
                    }
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string password = reader.GetString(2);
                    string adress = reader.GetString(3);
                    if (id != null)
                    {
                          users.Add(new User(id, name, password, adress));
                    }
                  
                }
                 con.Close();
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                // throw;
             }
            
             return users;
         }

         static public void updateUser(ObservableCollection<User> users)
         {
           
             con.Open();
             foreach (var user in users)
             {
                 
                 String st = "UPDATE Urser SET UsrName='" + user.UserName + "', EmailAddress='" + user.Adress + "' WHERE Id='" + user.Id + "';";
                 
                              SqlCommand sqlcom = new SqlCommand(st, con);
                              try
                              {
                                  sqlcom.ExecuteNonQuery();
                              }
                              catch (SqlException ex)
                              {
                                  MessageBox.Show(ex.Message);
                              }
             }
             con.Close();
         }
    }

}