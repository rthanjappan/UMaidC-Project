using Model;
using System.Windows;

namespace UMaid_Window
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
       
        Dto_User u = new Dto_User();

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void RegisterUser(object sender, RoutedEventArgs e)
        {

            UMaidServiceReference.Service1Client svc =
                new UMaidServiceReference.Service1Client();


            //checking whether the DB can  be accessed
            Dto_User p = new Dto_User();
            p.UserID = 10015;
            Dto_User userRecordFromDB =
                svc.GetUserByUserID(p);
            MessageBox.Show("Checking whether the users table can be accessed .  :  "+
                userRecordFromDB.ToString());

            //registering the user by inserting the "Dto_User" into table "Users"
            Dto_User u = new Dto_User();
            u.LName = tbLName.Text;
            u.FName = tbFName.Text;
            u.Email = tbEmail.Text;
            u.Password = tbPass.Text;
            u.PhoneNumber = tbPhoneNum.Text;
            u.StreetName = tbStreetName.Text;
            u.City = tbCity.Text;
            u.State = tbState.Text;
            u.PostalCode = tbPostalCode.Text;
            u.StartDate = System.DateTime.Now ;
            if (btnCustomer.IsChecked == true)
            {
                u.UserTypeID = 1;
            }
            else
            {
                u.UserTypeID = 2;
            }

            Dto_User userReturned = svc.InsertUser(u);//user is registered
            if (!userReturned.Error) {
                MessageBox.Show("You are successfully registered" );
                MessageBox.Show(userReturned.ToString());
            }
            else
            {
                MessageBox.Show(userReturned.ErrorMessage);
            }


           
        }
        
    }
}
