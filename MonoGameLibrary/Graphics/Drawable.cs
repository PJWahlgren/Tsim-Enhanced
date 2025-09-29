using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics
{
    public interface Drawable
    {

        public void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}