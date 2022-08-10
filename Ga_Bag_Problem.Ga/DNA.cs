namespace Ga_Bag_Problem.Ga
{
    public class DNA<T>
    {
        public T[] Genes { get; set; }
        public float Fitness { get; set; }
        public Random random { get; set; }
        public Func<T> getRandomGene { get; set; }
        public Func<int, float> fitnessFunction { get; set; }


        public DNA(int length, Random random, Func<T> getRandomGene, Func<int, float> fitnessFunction, bool shouldInitGenes = true)
        {
            Genes = new T[length];
            this.random = random;
            this.getRandomGene = getRandomGene;
            this.fitnessFunction = fitnessFunction;


            if (shouldInitGenes)
            {
                for (int i = 0; i < length; i++)
                {
                    Genes[i] = getRandomGene();
                }
            }

        }
        public float CalculateFitness(int index)
        {
            Fitness = fitnessFunction(index);
            return Fitness;
        }
        public DNA<T> Crossover(DNA<T> parent)
        {
            DNA<T> child = new DNA<T>(Genes.Length, random, getRandomGene, fitnessFunction, shouldInitGenes: false);
            for (int i = 0; i < Genes.Length; i++)
            {
                child.Genes[i] = random.NextDouble() < .5f ? Genes[i] : parent.Genes[i];
            }
            return child;
        }
        public void Mutate(float mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }
    }
}