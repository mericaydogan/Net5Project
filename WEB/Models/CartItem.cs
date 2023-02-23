using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    
    public class CartItem
    {
        //bir sepetin ......'sı olur.
        public CartItem()
        {
            Quantity = 1;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get { return Quantity * UnitPrice; }}
        

        //todo: sepette indirim => Toplam tutar 300 TL'nin üzerinde ise 10 TL indirim.
        //todo: Kupon kullanıldığında sepette 15 TL indirim uygulanacak.

        //todo: sepet html içerisinde adetler bir input ile beraber gösterilsin. input'un değeri değiştirildiğinde fiyatlar da güncellensin.
    }
}
