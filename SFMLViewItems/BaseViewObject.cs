using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = SFML.Graphics.Color;

namespace SFMLViewItems
{
    public class BaseViewObject: Drawable
    {
        protected float PositionX;
        protected float PositionY;
        protected float Width;
        protected float Height;
        protected float Elevation;
        protected RectangleShape TopLayer;
        protected RectangleShape BottomLayer;

        public BaseViewObject(float x, float y, float width, float height, float elevation)
        {
            PositionX = x;
            PositionY = y;
            Width = width;
            Height = height;
            Elevation = elevation;

            TopLayer = new RectangleShape(new Vector2f(Width, Height));
            TopLayer.FillColor = Color.Red;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            BottomLayer.Draw(target, states);
            TopLayer.Draw(target, states);
        }
    }
}
