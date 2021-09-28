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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        #region Window Fields
        List<Dto_Profile> profiles = new List<Dto_Profile>();
        //Dto_Profile profileToEdit = null;
        Dto_Profile UserProfile = null;
        Dto_Profile selectedProfile = null;
        Dto_User selectedUser = null;
        #endregion Window Fields

        public ProfileWindow()
        {
            InitializeComponent();
        }

        public ProfileWindow(Dto_User user)
        {
            InitializeComponent();

            selectedUser = user;
            //

            LoadProfile();
        }

        /** Load maid profile from the database using userID */
        private void LoadProfile()
        {
            profiles.Clear();

            try
            {
                using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
                {
                    UserProfile = svc.GetProfile(selectedUser);
                    
                    if (!UserProfile.Error) {
                        selectedProfile = UserProfile;
                        MessageBox.Show(UserProfile.ToString());

                        List < Dto_Profile > pictureList=new List<Dto_Profile>();
                        pictureList.Add(UserProfile);
                        LbxCustomer.ItemsSource = pictureList;
                        tbPicturePath.Text = UserProfile.PicturePath;
                        tbAccNum.Text = ""+UserProfile.AccountNumber;
                        tbRating.Text = ""+UserProfile.AvgRating;
                        tbBio.Text = UserProfile.Bio;
                    }
                    else
                    {
                        Dto_Picture newPictureRecord = new Dto_Picture()
                        {
                            UserID = selectedUser.UserID

                        };

                        Dto_Picture pictureRecordReturned = svc.InsertPicture(newPictureRecord);
                        Dto_Profile newProfile = new Dto_Profile() {
                            UserID = selectedUser.UserID,
                            PictureID = pictureRecordReturned.PictureID
                         };
                        Dto_Profile profileRecordReturned = svc.InsertProfile(newProfile);

                        selectedProfile = profileRecordReturned;
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                        
        }
        private void EditProfile()
        {
            if (selectedProfile == null)
            {

                return;
            }
            Dto_Profile profileToEdit = new Dto_Profile()
            {
                ProfileID = selectedProfile.ProfileID,
                UserID = selectedUser.UserID,
                PictureID = selectedProfile.PictureID,
                //AccountNumber = Convert.ToInt32(tbAccNum.Text),
                //AvgRating = Convert.ToDouble(tbRating.Text),
                Bio = tbBio.Text
            };
            try
            {
                profileToEdit.AccountNumber = Convert.ToInt32(tbAccNum.Text);
            }
            catch(Exception ex)
            {
                profileToEdit.AccountNumber = 0;
            }
            try
            {
                profileToEdit.AvgRating = Convert.ToDouble(tbRating.Text);
            }
            catch(Exception ex)
            {
                profileToEdit.AvgRating = 0;
            }

            using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
            {

                Dto_Picture selectedPictureRecord = new Dto_Picture();
                selectedPictureRecord = svc.GetPicture(selectedUser);
                selectedPictureRecord.PicturePath =
                    tbPicturePath.Text;

                Dto_Bool status= svc.UpdatePicture(selectedPictureRecord);

                if (!status.success)
                {
                    MessageBox.Show("Error:Updating picture record");
                }
                Dto_Bool b = svc.UpdateProfile(profileToEdit);

                if (b.success)
                {
                    MessageBox.Show("Profile succesfully changed!");
                }
                else
                {
                    MessageBox.Show(b.ErrorMessage);
                }
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            EditProfile();

            LoadProfile();
        }

        
    }
}
