using SFML.Graphics;
using SFML.System;
using SFMLView.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLView
{
    public class TextView: BaseViewRectangleObject
    {
        protected TextAlign Align;
        protected Text Text;
        protected string TextSrc;
        protected Font Font;
        protected Color Color;
        protected uint Size;
        protected float TextPositionX;
        protected float TextPositionY;
        
        /// <summary>
        /// Create text view
        /// </summary>
        /// <param name="x">Position on x-axis</param>
        /// <param name="y">Position on y-axis</param>
        /// <param name="width">Buttons width</param>
        /// <param name="height">Buttons height</param>
        public TextView(
            float x, float y, 
            float width, float height, 
            float elevationX = 0, float elevationY = 0,
            bool isClickable = false, bool isClickAnimtate = false, 
            ShadowTypes shadowType = ShadowTypes.BOTTOM_RIGHT): 
            base(x, y, width, height, elevationX, elevationY, isClickable, isClickAnimtate, shadowType)
        {
            Align = TextAlign.CENTER;

            Text = new Text();

            TextSrc = "";
            Color = Color.Black;
            Size = 12;

            if (Align == TextAlign.CENTER)
            {
                var x0 = PositionX + Width / 2 - Text.GetLocalBounds().Width / 2 - ElevationX;
                var y0 = PositionY + Height / 2 - Text.GetLocalBounds().Height / 2 - ElevationY;
                Text.Position = new Vector2f(x0, y0);
            }

            Text.CharacterSize = Size;
            Text.FillColor = Color;
            Text.DisplayedString = TextSrc;
        }

        public void Update()
        {
            Text.Font = Font;
            Text.DisplayedString = TextSrc;

            if (Align == TextAlign.CENTER)
            {
                var x = PositionX + Width / 2 - Text.GetLocalBounds().Width / 2 - ElevationX;
                var y = PositionY + Height / 2 - Text.GetLocalBounds().Height / 2 - ElevationY;
                Text.Position = new Vector2f(x, y);
            }
            TextPositionX = Text.Position.X;
            TextPositionY = Text.Position.Y;

            Text.CharacterSize = Size;
            Text.FillColor = Color;
        }

        /// <summary>
        /// Set text on text view
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="font">Font</param>
        public void SetText(string text, Font font)
        {
            Font = font;
            TextSrc = text;
            Update();
        }

        /// <summary>
        /// Set text position on button
        /// </summary>
        /// <param name="align">Center</param>
        public void SetTextPosition(TextAlign align)
        {
            Align = align;
            Update();
        }

        /// <summary>
        /// Set color to text
        /// </summary>
        /// <param name="color">Your color</param>
        public void SetTextColor(Color color)
        {
            Color = color;
            Update();
        }

        /// <summary>
        /// Set text size
        /// </summary>
        /// <param name="size">Size</param>
        public void SetTextSize(uint size)
        {
            Size = size;
            Update();
        }

        /// <summary>
        /// Get text
        /// </summary>
        /// <returns>Text</returns>
        public string GetText()
        {
            return TextSrc;
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
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
