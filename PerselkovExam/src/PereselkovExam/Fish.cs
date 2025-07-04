
namespace PereselkovExam
{
    public class Fish
    {
        public Fish(string fishTipe, string manufacture, decimal price)
        {
            FishTipe = fishTipe;
            Manufacture = manufacture;
            Price = price;
        }
        public string FishTipe { get; set; }
        public string Manufacture { get; set; }
        private decimal price { get; set; }

        public decimal Price
        {
            get => price;
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{FishTipe}; {Manufacture}; {Price.ToString("F2")};";
        }
    }
}
