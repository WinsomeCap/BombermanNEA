using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BombermanNEA;

public class Dijkstra
{
    public static void start(PlaceNode[] points, PlaceNode start)
    {
        private Dictionary<PlaceNode, int> distances;
        private PlaceNode current = start;
        private List<PlaceNode> unvisited = new List<PlaceNode>();
        foreach (PlaceNode node in points.Keys)
        {
            unvisited.Add(node);
            distances.Add(node,-1)
        }
        distances.Add(start,0)
        PlaceNode min = start;
        while (unvisited.Count > 0)
        {   
            foreach (PlaceNode node in unvisited)
            {
                if (distances[node] == -1)
                {
                    continue;
                }
                else if (distances[node] < distances[min])
                {
                    min = distances[node]
                }
            }
            foreach (PlaceNode node in min.connections.Keys)
            {
                if (distances[node] > distances[min] + min.connections[node] || distances[node] == -1)
                {
                    distances[node] = distances[min] + min.connections[node];
                }
            }
            unvisited.Remove(min);
        }
    }
}