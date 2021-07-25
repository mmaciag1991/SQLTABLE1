using System;

namespace SQLTABLE.ObservableLists
{
    public class User
    {
        private int id;
        private string userName;
        private string password;
        private string adress;

        public User()
        {
            id = -1;
            userName = "";
            password = "";
            adress = "";
        }

        public User(int id, string userName, string password, string adress)
        {
            this.id = id;
            this.userName = userName;
            this.password = password;
            this.adress = adress;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

    }
}