using System.Collections.Generic;

namespace ProjektAutomat
{
    public class Vend
    {
        public int VendID { get; set; }
        public float CustomerBalance { get; set; }
        public float VendBalance { get; set; }
        public List<Product> Products { get; set; }
    }
}
