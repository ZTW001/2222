using System;
using Improve.Framework.Algorithms.Genetic;

namespace RgbGuesser
{
	class RgbChromosome : IChromosome<Rgb>
	{
		private Rgb targetRgb = new Rgb { R = 127, G = 240, B = 50 };
		private Rgb chromosome;

		public RgbChromosome(int r, int g, int b)
		{
			this.chromosome = new Rgb { R = r, G = g, B = b };
		}

		public double Fitness
		{
			get
			{
				int maxDiff = 255 * 3;
				
				int rDiff = Math.Abs(chromosome.R - targetRgb.R);
				int gDiff = Math.Abs(chromosome.G - targetRgb.G);
				int bDiff = Math.Abs(chromosome.B - targetRgb.B);
				int totalDiff = rDiff + gDiff + bDiff;

				return maxDiff - totalDiff;
			}
		}

		public Rgb ChromosomeValue
		{
			get { return chromosome; }
		}
	}
}