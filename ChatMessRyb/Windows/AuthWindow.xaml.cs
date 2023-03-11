using ChatMessRyb.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatMessRyb.Windows
{
    public partial class AuthWindow : Window
    {
        public static ChatDBEntities DB = new ChatDBEntities();
        public static Employee employee;
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void AuthBTNClick(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "" || TBPassword.Text == "")
            {
                MessageBox.Show("Введите логин и пароль!");
            }
            foreach (var user in DB.Employee)
            {
                if (user.UserName == TBName.Text.Trim())
                {
                    if (user.Password == TBPassword.Text.Trim())
                    {
                        MessageBox.Show($"Здравствуйте, заместитель директора : {user.Name}");

                        employee = user;

                        ChatDepartTopicWindow main = new ChatDepartTopicWindow();
                        this.Close();
                        main.Show();
                    }
                }
            }
        }

        private void CancelBTNClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
