using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UAS_Pemrograman
{
    public partial class PilihCupon : Window
    {
        Controller.CuponController CuponController;
        OnPilihCuponChangedListener listener;

        public PilihCupon()
        {
            InitializeComponent();

            CuponController = new Controller.CuponController();
            DaftarCupon.ItemsSource = CuponController.getItems();

            generateListCupon();
        }

        private void generateListCupon()
        {
            Model.Cupon Cupon1 = new Model.Cupon(title: "Promo Tebus Murah Diskon 30% max. 30.000", discInPercent: 30);
            Model.Cupon Cupon2 = new Model.Cupon(title: "Promo Awal Tahun Diskon 25%", discInPercent: 25);
            Model.Cupon Cupon3 = new Model.Cupon(title: "Promo Natal Potongan 10000", disc: 10000);

            CuponController.addItem(Cupon1);
            CuponController.addItem(Cupon2);
            CuponController.addItem(Cupon3);

            DaftarCupon.Items.Refresh();
        }

        public void SetOnItemSelectedListener(OnPilihCuponChangedListener listener)
        {
            this.listener = listener;
        }

        public interface OnPilihCuponChangedListener
        {
            void OnPilihCuponChangedListener(Model.Cupon item);
        }

        private void DaftarCuponSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Model.Cupon item = listbox.SelectedItem as Model.Cupon;
            

            this.listener.OnPilihCuponChangedListener(item);
        }
    }
}
