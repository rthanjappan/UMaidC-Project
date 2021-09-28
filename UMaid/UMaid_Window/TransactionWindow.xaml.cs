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
    /// Interaction logic for TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : Window
    {
        List<Dto_Transaction> transactions = new List<Dto_Transaction>();
        Dto_User selectedUser = null;
        Dto_Bid selectedBid = null;

        public TransactionWindow()
        {
            InitializeComponent();
            LoadData();
            LoadTransaction();
        }

        public TransactionWindow(Dto_User user, Dto_Bid bid)
        {
            InitializeComponent();

            selectedUser = user;
            selectedBid = bid;

            LoadData();
            LoadTransaction();
        }

        private void LoadData()
        {
            Dto_Address a = new Dto_Address();
            string address = a.AddressLine1 + " " + a.City + " " + a.State + " " + a.ZipCode;
            tbAddress.Text = address;

            Dto_Listing l = new Dto_Listing();
            tbListingInfo.Text = l.ListingInfo;

            //Dto_Bid b = new Dto_Bid();
            tbBidInfo.Text = selectedBid.BidPrice.ToString();
            tbBidTime.Text = selectedBid.BidExpires.ToString();

            Dto_Transaction load = new Dto_Transaction();
            tbListingID.Text = load.listingID.ToString();
            tbBidID.Text = load.bidID.ToString();
            tbTransactionID.Text = load.transactionID.ToString();
        }

        private void LoadTransaction()
        {
            transactions.Clear();

            try
            {
                using (UMaidServiceReference.Service1Client svc = new UMaidServiceReference.Service1Client())
                {
                    transactions = svc.GetMaidTransactions(selectedUser).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
