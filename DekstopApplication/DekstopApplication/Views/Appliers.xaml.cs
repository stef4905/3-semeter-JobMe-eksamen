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
        //Instance variables
        ApplierCreate applierCreateView = new ApplierCreate();
        ApplierServiceClient applierClient = new ApplierServiceClient();
        public List<Applier> applierList = new List<Applier>();
        public Applier ApplierSelected = null; //Used to keet knowlegde of who the current selected applier is
        private int LastIndexSeletected;

        /// <summary>
        /// Constructor for the Applier User Control View
        /// </summary>
        public Appliers()
        {
            InitializeComponent();
            UpdateTableAndList();
            //applierCreateView.TheFunc = UpdateTableAndList;
        }

        /// <summary>
        /// Updates the tabel with all new Appliers from the database
        /// </summary>
        public void UpdateTableAndList()
        {
            applierList = applierClient.GetAllAppliers();
            ApplierTable.ItemsSource = applierList;
        }

        /// <summary>
        /// Opens the User Control view for creating a new Applier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateApplierButton_Click(object sender, RoutedEventArgs e)
        {
            GuiPanelApplier.Children.Clear();
            GuiGridApplier.Children.Add(applierCreateView);
            applierCreateView.TheFunc = UpdateTableAndList;
        }


        /// <summary>
        /// Opens the new User Control view for updating the selected Applier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Deletes the selected Applier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteApplier(object sender, RoutedEventArgs e)
        {
            if (ApplierTable.SelectedIndex >= 0)
            {
                Applier applier = (Applier)ApplierTable.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Er du sikker på du vil slette " + ApplierSelected.Email, "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    applierClient.Delete(ApplierSelected.Id);
                    MessageBox.Show("Ansøgeren " + ApplierSelected.Email + " er blevet slettet!");
                    UpdateTableAndList();
                }
                else if (result == MessageBoxResult.No)
                {
                    // No code here
                }
            }
            else
            {
                MessageBox.Show("Du har ikke valgt en ansøger!");
            }


        }

        /// <summary>
        /// Search function to find specific Appliers on the table.
        /// When found the ApplierTable is updated list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Sets the table back to the applierList.
        /// removes the text currently in the ApplierSearchBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllCurentAppliers(object sender, RoutedEventArgs e)
        {
            ApplierTable.ClearValue(ListView.ItemsSourceProperty);
            ApplierTable.ItemsSource = applierList;
            ApplierSearchBox.Text = "";
        }

        private void ApplierTable_SelectedApplier(object sender, SelectionChangedEventArgs e)
        {
            int index;

            if (ApplierTable.SelectedIndex >= 0)
            {
                index = ApplierTable.SelectedIndex;
            }
            else
            {
                index = LastIndexSeletected;
            }
            ApplierSelected = applierList[index];
        }
    }
}
