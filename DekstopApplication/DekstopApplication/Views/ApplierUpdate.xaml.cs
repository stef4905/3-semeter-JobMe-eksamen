using DekstopApplication.ApplierServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ApplierUpdate.xaml
    /// </summary>
    public partial class ApplierUpdate : UserControl
    {
        public ObservableCollection<BoolStringClass> Categories { get; set; }


        ApplierServiceClient applierClient = new ApplierServiceClient();
        Applier applierG = new Applier();
        public ApplierUpdate(Applier applier)
        {

            InitializeComponent();
            applierG = applier;
            EmailInput.Text = applier.Email;
            FNameInput.Text = applier.FName;
            LNameInput.Text = applier.LName;
            BirtdatePicker.Text = Convert.ToString(applier.Birthdate);
            AdressInput.Text = applier.Address;
            PhoneInput.Text = Convert.ToString(applier.Phone);
            DescriptionInput.Text = applier.Description;
            HomePageInput.Text = applier.HomePage;
            CurrentJobInput.Text = applier.CurrentJob;
            CreateCheckBoxList();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Applier applier = applierG;

            if (!Regex.IsMatch(EmailInput.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                FailCheckLabel.Content = "Skriv en valid email";
            }

            else
            {

                applier.Email = EmailInput.Text;
                applier.FName = FNameInput.Text;
                applier.LName = LNameInput.Text;
                applier.Birthdate = Convert.ToDateTime(BirtdatePicker.Text);
                applier.Address = AdressInput.Text;
                applier.Phone = Convert.ToInt32(PhoneInput.Text);
                applier.Description = DescriptionInput.Text;
                applier.HomePage = HomePageInput.Text;
                applier.CurrentJob = CurrentJobInput.Text;


                applierClient.Update(applier);
            }
        }



        public class BoolStringClass
        {
            public string TheText { get; set; }
            public int TheValue { get; set; }
            public bool check { get; set; }
        }
        public void CreateCheckBoxList()
        {
            

            //TheList = new ObservableCollection<BoolStringClass>();
            //TheList.Add(new BoolStringClass { TheText = "EAST", TheValue = 1 });
            //TheList.Add(new BoolStringClass { TheText = "WEST", TheValue = 2 });
            //TheList.Add(new BoolStringClass { TheText = "NORTH", TheValue = 3 });
            //TheList.Add(new BoolStringClass { TheText = "SOUTH", TheValue = 4 });
            //this.DataContext = this;
        }


    }


}

