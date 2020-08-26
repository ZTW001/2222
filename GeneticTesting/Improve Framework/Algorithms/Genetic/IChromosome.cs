namespace Improve.Framework.Algorithms.Genetic
{
	public interface IChromosome<T>
	{
		double Fitness { get; }
		T ChromosomeValue { get; }
	}
}