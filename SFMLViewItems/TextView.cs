using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLViewItems
{
    public class TextView: Drawable
    {
        protected TextAlign Align;
        protected float PositionX;
        protected float PositionY;
        protected float Width;
        protected float Height;
        protected float Elevation;
        protected Text Text;
        protected RectangleShape TopLayer;
        protected RectangleShape BottomLayer;

        /// <summary>
        /// Create text view
        /// </summary>
        /// <param name="x">Position on x-axis</param>
        /// <param name="y">Position on y-axis</param>
        /// <param name="width">Buttons width</param>
        /// <param name="height">Buttons height</param>
        public TextView(float x, float y, float width, float height)
        {
            Align = TextAlign.CENTER;

            PositionX = x;
            PositionY = y;
            Width = width;
            Height = height;

            Elevation = 5;

            BottomLayer = new RectangleShape(new Vector2f(Width, Height));
            TopLayer = new RectangleShape(new Vector2f(Width, Height));

            TopLayer.Position = new Vector2f(PositionX, PositionY);
            BottomLayer.Position = new Vector2f(PositionX + Elevation, PositionY + Elevation);

            Text = new Text();
        }

        /// <summary>
        /// Set text position on button
        /// </summary>
        /// <param name="align">Center</param>
        public void SetTextPosition(TextAlign align)
        {
            Align = align;
            if (align == TextAlign.CENTER)
            {
                var x = PositionX + Width / 2 - Text.GetLocalBounds().Width / 2 - Elevation;
                var y = PositionY + Height / 2 - Text.GetLocalBounds().Height / 2 - Elevation;
                Text.Position = new Vector2f(x, y);
            }
        }

        /// <summary>
        /// Set color to text
        /// </summary>
        /// <param name="color">Your color</param>
        public void SetTextColor(Color color)
        {
            Text.Color = color;
        }

        /// <summary>
        /// Set text size
        /// </summary>
        /// <param name="size">Size</param>
        public void SetTextSize(uint size)
        {
            Text.CharacterSize = size;
        }

        /// <summary>
        /// Set color for top layer (where text)
        /// </summary>
        /// <param name="color">Color</param>
        public void SetColorTopLayer(Color color)
        {
            TopLayer.FillColor = color;
        }

        /// <summary>
        /// Set color for bottom layer
        /// </summary>
        /// <param name="color">Color</param>
        public void SetColorBottomLayer(Color color)
        {
            BottomLayer.FillColor = color;
        }

        /// <summary>
        /// Set Image for bottom layer
        /// </summary>
        /// <param name="color">Color</param>
        public void SetTextureBottomLayer(string path)
        {
            var texture = new Texture(path);
            BottomLayer.Texture = texture;
        }

        /// <summary>
        /// Set image for top layer
        /// </summary>
        /// <param name="color">Color</param>
        public void SetTextureTopLayer(string path)
        {
            var texture = new Texture(path);
            TopLayer.Texture = texture;
        }

        /// <summary>
        /// Set text on text view
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="font">Font</param>
        public void SetText(string text, Font font)
        {
            Text.DisplayedString = text;
            Text.Font = font;
        }

        /// <summary>
        /// Get text from text view
        /// </summary>
        public string GetText()
        {
            return Text.DisplayedString;
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            BottomLayer.Draw(target, states);
            TopLayer.Draw(target, states);
            Text.Draw(target, states);
        }

        /// <summary>
        /// Check mouse position
        /// </summary>
        /// <param name="mouseX">Mouse position on x-axis</param>
        /// <param name="mouseY">Mouse position on y-axis</param>
        /// <returns>True if mouse over button</returns>
        public bool IsOverView(float mouseX, float mouseY)
        {
            if ((mouseX >= PositionX) && (mouseX <= PositionX + Width) && (mouseY >= PositionY) && (mouseY <= PositionY + Height))
                return true;
            return false;
        }
    }
}
