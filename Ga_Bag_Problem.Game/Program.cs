using Ga_Bag_Problem.Ga;
using Ga_Bag_Problem.Game;

var bagSize = 6;
var populationSize = 50;
var random = new Random();
List<Genes> possiblesGenes = PossiblesGenes.toGenes();
GeneticAlgorithm<Genes> ga;

ga = new GeneticAlgorithm<Genes>(populationSize, bagSize, random, getRandomGene, null, 5);
var totalWeigths = 50;
var totalPrices = possiblesGenes.Select(x => x.Price).Sum(x => x);

float fitnessFunction(int index)
{

    var fitness = 0f;

    var currentGenes = ga.Population[index].Genes;
    var sumOfWeights = 0f;
    var sumOfPrices = 0f;

    for (var i = 0; i < currentGenes.Length; i++)
    {
        sumOfWeights += currentGenes[i].Weigth;
        sumOfPrices += currentGenes[i].Price;
    }
    if (sumOfWeights > totalWeigths)
    {
        fitness = 0f;
    }
    else
    {
        fitness = ((sumOfWeights / totalWeigths) / 2) + ((sumOfPrices / totalPrices) / 2);
    }
    return fitness;
}

Genes getRandomGene()
{
    var i = random.Next(0, possiblesGenes.Count);
    return possiblesGenes[i];
}
ga.SetFitnessFunction(fitnessFunction);


for (var i = 0; i < 5000; i++)
{
    ga.NewGeneration();
}

Console.WriteLine($"Best Fitness: {ga.BestFitness}");
Console.WriteLine("Best Genes:");
for (var i = 0; i < ga.BestGenes.Length; i++)
{
    Console.WriteLine(ga.BestGenes[i].ToString());
}
var sum = ga.BestGenes.Sum(e => e.Price);
var w = ga.BestGenes.Sum(e => e.Weigth);
Console.WriteLine($"Sum of the Prices of Best Solution: {sum}");
Console.WriteLine($"Sum of the Weigth of Best Solution: {w}, the max weigth is 50 of the bag, its {(w / 50) * 100}% of the bag");
Console.WriteLine($"Total Generations: {ga.Generation}");
