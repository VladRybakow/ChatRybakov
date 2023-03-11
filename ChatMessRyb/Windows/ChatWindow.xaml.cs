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
    public partial class ChatWindow : Window
    {
        public static ChatDBEntities DB = new ChatDBEntities();
        ChatMessage message;
        public ChatWindow(ChatMessage chatMessager)
        {
            InitializeComponent();
            this.message = chatMessager;
            TBName.Text = message.Chatroom.Topic;

            var chatRoom = ((Employee)AuthWindow.employee).Id_Employee;
            List<ChatMessage> chatMessages = DB.ChatMessage.Where(x => x.Id_Chatroom == chatRoom).ToList();
            List<ChatMessage> distinct = chatMessages.Distinct().ToList();

            MemberLst.ItemsSource = distinct.ToList();
            ChatLst.ItemsSource = chatMessages.ToList();
        }

        private void SendBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ChatMessage chat = new ChatMessage();
                var chatRoom = ((Employee)AuthWindow.employee).Id_Employee;
                List<ChatMessage> chatMessages = DB.ChatMessage.Where(x => x.Id_Chatroom == chatRoom).ToList();
                chat.Id_Employee = message.Id_Employee;
                chat.Id_Chatroom = message.Id_Chatroom;
                chat.Date = DateTime.Now;
                chat.Message = TBText.Text;
                DB.ChatMessage.Add(chat);
                DB.SaveChanges();

                ChatLst.ItemsSource = chatMessages.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                var chatRoom = ((Employee)AuthWindow.employee).Id_Employee;
                List<ChatMessage> chatMessages = DB.ChatMessage.Where(x => x.Id_Chatroom == chatRoom).ToList();
                ChatLst.ItemsSource = chatMessages.ToList();

            }
        }
    }
}
