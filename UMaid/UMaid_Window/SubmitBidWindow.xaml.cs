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
    /// Interaction logic for SubmitBid.xaml
    /// </summary>
    public partial class SubmitBidWindow : Window
    {
        #region BidFields
        List<Dto_Bid> bids = new List<Dto_Bid>();
        public Dto_User selectedUser = null;
        public Dto_Bid selectedBid = null;
        #endregion BidFields

        public SubmitBidWindow()
        {
            InitializeComponent();
            LoadBids();
        }

        public SubmitBidWindow(Dto_User user)
        {
            InitializeComponent();

            selectedUser = user;
            LoadBids();
        }

        private void LoadBids()
        {
            using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
            {
                // All this code is just for testing

                Dto_Listing listing = new Dto_Listing()
                {
                    listingID = 50003,
                    propertyID = 20011,
                    userID = 10008
                };

                List<Dto_Bid> bidList = svc.GetBids().ToList();

                //propInfoTextBlock.Text = props.allValues;
                Dto_Bid aBid = new Dto_Bid()
                {
                    BidID = 36001
                };

                var b = svc.GetBid(aBid);

                //propInfoTextBlock.Text = b.allBidValues;

                //BidsListBox.ItemsSource = bidList;

                Dto_Bid newBid = new Dto_Bid()
                {
                    BidID = 1,
                    UserID = 1,
                    ListingID = 50003,
                    BidPrice = 95,
                    StartTime = DateTime.Now,
                    BidExpires = DateTime.Now.AddHours(36),
                    IsAccepted = 0
                };

                selectedBid = newBid;

                //Dto_Bid insertedBid = svc.InsertBid(newBid);

                // Dto_Bool result = svc.DeleteBid(newBid);

                //propInfoTextBlock.Text = result.success.ToString();

                Dto_Bool updateResult = svc.UpdateBid(newBid);

                //propInfoTextBlock.Text = updateResult.success.ToString();
                propInfoTextBlock.Text = newBid.allBidValues;
            }
        }

        private void BtnTransactionWindow_Click(object sender, RoutedEventArgs e)
        {
            TransactionWindow transactionWindow = new TransactionWindow(selectedUser, selectedBid);

            transactionWindow.Show();
            this.Close();
        }
    }
}
