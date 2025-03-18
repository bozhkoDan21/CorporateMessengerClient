using System.Windows;
using System.Windows.Controls;

namespace CorporateMessenger.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadChats();
        }

        private void LoadChats()
        {
            ChatList.Items.Add(new { ChatName = "Общий чат" });
            ChatList.Items.Add(new { ChatName = "Рабочая группа" });
            ChatList.Items.Add(new { ChatName = "Друзья" });
        }

        private void ChatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChatList.SelectedItem is not null)
            {
                dynamic selectedChat = ChatList.SelectedItem;
                ChatTitle.Text = selectedChat.ChatName;
                MessagesPanel.Children.Clear();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchPlaceholder.Visibility = string.IsNullOrWhiteSpace(SearchBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageBox.Text))
            {
                TextBlock message = new TextBlock
                {
                    Text = MessageBox.Text,
                    FontSize = 16,
                    Foreground = System.Windows.Media.Brushes.White,
                    Margin = new Thickness(5),
                    TextWrapping = TextWrapping.Wrap
                };

                MessagesPanel.Children.Add(message);
                MessageBox.Clear();
            }
        }
    }
}
