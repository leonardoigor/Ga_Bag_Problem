namespace Ga_Bag_Problem.Game
{
    public class Genes
    {
        public Genes()
        {

        }
        public Genes(float weigth, float price, string name)
        {
            Weigth = weigth;
            Price = price;
            Name = name;
        }

        public float Weigth { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return $"{Name} - {Weigth} - {Price}";
        }

    }
}
