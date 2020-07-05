using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLViewItems
{
    public class MessageBox: Drawable
    {
        private float PositionX;
        private float PositionY;
        private float Width;
        private float Height;
        private float Elevation;
        private Text Text;
        private RectangleShape TopLayer;
        private RectangleShape BottomLayer;
        private Button LeftButton;
        private Button RightButton;
        private float ButtonMargin;
        private float ButtonWidth;
        private float ButtonHeight;
        private TextAlign Align;

        public MessageBox(float x, float y, float width, float height)
        {
            PositionX = x;
            PositionY = y;
            Width = width;
            Height = height;

            Elevation = 5;

            TopLayer = new RectangleShape(new Vector2f(Width, Height));
            BottomLayer = new RectangleShape(new Vector2f(Width, Height));

            TopLayer.Position = new Vector2f(PositionX, PositionY);
            BottomLayer.Position = new Vector2f(PositionX + Elevation, PositionY + Elevation);

            Text = new Text();

            ButtonMargin = 10;
            ButtonWidth = 200;
            ButtonHeight = 50;

            Align = TextAlign.CENTER;
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
        /// Set color for top layer (where text)
        /// </summary>
        /// <param name="color">Color</param>
        public void SetColorTopLayer(Color color)
        {
            TopLayer.FillColor = color;
        }

        /// <summary>
        /// Add right button to MessageBox
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="font">Font</param>
        public void AddRightButton(string text, Font font)
        {
            RightButton = new Button(PositionX + ButtonMargin + ButtonMargin + ButtonWidth, PositionY + Height - ButtonMargin - ButtonHeight, ButtonWidth, ButtonHeight);
            RightButton.SetColorTopLayer(Color.Yellow);
            RightButton.SetColorBottomLayer(Color.Black);
            RightButton.SetText(text, font);
            RightButton.SetTextColor(Color.Black);
            RightButton.SetTextSize(20);
            RightButton.SetTextPosition(TextAlign.CENTER);
        }

        /// <summary>
        /// Add left button to MessageBox
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="font">Font</param>
        public void AddLeftButton(string text, Font font)
        {
            LeftButton = new Button(PositionX + ButtonMargin, PositionY + Height - ButtonMargin - ButtonHeight, ButtonWidth, ButtonHeight);
            LeftButton.SetColorTopLayer(Color.Yellow);
            LeftButton.SetColorBottomLayer(Color.Black);
            LeftButton.SetText(text, font);
            LeftButton.SetTextColor(Color.Black);
            LeftButton.SetTextSize(20);
            LeftButton.SetTextPosition(TextAlign.CENTER);
        }

        /// <summary>
        /// Set text to right button
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="font">Font</param>
        public void SetRightButtonText(string text, Font font)
        {
            if (RightButton != null)
                RightButton.SetText(text, font);
        }

        /// <summary>
        /// Set text to left button
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="font">Font</param>
        public void SetLeftButtonText(string text, Font font)
        {
            if (LeftButton != null)
                LeftButton.SetText(text, font);
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            BottomLayer.Draw(target, states);
            TopLayer.Draw(target, states);
            Text.Draw(target, states);
            if(RightButton != null)
                RightButton.Draw(target, states);
            if(LeftButton != null)
                LeftButton.Draw(target, states);
            if(Text != null)
                Text.Draw(target, states);
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
                var y = PositionY + (Height - ButtonHeight - 2 * ButtonMargin ) / 2 - Text.GetLocalBounds().Height / 2 - Elevation;
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
