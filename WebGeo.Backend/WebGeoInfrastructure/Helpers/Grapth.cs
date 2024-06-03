using WebGeoInfrastructure.Entities;

namespace WebGeoInfrastructure.Helpers
{
    public class Grapth
    {
        private Dictionary<int, List<Routes>> adjacencyList;

        public Grapth(List<Routes> routes)
        {
            adjacencyList = new Dictionary<int, List<Routes>>();

            // Construa o grafo a partir dos dados das rotas
            foreach (var route in routes)
            {
                if (!adjacencyList.ContainsKey(route.OriginId))
                {
                    adjacencyList[route.OriginId] = new List<Routes>();
                }
                adjacencyList[route.OriginId].Add(route);

                // Adicionar destinos para garantir que todos os IDs estejam na lista de adjacência
                if (!adjacencyList.ContainsKey(route.DestinyId))
                {
                    adjacencyList[route.DestinyId] = new List<Routes>();
                }
            }
        }

        // Algoritmo de Dijkstra
        public List<int> ShortestPath(int start, int end)
        {
            var distances = new Dictionary<int, int>();
            var previous = new Dictionary<int, int>();
            var queue = new List<int>();

            foreach (var vertex in adjacencyList.Keys)
            {
                distances[vertex] = int.MaxValue;
                previous[vertex] = -1;
                queue.Add(vertex);
            }

            distances[start] = 0;

            while (queue.Any())
            {
                queue.Sort((x, y) => distances[x].CompareTo(distances[y]));
                var smallest = queue.First();
                queue.Remove(smallest);

                if (smallest == end)
                {
                    var path = new List<int>();
                    while (previous[smallest] != -1)
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }
                    path.Add(start);
                    path.Reverse();
                    return path;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in adjacencyList[smallest])
                {
                    var alt = distances[smallest] + neighbor.Weight;
                    if (alt < distances[neighbor.DestinyId])
                    {
                        distances[neighbor.DestinyId] = alt;
                        previous[neighbor.DestinyId] = smallest;
                    }
                }
            }

            return null;
        }
    }
}
