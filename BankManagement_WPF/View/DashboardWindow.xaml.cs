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
using System.Windows.Shapes;

namespace BankManagement_WPF.View
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //do my stuff before closing
            new LoginWindow().Show();
            base.OnClosing(e);
        }


        private void ApplyLoanButton_Click(object sender, RoutedEventArgs e)
        {
            new ApplyLoanWindow().Show();
            this.Hide();
        }
        private void UpdateDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateUserDetailWindow().ShowDialog();
        }
        private void PreviousLoanButton_Click(object sender, RoutedEventArgs e)
        {
            new PreviousAppliedLoansWindow().ShowDialog();
        }
        
    }
}
