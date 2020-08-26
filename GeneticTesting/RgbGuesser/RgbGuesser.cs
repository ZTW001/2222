using System;
using System.Collections.Generic;
using System.Linq;
using Improve.Framework.Algorithms.Genetic;

namespace RgbGuesser
{
	class RgbGuesser : GeneticAlgorithm<Rgb>
	{
		private Random random = new Random();

		public RgbGuesser()
			: base(100, 10)
		{ }

		protected override IEnumerable<IChromosome<Rgb>> Mutate(IChromosome<Rgb> chromosome)
		{
			RgbChromosome mutation = new RgbChromosome(chromosome.ChromosomeValue.R, chromosome.ChromosomeValue.G, chromosome.ChromosomeValue.B);
			mutation.ChromosomeValue.R = Math.Min(255, Math.Max(0, mutation.ChromosomeValue.R + random.Next(-5, 6)));
			mutation.ChromosomeValue.G = Math.Min(255, Math.Max(0, mutation.ChromosomeValue.G + random.Next(-5, 6)));
			mutation.ChromosomeValue.B = Math.Min(255, Math.Max(0, mutation.ChromosomeValue.B + random.Next(-5, 6)));

			yield return mutation;
		}

		protected override IChromosome<Rgb> CreateInitialRandomChromosome()
		{
			return new RgbChromosome(random.Next(1, 256), random.Next(1, 256), random.Next(1, 256));
		}

		protected override IEnumerable<IChromosome<Rgb>> GetGenerationSurvivors()
		{
			// Return the best chromosome
			var topChromosome = this.ChromosomePopulation
				.OrderByDescending(c => c.Fitness)
				.First();

			// Return the remaining chromosomes from the pool
			var survivors = this.ChromosomePopulation
				.Where(c => c != topChromosome)
				.OrderByDescending(c => random.NextDouble() * c.Fitness)
				.Take(this.GenerationSurvivorCount - 1);

			yield return topChromosome;

			foreach (var survivor in survivors)
				yield return survivor;
		}
	}
}