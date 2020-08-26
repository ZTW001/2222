using System;
using System.Linq;

namespace RgbGuesser
{
	class Program
	{
		static void Main(string[] args)
		{
			// Setup RgbGuesser
			RgbGuesser rgbGuesser = new RgbGuesser();

			// For each generation, write the generation number + top 5 chromosomes + fitness
			for (int i = 1; i < 100000; i++)
			{
				Console.WriteLine("Generation: " + rgbGuesser.CurrentGenerationNumber);
				Console.WriteLine("-----");

				// Get top 5 chromosomes
				var topChromosomes = rgbGuesser.CurrentGenerationPopulation
					.OrderByDescending(c => c.Fitness)
					.Take(5);

				// Get bottom 5 chromosomes
				var bottomChromosomes = rgbGuesser.CurrentGenerationPopulation
					.OrderBy(c => c.Fitness)
					.Take(5);

				if (topChromosomes.Where(c => c.Fitness == 255 * 3).Count() > 0)
				{
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("### Perfect match found at generation " + rgbGuesser.CurrentGenerationNumber + "!");
					Console.Read();
					return;
				}

				// Print out top 5 and bottom 5 chromosomes
				foreach (var chromosome in topChromosomes)
					Console.WriteLine(Convert.ToInt32(chromosome.Fitness).ToString().PadLeft(3) + ": " + chromosome.ChromosomeValue);
				Console.WriteLine("-----");
				foreach (var chromosome in bottomChromosomes.OrderByDescending(c => c.Fitness))
					Console.WriteLine(Convert.ToInt32(chromosome.Fitness).ToString().PadLeft(3) + ": " + chromosome.ChromosomeValue);

				Console.WriteLine();
				Console.WriteLine();

				// Homage to Charles Darwin
				rgbGuesser.PerformEvolution();
			}

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}