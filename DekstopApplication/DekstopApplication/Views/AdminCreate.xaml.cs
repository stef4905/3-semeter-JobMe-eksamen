using DekstopApplication.AdminServiceReference;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for AdminCreate.xaml
    /// </summary>
    public partial class AdminCreate : UserControl
    {
        

        AdminServiceClient adminClient = new AdminServiceClient();
        public AdminCreate()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            string Username = UsernameInput.Text.ToLower();
            string Password = PasswordInput.Password.ToString();
            string PasswordRepeat = PasswordRepeatInput.Password.ToString();

            AdminServiceReference.Admin admin = new AdminServiceReference.Admin
            {
                Username = Username,
                Password = Password
            };

            if(Password != PasswordRepeat)
            {
                FailCheckLabel.Content = "Kodeordet stemmer ikke overens";
            }
            else
            {
                Admin adminView = new Admin();
                

                adminClient.Create(admin);


                GuiPanelCreateAdmin.Children.Clear();
                GuiPanelCreateAdmin.Children.Add(adminView);
                
                
                //BindingExpression binding = adminView.AdminTable.GetBindingExpression(ListView.)


                //adminView.adminList = adminClient.GetAllAdmin();
                //adminView.AdminTable.ItemsSource = adminList;
                //((Panel)this.Parent).Children.Remove(this);




            }
        }
    }
}
