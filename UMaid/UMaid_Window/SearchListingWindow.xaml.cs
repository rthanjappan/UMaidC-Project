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
using DAL;
using Model;

namespace UMaid_Window
{
    /// <summary>
    /// Interaction logic for SearchListing.xaml
    /// </summary>
    public partial class SearchListingWindow : Window
    {
        #region Window Fields
        List<Dto_User> users = new List<Dto_User>();
        Dto_User selectedUser = null;
        #endregion Window Fields

        public SearchListingWindow()
        {
            InitializeComponent();
        }

        public SearchListingWindow(Dto_User user)
        {
            InitializeComponent();

            selectedUser = user;
        }

        private void btnSubmitBidWindow_Click(object sender, RoutedEventArgs e)
        {
            SubmitBidWindow submitBidWindow = new SubmitBidWindow(selectedUser);

            submitBidWindow.Show();
        }
    }
}
