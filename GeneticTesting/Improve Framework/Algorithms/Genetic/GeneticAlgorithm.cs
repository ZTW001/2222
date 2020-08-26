using System;
using System.Collections.Generic;
using System.Linq;

namespace Improve.Framework.Algorithms.Genetic
{
	public abstract class GeneticAlgorithm<T>
	{
		/// <summary>
		/// This is the amount of chromosomes that will be in the population at any generation.
		/// </summary>
		protected int ChromosomePopulationSize;

		/// <summary>
		/// This is the number of chromosomes that survive each generation, after which they're mutated.
		/// </summary>
		protected int GenerationSurvivorCount;

		/// <summary>
		/// This list holdes the chromosomes of the current population.
		/// </summary>
		protected IList<IChromosome<T>> ChromosomePopulation;

		/// <summary>
		/// This is the current generation number. Incremented each time a new generation is made.
		/// </summary>
		public int CurrentGenerationNumber;

		/// <summary>
		/// This is the current generation population.
		/// </summary>
		public IEnumerable<IChromosome<T>> CurrentGenerationPopulation
		{
			get { return ChromosomePopulation.AsEnumerable(); }
		}

		/// <summary>
		/// Initializes the genetic algorithm by evolving the initial generation of chromosomes.
		/// </summary>
		/// <param name="chromosomePopulationSize">The size of any generation.</param>
		/// <param name="generationSurvivorCount">The number of chromosomes to survive the evolution of a generation.</param>
		public GeneticAlgorithm(int populationSize, int generationSurvivorCount)
		{
			if (generationSurvivorCount >= populationSize)
				throw new ArgumentException("The survival count of a generation must be smaller than the population size. Otherwise the population will become stagnant");

			if (generationSurvivorCount < 2)
				throw new ArgumentException("Where would we be today if either Adam or Eve were alone?");

			ChromosomePopulationSize = populationSize;
			GenerationSurvivorCount = generationSurvivorCount;

			// Create initial population and set generation
			CurrentGenerationNumber = 1;
			createInitialChromosomes();
		}

		/// <summary>
		/// Creates the initial population of random chromosomes.
		/// </summary>
		private void createInitialChromosomes()
		{
			ChromosomePopulation = new List<IChromosome<T>>();

			for (int i = 0; i < ChromosomePopulationSize; i++)
				ChromosomePopulation.Add(CreateInitialRandomChromosome());
		}

		/// <summary>
		/// Performs an evolution by picking up the generation survivors and mutating them.
		/// </summary>
		public void PerformEvolution()
		{
			IList<IChromosome<T>> newGeneration = new List<IChromosome<T>>();

			// Get the survivors of the last generation
			IEnumerable<IChromosome<T>> survivors = GetGenerationSurvivors();

			// Add the survivors of the previous generation
			foreach (var survivor in survivors)
				newGeneration.Add(survivor);

			// Until the population is full, add a new mutation of any two survivors, selected by weighted random based on their fitness.
			Random rnd = new Random();

			while (newGeneration.Count < ChromosomePopulationSize - GenerationSurvivorCount)
			{
				// Get two random survivors, weighted random sort based on fitness
				var randomSurvivor = survivors
					.OrderBy(c => rnd.NextDouble() * c.Fitness)
					.First();

				foreach (var offspring in Mutate(randomSurvivor))
				{
					if (newGeneration.Count == ChromosomePopulationSize)
						break;

					newGeneration.Add(offspring);
				}
			}

			// Overwrite current population
			ChromosomePopulation = newGeneration;

			// Increment the current generation
			CurrentGenerationNumber++;
		}

		/// <summary>
		/// Creates an arbitrary number of mutated chromosomes, based on the input chromosome.
		/// </summary>
		protected abstract IEnumerable<IChromosome<T>> Mutate(IChromosome<T> chromosome);

		/// <summary>
		/// Creates a single random chromosome for the initial chromosome population.
		/// </summary>
		protected abstract IChromosome<T> CreateInitialRandomChromosome();

		/// <summary>
		/// Selects the surviving chromosomes of the current generation.
		/// </summary>
		/// <returns>Returns a list of survivors of the current generation.</returns>
		protected abstract IEnumerable<IChromosome<T>> GetGenerationSurvivors();
	}
}