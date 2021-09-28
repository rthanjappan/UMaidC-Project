using System;
using System.IO;
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
using Microsoft.Win32;
using DAL;
using Model;

namespace UMaid_Window
{
    /// <summary>
    /// Interaction logic for ManagePropertyWindow.xaml
    /// </summary>
    public partial class ManagePropertyWindow : Window
    {
        #region WindowFields
        List<Dto_Property> properties = new List<Dto_Property>();
        Dto_Property selectedProperty = null;
        Dto_User selectedUser = null;
        static int urlCount = 1;
        #endregion WindowFields

        public ManagePropertyWindow()
        {
            InitializeComponent();
        }

        // Constructor taking the login user as parameter
        public ManagePropertyWindow(Dto_User user)
        {
            InitializeComponent();

            setSelectedUser(user);
            LoadProperty();
        }

        /** Load properties from the database using userID */
        private void LoadProperty()
        {
            properties.Clear();

            try
            {
                using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
                {
                    properties = svc.GetPropertiesByUser(selectedUser).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cbProperties.ItemsSource = properties.OrderBy(i => i.PropertyID).ToList();
        }

        private void AddProperty()
        {
            Dto_Property propertyToAdd = new Dto_Property
            {
                UserID = selectedUser.UserID,

                Address = new Dto_Address
                {
                    AddressLine1 = tbAddress1?.Text?? "",
                    AddressLine2 = tbAddress2?.Text?? "",
                    City = tbCity.Text,
                    State = tbState.Text,
                    ZipCode = tbZip.Text
                },

                photos = new List<string>
                {
                    tbPic.Text
                },

                size = Convert.ToInt32(tbSize.Text),
                numBeds = Convert.ToInt32(tbBedrooms.Text),
                numBaths = Convert.ToInt32(tbBathrooms.Text),

                isVacant = rbVacant.IsChecked == true? true : false,
                desc = tbAddInfo.Text,
                priceLight = 0,
                priceMedium = 0,
                priceHeavy = 0,
                hasPets = rbPets.IsChecked == true? true : false
            };

            using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
            {
                Dto_Bool b = svc.InsertProperty(propertyToAdd);

                if (b.success)
                {
                    MessageBox.Show("Property succesfully added!");
                }
                else
                {
                    MessageBox.Show(b.ErrorMessage);
                }
            }
        }
        private void EditProperty()
        {
            Dto_Property propertyToEdit = new Dto_Property()
            {
                PropertyID = selectedProperty.PropertyID,
                UserID = selectedUser.UserID,

                Address = new Dto_Address
                {
                    AddressID = selectedProperty.Address.AddressID,
                    AddressLine1 = tbAddress1.Text,
                    AddressLine2 = tbAddress2?.Text ?? "",
                    City = tbCity.Text,
                    State = tbState.Text,
                    ZipCode = tbZip.Text
                },

                photos = new List<string>
                {
                    tbPic.Text
                },

                size = Convert.ToInt32(tbSize.Text),
                numBeds = Convert.ToInt32(tbBedrooms.Text),
                numBaths = Convert.ToInt32(tbBathrooms.Text),
                desc = tbAddInfo.Text,

                isVacant = rbVacant.IsChecked == true ? true : false,
                hasPets = rbPets.IsChecked == true ? true : false
            };

            using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
            {
                Dto_Bool b = svc.UpdateProperty(propertyToEdit);

                if (b.success)
                {
                    MessageBox.Show("Property succesfully edited!");
                }
                else
                {
                    MessageBox.Show(b.ErrorMessage);
                }
            }
        }

        private void DeleteProperty()
        {
            using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
            {
                Dto_Bool b = svc.DeleteProperty(selectedProperty);

                if (b.success)
                {
                    MessageBox.Show("Property succesfully removed!");
                }
                else
                {
                    MessageBox.Show(b.ErrorMessage);
                }
            }
        }

        private void BtnAddProperty_Click(object sender, RoutedEventArgs e)
        {
            AddProperty();

            LoadProperty();
        }

        private void BtnEditProperty_Click(object sender, RoutedEventArgs e)
        {
            EditProperty();

            LoadProperty();
        }

        private void BtnDeleteProperty_Click(object sender, RoutedEventArgs e)
        {
            DeleteProperty();

            LoadProperty();
        }

        private void BtnClear_Click(object Sender, RoutedEventArgs e)
        {
            selectedProperty = null;

            cbProperties.SelectedIndex = 0;

            lbPropertyPics.ItemsSource = null;
            tbPic.Clear();

            tbAddress1.Clear();
            tbAddress2.Clear();
            tbCity.Clear();
            tbState.Clear();
            tbZip.Clear();
            tbSize.Clear();

            tbBedrooms.Clear();
            tbBathrooms.Clear();
            rbOccupied.IsChecked = false;
            rbVacant.IsChecked = false;
            rbPets.IsChecked = false;
            rbNoPets.IsChecked = false;

            tbAddInfo.Clear();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CbProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // This line creates combo box errors
                selectedProperty = e.AddedItems[0] as Dto_Property;

                // Display Images(WIP)
                LoadImages();

                tbAddress1.Text = selectedProperty.Address.AddressLine1;
                tbAddress2.Text = selectedProperty.Address.AddressLine2;
                tbCity.Text = selectedProperty.Address.City;
                tbState.Text = selectedProperty.Address.State;
                tbZip.Text = selectedProperty.Address.ZipCode;
                tbPic.Text = selectedProperty.photos.ElementAtOrDefault(0);

                tbSize.Text = selectedProperty.size.ToString();
                tbBedrooms.Text = selectedProperty.numBeds.ToString();
                tbBathrooms.Text = selectedProperty.numBaths.ToString();

                if (selectedProperty.isVacant)
                { rbVacant.IsChecked = true; }
                else
                { rbOccupied.IsChecked = true; }

                if (selectedProperty.hasPets)
                { rbPets.IsChecked = true; }
                else
                { rbNoPets.IsChecked = true; }

                tbAddInfo.Text = selectedProperty.desc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        // Handler for re-selecting the same property item in combo box
        private void CbProperties_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void setSelectedUser(Dto_User user)
        {
            selectedUser = user;
        }

        private void LoadImages()
        {
            this.DataContext = selectedProperty.photos;

            lbPropertyPics.ItemsSource = selectedProperty.photos;
        }

        // Dynamically adding new textbox when button "+" is clicked
        private void BtnAddPictures_Click(object sender, RoutedEventArgs e)
        {
            spAddressInfo.Children.Add(new TextBox()
            {
                Name = "tbPic" + urlCount,
                FontSize = 13,
                Width = 450,
                Margin = new Thickness(10, 0, 5, 0),
                HorizontalAlignment = HorizontalAlignment.Left
            });

            urlCount++;
        }

        //private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Multiselect = true;
        //    openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        //        "JPEG (.jpg;*.jpeg) |*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

        //    if(openFileDialog.ShowDialog() == true)
        //    {
        //        foreach (string filename in openFileDialog.FileNames)
        //            lbFiles.Items.Add(System.IO.Path.GetFileName(filename));
        //    }
        //}
    }
}