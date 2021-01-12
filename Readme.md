# UAS Pemrograman
Aplikasi ini berfungsi untuk simulasi pembelian makanan/minuman 
dengan implementasi cupon.

## Scope and Functionalities
- User dapat melihat daftar makanan yang ditawarkan
- User dapat memasukkan atau menghapus makanan pilihan ke dalam keranjang
- User dapat melihat subtotal makanan yang terdapat pada keranjang
- User dapat melihat daftar voucher yang ditawarkan
- User dapat menggunakan salah satu voucher
- User dapat melihat harga total termasuk potongannya

## How Does it works?
```csharp
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
```
digunakan untuk mengisi daftar cupon dan dimasukkan kedalam
list

<br>

```csharp
        public void OnPilihCuponChangedListener(Cupon item)
        {
            controller.addCupon(item);
        }
```
digunakan untuk menambahkan kupon yang dipilih

<br>

```csharp
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
```
digunakan untuk menambahkan daftar menu kedalam list

<br>

```csharp
        public void onPenawaranSelected(Item item)
                {
                    controller.addItem(item);
                }
```
digunakan untuk menambahkan item yang dipilih kedalam list menu pesanan

<br>

```csharp
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
```
digunakan untuk perhitungan grant total semua pesanan dan juga cupon yang digunakan
