using System;
using SFML.Graphics;
using SFML.System;

namespace Core
{
    /// <summary>
    /// Field. Here will be placed Ball, two Counter, two Racket and Grid
    /// </summary>
    public class Field : Drawable
    {
        public readonly Color BackColor;
        public uint Width => Dimensions.WindowWidth;
        public uint Height => Dimensions.WindowHeight;
        public readonly RectangleShape BackRect;

        /// <summary>
        /// Create Field
        /// </summary>
        public Field()
        {
            BackColor = Color.Black;
            BackRect = new RectangleShape(new Vector2f(Dimensions.WindowWidth, Dimensions.WindowHeight));
            BackRect.FillColor = BackColor;
        }

        /// <summary>
        /// Call it when you want to draw field
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            BackRect.Draw(target, states);
        }
    }
}
