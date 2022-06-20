namespace ProjektAutomat
{
    public class Product
    {
        public int ProductID { get; set; }
        public int VendID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public int Quantity { get; set; }
        public override string ToString() { return string.Format($"{ProductID},{VendID},{Name},{Cost},{Quantity}"); }
    }
}
