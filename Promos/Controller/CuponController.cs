using System;
using System.Collections.Generic;
using System.Text;
using UAS_Pemrograman.Model;

namespace UAS_Pemrograman.Controller
{
    class CuponController
    {
        private List<Cupon> items;

        public CuponController()
        {
            items = new List<Cupon>();
        }

        public void addItem(Cupon item)
        {
            this.items.Add(item);
        }

        public List<Cupon> getItems()
        {
            return this.items;
        }

    }
}
