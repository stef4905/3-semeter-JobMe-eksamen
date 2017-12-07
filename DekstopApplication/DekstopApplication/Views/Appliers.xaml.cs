﻿using System;
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
        public Appliers()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateApplierButton_Click(object sender, RoutedEventArgs e)
        {
            GuiPanelApplierCreate.Children.Clear();
            GuiPanelApplierCreate.Children.Add(applierCreateView);
        }
    }
}
