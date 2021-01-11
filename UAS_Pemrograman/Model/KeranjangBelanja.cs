using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows;

namespace UAS_Pemrograman.Model
{
    class KeranjangBelanja
    {
        List<Item> itemBelanja;
        List<Cupon> itemCupon;
        int KapasitasCupon = 1;
        Payment payment;
        OnKeranjangBelanjaChangedListener callback;

        public KeranjangBelanja(Payment payment, OnKeranjangBelanjaChangedListener callback)
        {
            this.payment = payment;
            this.itemBelanja = new List<Item>();
            this.itemCupon = new List<Cupon>();
            this.callback = callback;
        }

        public List<Item> getItems()
        {
            return this.itemBelanja;
        }

        public List<Cupon> getCupon()
        {
            return this.itemCupon;
        }


        public void addItem(Item item)
        {
            this.itemBelanja.Add(item);
            this.callback.addItemSucceed();
            calculateSubTotal();
        }

        public void addCupon(Cupon item)
        {
            if (KapasitasCupon == 1)
            {
                this.itemCupon.Add(item);
                this.callback.addCuponSucceed();
                KapasitasCupon = 0;
                calculateSubTotal();
            } else
            {
                MessageBox.Show("Maaf cuma 1 cupon saja yg dapat dipilih", "Ok", MessageBoxButton.OK);
            }
        }

        public void removeCupon(Cupon item)
        {
            this.itemCupon.Remove(item);
            this.callback.removeCuponSucceed();
            KapasitasCupon = 1;
            calculateSubTotal();
        }

        public void removeItem(Item item)
        {
            this.itemBelanja.Remove(item);
            this.callback.removeItemSucceed();
            calculateSubTotal();
        }

        private void calculateSubTotal()
        {
            double subtotal = 0;
            double potongan = 0;
            foreach (Item item in itemBelanja)
            {
                subtotal += item.price;
            }

            foreach (Cupon Cupon in itemCupon)
            {
                if (Cupon.diskonPersen != 0)
                {

                    if(Cupon.diskonPersen == 30)
                    {
                        if(subtotal >= 100000)
                        {
                            potongan -= 30000;
                        }
                        
                        else
                        {
                            potongan -= subtotal * (Cupon.diskonPersen / 100);
                        }
                    } 

                    else 
                    { 
                        potongan -= subtotal * (Cupon.diskonPersen/100);
                    }
                }

                if(Cupon.diskon != 0)
                {
                    potongan -= Cupon.diskon;
                }
            }
            payment.updateTotal(subtotal, potongan); 


        }
    }
    interface OnKeranjangBelanjaChangedListener
    {
        void removeItemSucceed();
        void addItemSucceed();
        void removeCuponSucceed();
        void addCuponSucceed();
    }
}
