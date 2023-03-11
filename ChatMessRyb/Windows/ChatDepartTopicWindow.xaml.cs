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
    public partial class ChatDepartTopicWindow : Window
    {
        public static ChatDBEntities DB = new ChatDBEntities();
        public ChatDepartTopicWindow()
        {
            InitializeComponent();

            TBName.Text = AuthWindow.employee.Name;
            var chatRoom = ((Employee)AuthWindow.employee).Id_Employee;
            TopicLst.ItemsSource = DB.ChatMessage.Where(x => x.Id_Employee == chatRoom).ToList();
        }
    }
}
