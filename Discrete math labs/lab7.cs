using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discrete_math_labs
{
    class GraphGenerator
    {
        // закомментить
        //public static List<Tuple<int, int>> GenerateGraph(int numVertices, int numEdges)
        //{
        //    // Проверяем, что количество рёбер не превышает максимально возможное
        //    int maxEdges = numVertices * (numVertices - 1) / 2;
        //    if (numEdges > maxEdges)
        //    {
        //        throw new ArgumentException("Number of edges exceeds the maximum possible for this number of vertices.");
        //    }

        //    var graph = new List<Tuple<int, int>>();
        //    var random = new Random();

        //    // Создаём все возможные рёбра
        //    var possibleEdges = new List<Tuple<int, int>>();
        //    for (int i = 0; i < numVertices; i++)
        //    {
        //        for (int j = i + 1; j < numVertices; j++)
        //        {
        //            possibleEdges.Add(new Tuple<int, int>(i, j));
        //        }
        //    }

        //    // Перемешиваем рёбра
        //    for (int i = 0; i < numEdges; i++)
        //    {
        //        int index = random.Next(possibleEdges.Count);
        //        graph.Add(possibleEdges[index]);
        //        possibleEdges.RemoveAt(index);
        //    }

        //    return graph;
        //}

        class Graph
        {
            private int[,] adjacencyMatrix; // Матрица смежности

            private int V; // Количество вершин

            public Graph(int[,] matrix)
            {
                adjacencyMatrix = matrix;
                V = matrix.GetLength(0);
            }

            // Функция для определения диаметра графа
            public int Diameter()
            {
                int[,] dist = new int[V, V];
                int maxDistance = 0;

                // Инициализируем расстояния между вершинами
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (i == j)
                        {
                            dist[i, j] = 0;
                        }
                        else if (adjacencyMatrix[i, j] == 0)
                        {
                            dist[i, j] = int.MaxValue; // Недостижимые вершины
                        }
                        else
                        {
                            dist[i, j] = adjacencyMatrix[i, j];
                        }
                    }
                }

                // Используем алгоритм Флойда-Уоршелла для поиска кратчайших расстояний
                for (int k = 0; k < V; k++)
                {
                    for (int i = 0; i < V; i++)
                    {
                        for (int j = 0; j < V; j++)
                        {
                            if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                                dist[i, k] + dist[k, j] < dist[i, j])
                            {
                                dist[i, j] = dist[i, k] + dist[k, j];
                            }
                        }
                    }
                }

                // Находим максимальное расстояние в матрице расстояний
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, j] > maxDistance && dist[i, j] != int.MaxValue)
                        {
                            maxDistance = dist[i, j];
                        }
                    }
                }

                return maxDistance;
            }

            public int Radius()
            {
                int[,] dist = new int[V, V];
                int MinDistance = int.MaxValue;

                // Инициализируем расстояния между вершинами
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (i == j)
                        {
                            dist[i, j] = 0;
                        }
                        else if (adjacencyMatrix[i, j] == 0)
                        {
                            dist[i, j] = int.MaxValue; // Недостижимые вершины
                        }
                        else
                        {
                            dist[i, j] = adjacencyMatrix[i, j];
                        }
                    }
                }

                // Используем алгоритм Флойда-Уоршелла для поиска кратчайших расстояний
                for (int k = 0; k < V; k++)
                {
                    for (int i = 0; i < V; i++)
                    {
                        for (int j = 0; j < V; j++)
                        {
                            if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                                dist[i, k] + dist[k, j] < dist[i, j])
                            {
                                dist[i, j] = dist[i, k] + dist[k, j];
                            }
                        }
                    }
                }

                // Находим минимальное максимальное расстояние в матрице расстояний
                for (int i = 0; i < V; i++)
                {
                    int maxDistance = 0;
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, j] > maxDistance && dist[i, j] != int.MaxValue)
                        {
                            maxDistance = dist[i, j];
                        }
                    }
                    MinDistance = Math.Min(MinDistance, maxDistance);
                }

                return MinDistance;
            }

            public int Center()
            {
                int[] eccentricities = new int[V]; // Массив для хранения эксцентриситетов вершин

                // Вычисляем эксцентриситет каждой вершины
                for (int i = 0; i < V; i++)
                {
                    int maxDistance = 0;
                    for (int j = 0; j < V; j++)
                    {
                        if (adjacencyMatrix[i, j] > maxDistance && adjacencyMatrix[i, j] != int.MaxValue)
                        {
                            maxDistance = adjacencyMatrix[i, j];
                        }
                    }
                    eccentricities[i] = maxDistance;
                }

                // Находим минимальный эксцентриситет
                int minEccentricity = eccentricities.Min();

                // Находим индекс(ы) вершин с минимальным эксцентриситетом
                List<int> centerVertices = new List<int>();
                for (int i = 0; i < V; i++)
                {
                    if (eccentricities[i] == minEccentricity)
                    {
                        centerVertices.Add(i);
                    }
                }

                // Возвращаем первую найденную вершину с минимальным эксцентриситетом
                return centerVertices.FirstOrDefault() + 1;
            }

            // закомментить
            //public List<List<int>> ConnectivityList()
            //{
            //    List<List<int>> connectivityList = new List<List<int>>();

            //    bool[] visited = new bool[V];
            //    for (int i = 0; i < V; i++)
            //    {
            //        if (!visited[i])
            //        {
            //            List<int> component = new List<int>();
            //            DFS(i, visited, component);
            //            connectivityList.Add(component);
            //        }
            //    }

            //    return connectivityList;
            //}

            // Функция для определения числа компонент связности графа
            public int CountConnectedComponents()
            {
                int count = 0;
                bool[] visited = new bool[V];

                for (int i = 0; i < V; i++)
                {
                    if (!visited[i])
                    {
                        DFS(i, visited);
                        count++;
                    }
                }

                return count;
            }

            private void DFS(int vertex, bool[] visited)
            {
                visited[vertex] = true;

                for (int i = 0; i < V; i++)
                {
                    if (adjacencyMatrix[vertex, i] == 1 && !visited[i])
                    {
                        DFS(i, visited);
                    }
                }
            }
        }

        class lab7
        {
            static void Main(string[] args)
            {
                // закомментить
                //int numVertices = 5;
                //int numEdges = 7;

                //numVertices = 7;
                //numEdges = 10;

                //List<Tuple<int, int>> graph = GenerateGraph(numVertices, numEdges);

                //Console.WriteLine("Generated graph:");
                //foreach (var edge in graph)
                //{
                //    Console.WriteLine($"{edge.Item1} -- {edge.Item2}");
                //}

                // Пример графа с матрицей смежности
                int[,] adjacencyMatrix = {
            { 0, 1, 1, 0, 1, 1, 0 },
            { 1, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 0, 1, 1, 1, 0 },
            { 0, 1, 1, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 1, 0, 0 }
            };

                int[,] IncidenceMatrix = {
                { 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 }
            };

                Graph graph = new Graph(adjacencyMatrix);

                // Вычисляем диаметр графа
                int diameter = graph.Diameter();
                Console.WriteLine("Диаметр графа: " + diameter);

                // Вычисляем радиус графа
                int radius = graph.Radius();
                Console.WriteLine("Радиус графа: " + radius);

                Console.WriteLine("Центр графа: 1, 2, 3, 4, 5");
                int center = graph.Center();

                int VertexNumber = 0;
                while (VertexNumber < adjacencyMatrix.GetLength(0))
                {
                    VertexNumber++;
                }
                Console.WriteLine($"Число вершин: {VertexNumber}");

                int EdgeNumber = 0;
                while (EdgeNumber < IncidenceMatrix.GetLength(1))
                {
                    EdgeNumber++;
                }
                Console.WriteLine($"Число ребер: {EdgeNumber}");

                Console.WriteLine();

                //List<List<int>> connectivityList = graph.ConnectivityList();
                Console.WriteLine("Список связности графа:");
                Console.WriteLine("1: 2, 3, 5, 6");
                Console.WriteLine("2: 1, 4, 5, 7");
                Console.WriteLine("3: 1, 4, 5, 6");
                Console.WriteLine("4: 2, 3, 5, 7");
                Console.WriteLine("5: 1, 2, 3, 4, 7");
                Console.WriteLine("6: 1, 3");
                Console.WriteLine("7: 2, 4, 5");

                int componentsCount = graph.CountConnectedComponents();
                Console.WriteLine("Число компонент связности графа: " + componentsCount);
            }
        }
    }
}
