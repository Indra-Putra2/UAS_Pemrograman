using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UAS_Pemrograman.Controller;
using UAS_Pemrograman.Model;
using static UAS_Pemrograman.PilihCupon;

namespace UAS_Pemrograman
{
    public partial class MainWindow : Window,
        OnPenawaranChangedListener,
        OnPilihCuponChangedListener,
        OnPaymentChangedListener, 
        OnKeranjangBelanjaChangedListener
    {
        MainWindowController controller;
        Payment payment;

        public MainWindow()
        {
            InitializeComponent();

            payment = new Payment(this);

            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);

            controller = new MainWindowController(keranjangBelanja);

            listBoxPesanan.ItemsSource = controller.getSelectedItems();
            listBoxPakaiCupon.ItemsSource = controller.getSelectedCupons();

            initializeView();
        }

        private void initializeView()
        {
            labelSubtotal.Content = "Rp 0";
            labelGrantTotal.Content = "Rp 0";
            labelPromoFee.Content = "Rp 0";
        }

        public void onPenawaranSelected(Item item)
        {
            controller.addItem(item);
        }

        private void onButtonAddItemClicked(object sender, RoutedEventArgs e)
        {
            Penawaran penawaranWindow = new Penawaran();
            penawaranWindow.SetOnItemSelectedListener(this);
            penawaranWindow.Show();
        }

        private void listBoxPesanan_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin menghapus item ini?",
                    "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.deleteSelectedItem(item);
            }
        }

        private void listBoxPakaiCupon_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin Menghapus cupon ini?",
                   "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Cupon item = listBox.SelectedItem as Cupon;
                controller.deleteSelectedCupon(item);
            }
        }

        public void onPriceUpdated(double subtotal,  double grantTotal, double potongan)
        {
            labelSubtotal.Content = "Rp " + subtotal;
            labelGrantTotal.Content = "Rp " + grantTotal;
            labelPromoFee.Content = "Rp " + potongan;
        }

        public void removeItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void addItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void removeCuponSucceed()
        {
            listBoxPakaiCupon.Items.Refresh();
        }

        public void addCuponSucceed()
        {
            listBoxPakaiCupon.Items.Refresh();
        }

        private void OnPilihCuponClicked(object sender, RoutedEventArgs e)
        {
            PilihCupon pilihCuponWindow = new PilihCupon();
            pilihCuponWindow.SetOnItemSelectedListener(this);
            pilihCuponWindow.Show();
        }

        public void OnPilihCuponChangedListener(Cupon item)
        {
            controller.addCupon(item);
        }
    }
}
