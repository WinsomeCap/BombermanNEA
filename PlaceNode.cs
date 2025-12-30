using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BombermanNEA;
public class PlaceNode
{
    public Vector2 position;
    public Dictionary<PlaceNode,int> connections = new Dictionary<PlaceNode, int>();
}