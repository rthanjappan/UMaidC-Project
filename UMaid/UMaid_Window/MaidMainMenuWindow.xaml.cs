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
using System.Windows.Shapes;
using DAL;
using Model;

namespace UMaid_Window
{
    /// <summary>
    /// Interaction logic for MaidProfileWindow.xaml
    /// </summary>
    public partial class MaidMainMenuWindow : Window
    {
        #region Window Fields
        List<Dto_User> users = new List<Dto_User>();
        Dto_User selectedUser = null;
        #endregion Window Fields

        public MaidMainMenuWindow()
        {
            InitializeComponent();
        }

        public MaidMainMenuWindow(Dto_User user)
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

           
            //using (UMaidEntities db = new UMaidEntities())
            //{
            //    //var n = db.UserTypeIDs.Where(c => c.UserTypeID1 == selectedUser.UserTypeID).SingleOrDefault();

            //    tbUserType.Text = n?.UserTypeDescription?? "N/A";
            //}
        }

        private void BtnMaidProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow maidProfileWindow = new ProfileWindow(selectedUser);

            maidProfileWindow.Show();
        }

        private void BtnSearchListing_Click(object sender, RoutedEventArgs e)
        {
            SearchListingWindow listingWindow = new SearchListingWindow(selectedUser);

            listingWindow.Show();
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
