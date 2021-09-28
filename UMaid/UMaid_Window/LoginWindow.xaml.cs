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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region LoginFields
        public Dto_User selectedUser = null;
        #endregion LoginFields

        public LoginWindow()
        {
            InitializeComponent();


        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (isValidLogin())
            {
                TestMethods();
                switch (selectedUser.UserTypeID)
                {
                    case 1:
                        MessageBox.Show("Logging  in  as customer");
                        CustomerMainMenuWindow customerMainWindow = new CustomerMainMenuWindow(selectedUser);
                        customerMainWindow.Show();
                        break;

                    case 2:
                        MessageBox.Show("Logging  in  as maid");
                        MaidMainMenuWindow maidMainWindow = new MaidMainMenuWindow(selectedUser);
                        maidMainWindow.Show();
                        break;
                    default :
                        MessageBox.Show("Error : user type is not specified");
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password");
            }
        }

        private bool isValidLogin()
        {
            Dto_User user = new Dto_User();

            user.Email = tbEmail.Text;
            user.Password = tbPassword.Password.ToString();

            using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
            {
                user = svc.GetUser(user);
                
                if (!user.Error)
                {
                    setSelectedUser(user);
                    MessageBox.Show("The user is : " + user.ToString());
                    return true;
                }
            }

                return false;
        }

        private void setSelectedUser(Dto_User user)
        {
            selectedUser = user;
        }

        private void BtnRegistrationWindow_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();

            registrationWindow.Show();
        }

        // Testing methods only
        private void TestMethods()
        {
            #region TestUpdatingUser
            Dto_User updatableUser = new Dto_User()
            {
                UserID = 11076,
                FName = "Colins",
                LName = "Changed",
                UserTypeID = 1,
                Email = "cchanged1@umaid.com",
                Password = "UMaid_c1",
                PhoneNumber = "1112229999",
                StreetName = "Changing Dr",
                City = "ChangeCity",
                PostalCode = "00000",
                State = "CH",
                StartDate = System.DateTime.Now,
                Rating = 0.5,
                NumOfRatings = 10
            };

            MessageBox.Show("Updating user : " + updatableUser.ToString());

            UMaidServiceReference.Service1Client svc =
                new UMaidServiceReference.Service1Client();
            Dto_Bool b = svc.UpdateUser(updatableUser);

            if (b.success)
            {
                MessageBox.Show("Updating user was successful  : " + updatableUser.ToString());

            }
            else
            {
                MessageBox.Show("Updating user was unsuccessful!!!");

            }
            # endregion TestUpdatingUser

            #region TestDeletingUser
            //UMaidServiceReference.Service1Client svc2 =
            //    new UMaidServiceReference.Service1Client();
            //Dto_User u= new Dto_User() { UserID = 11062 };
            //Dto_Bool b = svc2.DeleteUser(u);
            //if (b.success)
            //{
            //    MessageBox.Show("Deleting user was successful  : " +
            //        u.ToString());

            //}
            //else
            //{
            //    MessageBox.Show("Deleting user was unsuccessful!!!");

            //}
            #endregion TestDeletingUser


            #region TestGetAllUsers
            //UMaidServiceReference.Service1Client svc3 =
            //    new UMaidServiceReference.Service1Client();
            //List<Dto_User> usersList = svc3.GetAllUsers().ToList();
            //int i = 0;
            //foreach (Dto_User u in usersList)
            //{
            //    MessageBox.Show("" + (i + 1) + "       : " + u.ToString());
            //}
            #endregion TestGetAllUsers

            #region TestDeleteProfile
            //UMaidServiceReference.Service1Client svc4 =
            //    new UMaidServiceReference.Service1Client();

            //Dto_Profile profileToDelete = new Dto_Profile() { ProfileID = 29 };
            //Dto_Bool result = svc4.DeleteProfile(profileToDelete);
            //if (result.success)
            //{
            //    MessageBox.Show("Deleting profile was successful  : " +
            //        profileToDelete.ToString());

            //}
            //else
            //{
            //    MessageBox.Show("Deleting profile was unsuccessful!!!");
            //}
            #endregion TestDeleteProfile

            #region TestGetAllProfiles
            //UMaidServiceReference.Service1Client svc5 =
            //    new UMaidServiceReference.Service1Client();
            //List<Dto_Profile> profilesList = svc5.GetAllProfiles().ToList();
            //int i = 0;
            //foreach (Dto_Profile u in profilesList)
            //{
            //    MessageBox.Show("" + (i + 1) + "       : " + u.ToString());
            //    i++;
            //}
            #endregion TestGetAllProfiles


            #region TestDeletePicture
            //UMaidServiceReference.Service1Client svc6 =
            //    new UMaidServiceReference.Service1Client();

            //Dto_Picture pictureToDelete = new Dto_Picture() { PictureID = 60062 };
            //Dto_Bool result1 = svc6.DeletePicture(pictureToDelete);
            //if (result1.success)
            //{
            //    MessageBox.Show("Deleting picture was successful  : " +
            //        pictureToDelete.ToString());

            //}
            //else
            //{
            //    MessageBox.Show("Deleting picture was unsuccessful!!!");
            //}
            #endregion TestDeletePicture


            #region TestGetAllPictures
            //UMaidServiceReference.Service1Client svc7 =
            //    new UMaidServiceReference.Service1Client();
            //List<Dto_Picture> picturesList = svc7.GetAllPictures().ToList();
            //i = 0;
            //foreach (Dto_Picture u in picturesList)
            //{
            //    MessageBox.Show("" + (i + 1) + "       : " + u.ToString());
            //    i++;
            //}

            #endregion TestGetAllPictures

        }
        private void BtnLoginMaid_Click(object sender, RoutedEventArgs e)
        {
            //selectedUser = new Dto_User()
            //{
            //    UserID = 2,
            //    UserTypeID = 2,
            //    Email = "maid@umaid.com",
            //    Password = "maidTest",
            //    FName = "Maid",
            //    LName = "Test",
            //    PhoneNumber = "8881234567",
            //    StartDate = DateTime.Now
            //};

            //MaidMainMenuWindow maidMainWindow = new MaidMainMenuWindow(selectedUser);

            //maidMainWindow.Show();
            //this.Close();
        }

        private void BtnLoginCust_Click(object sender, RoutedEventArgs e)
        {
            //selectedUser = new Dto_User()
            //{
            //    UserID = 1,
            //    UserTypeID = 1,
            //    Email = "owner@umaid.com",
            //    Password = "ownerTest",
            //    FName = "Owner",
            //    LName = "Test",
            //    PhoneNumber = "8889876543",
            //    StartDate = DateTime.Now
            //};
            
            //CustomerMainMenuWindow customerMainWindow = new CustomerMainMenuWindow(selectedUser);

            //customerMainWindow.Show();
            //this.Close();
        }
    }
}
