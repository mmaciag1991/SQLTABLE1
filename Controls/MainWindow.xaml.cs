using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SQLTABLE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            
            InitializeComponent();
            FillDataGrid();
            
        }
        
        private void FillDataGrid()
        {
            
            DataTable dt = new DataTable("Urser");

            SQL_Module.getUsersData().Fill(dt);
 
            grdEmployee.ItemsSource = dt.DefaultView;
            
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Shutdown();
            
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
        
    }
  
}