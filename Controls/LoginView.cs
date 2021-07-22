using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SQLTABLE
{
    public partial class LoginView
    {
        
        Message message = new Message();
        
        public LoginView()
        {
            InitializeComponent();

        
                initializeConnection();
           

            //ProgressBar.Visibility = Visibility.Hidden;
            //ProgressBar.Value = 50;
        }
        
       
       

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            if (SQL_Module.VerifyUser(txtUsername.Text, txtPassword.Password))
            {
               // MessageBox.Show("Zalogowano pomyślnie", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

               
               message.showMessage("Zalogowano pomyślnie",MessageType.OK);
               
               message.Topmost = true;
               MainWindow mainWindow = new MainWindow();
               message.ownerWindow(mainWindow);
               
              // mainWindow.Show();
               Hide();
            }
            else
            {
                message.showMessage("Nie poprawny login lub hasło",MessageType.Error);
                message.Topmost = true;
            }
        }
        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void initializeConnection()
        {
            ProgressBar.Visibility = Visibility.Visible;

            if ((SQL_Module.startConnection().State & ConnectionState.Open) != 0)
            {
                network_icon.Foreground = new SolidColorBrush(Colors.Green);
                ProgressBar.Visibility = Visibility.Hidden;
            }
            else
            {
                txtUsername.IsEnabled = false;
                txtPassword.IsEnabled = false;
                btnLogin.IsEnabled = false;
                network_icon.MouseDoubleClick += delegate(object sender, MouseButtonEventArgs e)
                {
                   
                        initializeConnection();
                  
                };
            }
            
        }
      
    }
}
