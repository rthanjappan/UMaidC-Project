using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DAL;
using Model;

namespace UMaid_Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerMainMenuWindow : Window
    {
        #region Window Fields
        List<Dto_User> users = new List<Dto_User>();
        Dto_User selectedUser = null;
        #endregion Window FIelds

        public CustomerMainMenuWindow()
        {
            InitializeComponent();
        }

        public CustomerMainMenuWindow(Dto_User user)
        {
            InitializeComponent();
            UMaidServiceReference.Service1Client
                svc = new UMaidServiceReference.Service1Client();
           
                Dto_User userRecordFromDB =
                    svc.GetUserByUserID(user);
            if (!userRecordFromDB.Error)
            {
                selectedUser = userRecordFromDB;
                
            }
            else
            {
                selectedUser = user;
            }
            this.DataContext = selectedUser;
            Dto_UserType userType = svc.GetUserType(selectedUser);
            tbUserType.Text = userType.UserTypeDescription;

           
            using (UMaidEntities db = new UMaidEntities())
            {
                //var n = db.USEs.Where(c => c.UserTypeID1 == selectedUser.UserTypeID).SingleOrDefault();

                //tbUserType.Text = n?.UserTypeDescription?? "N/A";
            }
        }

        private void BtnCustomerProfileWindow_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow customerProfileWindow = new ProfileWindow(selectedUser);

            customerProfileWindow.Show();
        }

        private void BtnManagePropertyWindow_Click(object sender, RoutedEventArgs e)
        {
            ManagePropertyWindow propertyWindow = new ManagePropertyWindow(selectedUser);

            propertyWindow.Show();
        }

        private void BtnManageListingWindow_Click(object sender, RoutedEventArgs e)
        {
            ManageListingWindow listingWindow = new ManageListingWindow();

            listingWindow.Show();
        }

        private void BtnViewBidWindow_Click(object sender, RoutedEventArgs e)
        {
            ViewActiveBidsWindow bidWindow = new ViewActiveBidsWindow();

            bidWindow.Show();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            selectedUser = null;

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            this.Close();
        }
    }
}
