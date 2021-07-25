using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using SQLTABLE.ObservableLists;

namespace SQLTABLE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ObservableCollection<User> _users = SQL_Module.LoadUsersData();
        
        public MainWindow()
        {
            
            InitializeComponent();
            FillDataGrid();
            
        }
        
        private void FillDataGrid()
        {
            
            DataTable dt = new DataTable("Urser");

            //SQL_Module.getUsersData().Fill(dt);
            
            
 
            grdEmployee.ItemsSource = _users;


            _users.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(collectionChangedMethod);
            foreach (var user in _users)
            {
                Console.WriteLine("Id: "+user.Id+"  UserName: "+user.UserName+"  Password: "+user.Password+"  Adress: "+user.Adress);
            }
            
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
        
        private void collectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            //different kind of changes that may have occurred in collection
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(((User)item).Password);
                }
               //Console.WriteLine(e.NewItems);
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(((User)item).Password);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(((User)item).Password);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(((User)item).Password);
                }
            }
        }
        
    }
    
    
  
}