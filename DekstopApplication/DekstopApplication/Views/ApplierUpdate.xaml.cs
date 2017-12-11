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
        public ObservableCollection<BoolStringClass> CategoryList { get; set; }


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
            // Checks to see if the Apllier has a image or else it sets the default image(Apllier IMAGE)
            Uri imageUri = null;
            if (applier.ImageURL != null)
            {
                imageUri = new Uri(applier.ImageURL, UriKind.Absolute);
            }
            else
            {
                imageUri = new Uri("https://i.imgur.com/Csasjwt.png", UriKind.Absolute);
            }
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            ApplierImage.Source = imageBitmap;
            CreateCheckBoxList();
        }

        /// <summary>
        /// Method for when the back button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Updates an Applier by pression the update button on the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Applier applier = applierG;

            if (!Regex.IsMatch(EmailInput.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                FailCheckLabel.Content = "Skriv en valid email";
            }

            else if (EmailInput.Text == "" || FNameInput.Text == "" || LNameInput.Text == "" || BirtdatePicker.Text == "" || AdressInput.Text == ""
                || PhoneInput.Text == "" || DescriptionInput.Text == "" || HomePageInput.Text == "" || CurrentJobInput.Text == "")
            {
                FailCheckLabel.Content = "Alle felter skal være udfyldt!";
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Er du sikker på du vil opdatere" + applier.FName + applier.LName +"?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
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
                    if (applier.JobCategoryList != null)
                    {
                        applier.JobCategoryList.Clear();
                    }
                    List<JobCategory> jobList = new List<JobCategory>();

                    foreach (var item in CategoryList.Where(m => m.Cheeked))
                    {
                        JobCategory jobCategory = new JobCategory
                        {
                            Id = item.TheValue

                        };

                        jobList.Add(jobCategory);

                    }
                    applier.JobCategoryList = jobList;
                    applierClient.Update(applier);
                    SuccesCheck.Content = "Brugeren er opdateret!";
                    FailCheckLabel.Content = "";
                }

                else if (result == MessageBoxResult.No)
                {
                    //No Code here
                }

            }
               
        }


        /// <summary>
        /// Class made to the CategoryList, to make checkboxes
        /// </summary>
        public class BoolStringClass : CheckBox
        {
            public string TheText { get; set; }
            public int TheValue { get; set; }
            public bool Cheeked { get; set; }
        }

        /// <summary>
        /// Create the checkboxlist, by getting the jobCategory data from the JobPost client
        /// </summary>
        public void CreateCheckBoxList()
        {
            JobPostServiceReference.JobPostServiceClient jobClient = new JobPostServiceReference.JobPostServiceClient();

            List<JobPostServiceReference.JobCategory> CategoriesList = jobClient.GetAllJobCategories();

            CategoryList = new ObservableCollection<BoolStringClass>();

            foreach (var Category in CategoriesList)
            {

                CategoryList.Add(new BoolStringClass { TheText = Category.Title, TheValue = Category.Id });
            }

         
            this.DataContext = this;
        }



        /// <summary>
        /// Cheks if the checkbox is unchecked and seets CategoryLists cheeked to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxZone_UnChecked(object sender, RoutedEventArgs e)
        {

            CheckBox clickedBox = (CheckBox)sender;

            foreach (var item in CategoryList.Where(m => m.TheValue == Convert.ToInt32(clickedBox.Tag.ToString())))
            {
                if (clickedBox.IsEnabled)
                {

                    item.Cheeked = false;
                }
            }

        }

        /// <summary>
        /// Cheks if the checkbox is checked and seets CategoryLists cheeked to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;
            foreach (var item in CategoryList.Where(m => m.TheValue == Convert.ToInt32(clickedBox.Tag.ToString())))
            {
                if (clickedBox.IsEnabled)
                {
                    item.Cheeked = true;
                }

            }

        }


    }


}

