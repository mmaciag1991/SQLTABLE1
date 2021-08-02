using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SQLTABLE
{
    public partial class Message : Window
    {
        public bool isWindowActive = true;
        private MainWindow mainWindow;
        private MessageType _messageType = MessageType.Success;
        
        public Message()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (_messageType == MessageType.Success)
            {
                mainWindow.Show();
            }
            
            this.Hide();
        }

        public void showMessage(string message, MessageType messageType)
        {
            txbMessage.Text = message;
            _messageType = messageType;
            switch (messageType)
            {
                case MessageType.Success:
                    txbType.Text = "Sukces";
                   Image_stat.Source = new BitmapImage(new Uri(@"pack://application:,,,/../Images/success-icon-23192.png"));
                    break;
                case MessageType.Error:
                    txbType.Text = "Błąd";
                    Image_stat.Source = new BitmapImage(new Uri(@"pack://application:,,,/../Images/error-48268.png"));
                    break;
                case MessageType.Information:
                    txbType.Text = "Informacja";
                    Image_stat.Source = new BitmapImage(new Uri(@"pack://application:,,,/../Images/error-48268.png"));
                    break;
                case MessageType.Warning:
                    txbType.Text = "Ostrzeżenie";
                    Image_stat.Source = new BitmapImage(new Uri(@"pack://application:,,,/../Images/error-48268.png"));
                    break;
            }
            
            this.Show();

        }


        public void ownerWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
    
    
}