namespace Ga_Bag_Problem.Game
{
    public class PossiblesGenes
    {
        public List<float> Weigths;
        public List<float> Prices;
        public List<string> Names;
        public PossiblesGenes()
        {
            Weigths = new List<float>();
            Prices = new List<float>();
            Names = new List<string>();


            Weigths.Add(1.0f);
            Prices.Add(20.0f);
            Names.Add("sapatos");

            Weigths.Add(40.0f);
            Prices.Add(100.0f);
            Names.Add("Notebook");

            Weigths.Add(5.0f);
            Prices.Add(50.0f);
            Names.Add("celular");

            Weigths.Add(5.0f);
            Prices.Add(40.0f);
            Names.Add("relogios");

            Weigths.Add(2.0f);
            Prices.Add(5.0f);
            Names.Add("documentos");

            Weigths.Add(.5f);
            Prices.Add(10.0f);
            Names.Add("oculos");

            Weigths.Add(40f);
            Prices.Add(200.0f);
            Names.Add("bolsa");

            Weigths.Add(1);
            Prices.Add(9.0f);
            Names.Add("camisa");
        }

        public static List<Genes> toGenes()
        {
            var genes = new List<Genes>();
            var inst = new PossiblesGenes();

            for (var i = 0; i < inst.Weigths.Count; i++)
            {
                var w = inst.Weigths[i];
                var p = inst.Prices[i];
                var n = inst.Names[i];
                var newGene = new Genes(w, p, n);
                genes.Add(newGene);
            }


            return genes;
        }
    }
}
