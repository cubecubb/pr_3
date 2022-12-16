﻿using pr_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAut_click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxLogin.Text;
            string password = txtBoxPassword.Password;
            HashPassword.Passhash passhash = new HashPassword.Passhash();
            Helper helper = new Helper();
            UVD_BDEntities4 uVD_BD = Helper.GetContext();
            if (login == "")
            {
                if (password == "")
                {
                    MessageBox.Show("Введите логин и пароль");
                }
                else
                {
                    MessageBox.Show("Введите логин");
                }
            }
            else if (password == "")
            {
                MessageBox.Show("Введите пароль");
            }
            else
            {
                password = passhash.HashPassword(password);
                string result = helper.FindUsers(login, password);
                MessageBox.Show(result);
            }


        }
    }
}
