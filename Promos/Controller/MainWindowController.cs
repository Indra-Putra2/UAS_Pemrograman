using System;
using System.Collections.Generic;
using System.Text;
using UAS_Pemrograman.Model;

namespace UAS_Pemrograman.Controller
{
    class MainWindowController 
    {
        KeranjangBelanja keranjangBelanja;

        public MainWindowController(KeranjangBelanja keranjangBelanja)
        {
            this.keranjangBelanja = keranjangBelanja;
        }

        public void addItem(Item item)
        {
            this.keranjangBelanja.addItem(item);
        }

        public void addCupon(Cupon item)
        {
            this.keranjangBelanja.addCupon(item);
        }
        public List<Item> getSelectedItems()
        {
            return this.keranjangBelanja.getItems();
        }

        public List<Cupon> getSelectedCupons()
        {
            return this.keranjangBelanja.getCupon();
        }

        public void deleteSelectedItem(Item item)
        {
            this.keranjangBelanja.removeItem(item);
        }

        public void deleteSelectedCupon(Cupon item)
        {
            this.keranjangBelanja.removeCupon(item);
        }
    }
}
