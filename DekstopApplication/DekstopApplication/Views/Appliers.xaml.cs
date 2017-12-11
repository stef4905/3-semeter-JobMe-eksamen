using DekstopApplication.ApplierServiceReference;
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
    /// Interaction logic for Appliers.xaml
    /// </summary>
    public partial class Appliers : UserControl
    {
        ApplierCreate applierCreateView = new ApplierCreate();
        ApplierServiceClient applierClient = new ApplierServiceClient();
        public List<Applier> applierList = new List<Applier>();
        public Appliers()
        {
            InitializeComponent();
            UpdateTable();
            applierCreateView.TheFunc = UpdateTable;
        }

        public void UpdateTable()
        {
            applierList = applierClient.GetAllAppliers();
            ApplierTable.ItemsSource = applierList;
        }
        public class ApplierItems
        {
            public string Email { get; set; }
            public string Fornavn { get; set; }
            public string Efternavn { get; set; }
            public string Telefon { get; set; }
        }

    

        private void CreateApplierButton_Click(object sender, RoutedEventArgs e)
        {
            GuiPanelApplier.Children.Clear();
            GuiGridApplier.Children.Add(applierCreateView);
        }

        private void UpdateApplierButton_Click(object sender, RoutedEventArgs e)
        {
            Applier applier = (Applier)ApplierTable.SelectedItem;


            if (applier == null)
            {
                FailCheckLabel.Content = "Vælg en ansøger at opdatere";
            }
            else
            {
                ApplierUpdate applierUpdateView = new ApplierUpdate(applier);
                GuiPanelApplier.Children.Clear();
                GuiGridApplier.Children.Add(applierUpdateView);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Applier applier = (Applier)ApplierTable.SelectedItem;

            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil slette", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                applierClient.Delete(applier.Id);
            }
            else if (result == MessageBoxResult.No)
            {
                // No code here
            }
            

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Applier> ApplierSearchList = new List<Applier>();
            foreach (var applier in applierList)
            {
                int id;
                bool result = Int32.TryParse(ApplierSearchBox.Text, out id);

        

                if ((applier.FName != null && applier.FName.ToLower().Contains(ApplierSearchBox.Text.ToLower())) || (applier.FName != null && applier.LName.ToLower().Contains(ApplierSearchBox.Text.ToLower())) || applier.Email.ToLower().Contains(ApplierSearchBox.Text.ToLower()) || (applier.Phone.ToString() != null && applier.Phone.ToString().Contains(ApplierSearchBox.Text.ToLower())))
                {
                    ApplierSearchList.Add(applier);
                }

                else if (result)
                {
                    if (applier.Id == id)
                    {
                        ApplierSearchList.Add(applier);
                    }
                }
            }
            if (ApplierSearchList.Count != 0)
            {
                ApplierTable.ClearValue(ListView.ItemsSourceProperty);
                ApplierTable.ItemsSource = ApplierSearchList;
            }
        }
    }
}
