using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using AForge;
using AForge.Genetic;

namespace TSP
{
    class TSP
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("Data.txt");

            int citiesCount = 31;  //城市数

            int[,] map = new int[citiesCount, 2];

            for (int i = 0; i < citiesCount; i++)
            {
                string value = reader.ReadLine();
                string[] temp = value.Split(' ');
                map[i, 0] = int.Parse(temp[0]);  //读取城市坐标
                map[i, 1] = int.Parse(temp[1]);
            }

            // create fitness function
            TSPFitnessFunction fitnessFunction = new TSPFitnessFunction(map);

            int populationSize = 1000;  //种群最大规模
            bool greedyCrossover = true;

            /*  
             * 0：EliteSelection算法 
             * 1：RankSelection算法  
             * 其他：RouletteWheelSelection 算法
             * */
            int selectionMethod = 0; 

            // create population
            Population population = new Population(populationSize,
                (greedyCrossover) ? new TSPChromosome(map) : new PermutationChromosome(citiesCount),
                fitnessFunction,
                (selectionMethod == 0) ? (ISelectionMethod)new EliteSelection() :
                (selectionMethod == 1) ? (ISelectionMethod)new RankSelection() :
                (ISelectionMethod)new RouletteWheelSelection()
                );

            // iterations
            int iter = 1;
            int iterations = 5000;  //迭代最大周期

            // loop
            while (iter < iterations)
            {
                // run one epoch of genetic algorithm
                population.RunEpoch();

                // increase current iteration
                iter++;
            }

            System.Console.WriteLine("遍历路径是： {0}", ((PermutationChromosome)population.BestChromosome).ToString());
            System.Console.WriteLine("总路程是：{0}", fitnessFunction.PathLength(population.BestChromosome));
            System.Console.Read();

        }
    }
}
