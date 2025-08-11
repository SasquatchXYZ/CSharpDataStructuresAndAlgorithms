namespace TitleGuess;

public class GeneticAlgorithm
{
    private const string Genes = "abcdefghijklmnopqrstuvwxyz#ABCDEFGHIJKLMNOPQRSTUVWXYZ ";

    private readonly Random _random = new();
    private readonly List<Individual> _population = new();
    private int _generationNo;

    private readonly string _target;

    public GeneticAlgorithm(string target)
    {
        _target = target;
    }

    /// <summary>
    /// Runs the genetic algorithm to evolve a population of individuals to approximate the target string.
    /// The process includes initializing a population, evaluating its fitness,
    /// performing selection, mating to create offspring,
    /// and repeating the process across generations until a solution is found.
    /// </summary>
    public void Evaluate()
    {
        for (var i = 0; i < 1000; i++)
        {
            var chromosome = GetRandomChromosome();
            _population.Add(new Individual(chromosome, GetFitness(chromosome)));
        }

        var generation = new List<Individual>();
        while (true)
        {
            _population.Sort((a, b) =>
                b.Fitness.CompareTo(a.Fitness));

            if (_population[0].Fitness == _target.Length)
            {
                Print();
                break;
            }

            generation.Clear();

            // 20% of the best-fitted individuals are moved
            // automatically to the next generation
            for (var i = 0; i < 200; i++)
            {
                generation.Add(_population[i]);
            }

            // For the remaining 800 places in the new generation, we perform
            // crossover and randomly choose parents, from 40% of the best-fitted
            // individuals, to generate new individuals
            for (var i = 0; i < 800; i++)
            {
                var p1 = _population[_random.Next(400)];
                var p2 = _population[_random.Next(400)];
                var offspring = Mate(p1, p2);
                generation.Add(offspring);
            }

            _population.Clear();
            _population.AddRange(generation);
            Print();
            _generationNo++;
        }
    }

    /// <summary>
    /// Combines the genetic information of two parent individuals to create an offspring.
    /// The mating process involves inheriting genes from each parent with probabilities
    /// and occasionally introducing variations through random mutations.
    /// </summary>
    /// <param name="p1">The first parent individual contributing genetic material to the offspring.</param>
    /// <param name="p2">The second parent individual contributing genetic material to the offspring.</param>
    /// <returns>An offspring individual created from the genetic material of both parents.</returns>
    private Individual Mate(Individual p1, Individual p2)
    {
        var child = string.Empty;

        // Creates the chromosome of the child
        for (var i = 0; i < _target.Length; i++)
        {
            var r = _random.Next(101) / 100.0f;
            if (r < 0.45f)
            {
                // 45% of the genes are taken from the first parent
                child += p1.Chromosome[i];
            }
            else if (r < 0.9f)
            {
                // 45% of the genes are taken from the second parent
                child += p2.Chromosome[i];
            }
            else
            {
                // 10% of the genes are randomly mutated
                child += GetRandomGene();
            }
        }

        return new Individual(child, GetFitness(child));
    }

    private char GetRandomGene() => Genes[_random.Next(Genes.Length)];

    private string GetRandomChromosome()
    {
        var chromosome = string.Empty;
        for (var i = 0; i < _target.Length; i++)
        {
            chromosome += GetRandomGene();
        }

        return chromosome;
    }

    /// <summary>
    /// Calculates the fitness score of a chromosome based on its similarity to the target string.
    /// The fitness score represents the number of matching characters
    /// between the chromosome and the target string.
    /// </summary>
    /// <param name="chromosome">The chromosome string to evaluate for fitness.</param>
    /// <returns>The fitness score as an integer, representing the count of matching characters with the target string.</returns>
    private int GetFitness(string chromosome)
    {
        var fitness = 0;
        for (var i = 0; i < _target.Length; i++)
        {
            if (chromosome[i] == _target[i])
                fitness++;
        }

        return fitness;
    }

    private void Print() => Console.WriteLine(
        $"Generation {_generationNo:D2}: {_population[0].Chromosome} / {_population[0].Fitness}");
}
