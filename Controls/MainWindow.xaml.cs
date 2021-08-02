using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            
            foreach (User user in _users)
            {
                if (user.UserName.Equals(""))
                {

                    _users.Remove(user);
                }
            }
            
 
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

        private void GrdEmployee_OnMouseDown(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            User selectedUser = grdEmployee.SelectedItem as User;
            Debug.Assert(selectedUser != null, nameof(selectedUser) + " != null");
            Console.WriteLine(selectedUser.UserName);
            idTextBlock.Text = selectedUser.Id+"";
            loginTextBlock.Text = selectedUser.UserName;
            emailTextBlock.Text = selectedUser.Adress;
        }
        void OnApllyClick(object sender, RoutedEventArgs e)
        {
            User selectedUser = grdEmployee.SelectedItem as User;
            Debug.Assert(selectedUser != null, nameof(selectedUser) + " != null");
            Console.WriteLine(selectedUser.Id);
            foreach (var user in _users)
            {
                if (user.Id == selectedUser.Id)
                {
                    user.UserName = loginTextBlock.Text;
                    user.Adress = emailTextBlock.Text;
                    grdEmployee.Items.Refresh();
                }
            }
        }

        void OnUpdateUsers(object sender, RoutedEventArgs e)
        {
            SQL_Module.updateUser(_users);
            Message message = new Message();
            message.ownerWindow(this);
            message.showMessage("Dane użytkowników zostały zaktualizowane.",MessageType.Success);
            message.Topmost = true;
        }

    }
    
    
  
}