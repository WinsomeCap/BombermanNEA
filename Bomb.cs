using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BombermanNEA;

public class Bomb : StaticBody
{
    private Texture2D BombTex;
    private Texture2D Mask;
    private SpriteBatch spriteBatch;
    public Bomb(Vector2 position, Texture2D texture, float size, Color color, Texture2D mask, SpriteBatch spritebatch)
        : base(position, texture, size, color)
    {
        spriteBatch = spritebatch;
        BombTex = texture;
        Mask = mask;
        Thread thread = new Thread(new ThreadStart(wait));
    }
    private void wait()
    {
        bool TimeOn = true;
        new Timer(1000).Start(out TimeOn);
        while (TimeOn)
        {
            Texture = BombTex;
        }
        if (!TimeOn)
        {
            Texture = Mask;
            Draw(spriteBatch);
        }
    }
}