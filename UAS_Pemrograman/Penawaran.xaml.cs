using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UAS_Pemrograman.Controller;
using UAS_Pemrograman.Model;

namespace UAS_Pemrograman
{
    /// <summary>
    /// Interaction logic for Penawaran.xaml
    /// </summary>

    public partial class Penawaran : Window
    {
        PenawaranController Penawarancontroller;
        OnPenawaranChangedListener listener;
        public Penawaran()
        {
            InitializeComponent();

            Penawarancontroller = new PenawaranController();
            listPenawaran.ItemsSource = Penawarancontroller.getItems();

            generateContentPenawaran();
        }

        public void SetOnItemSelectedListener(OnPenawaranChangedListener listener)
        {
            this.listener = listener;
        }

        private void generateContentPenawaran()
        {
            Item menu1 = new Item("Coffe Late", 30000);
            Item menu2 = new Item("BlackTea", 20000);
            Item menu3 = new Item("Milk Shake", 15000);
            Item menu4 = new Item("Watermelon Juice", 25000);
            Item menu5 = new Item("Lemon Squash", 30000);
            Item menu6 = new Item("Pizza", 75000);
            Item menu7 = new Item("Fried Rice Special", 45000);

            Penawarancontroller.addItem(menu1);
            Penawarancontroller.addItem(menu2);
            Penawarancontroller.addItem(menu3);
            Penawarancontroller.addItem(menu4);
            Penawarancontroller.addItem(menu5);
            Penawarancontroller.addItem(menu6);
            Penawarancontroller.addItem(menu7);

            listPenawaran.Items.Refresh();
        }

        private void listPenawaran_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Item item = listbox.SelectedItem as Item;

            this.listener.onPenawaranSelected(item);
        }
    }

    public interface OnPenawaranChangedListener
    {
        void onPenawaranSelected(Item item);
    }
}
