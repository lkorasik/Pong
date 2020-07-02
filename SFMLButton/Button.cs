﻿using SFML.Graphics;
using SFML.System;
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace SFMLButton
{
    public class Button: Drawable
    {
        public float PositionX;
        public float PositionY;
        private readonly RectangleShape BottomLayer;
        private readonly RectangleShape TopLayer;
        public float Elevation;
        private float width;
        private float height;
        private Text Text;
        public float Width
        {
            get => width;
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Width must be more than zero");

                width = value;
            }
        }
        public float Height
        {
            get => height;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Height must be greater than zero");

                height = value;
            }
        }
        private TextAlign Align;
        
        public Button(float x, float y, float width, float height)
        {
            PositionX = x;
            PositionY = y;

            this.width = width;
            this.height = height;

            Elevation = 5;

            Align = TextAlign.CENTER;

            BottomLayer = new RectangleShape(new Vector2f(this.width, this.height));
            TopLayer = new RectangleShape(new Vector2f(this.width, this.height));

            TopLayer.Position = new Vector2f(PositionX, PositionY);
            BottomLayer.Position = new Vector2f(PositionX + Elevation, PositionY + Elevation);

            Text = new Text();
        }

        public void SetPosition(int x, int y)
        {
            Text.Position = new Vector2f(x, y);
        }

        public void SetPosition(TextAlign align)
        {
            Align = align;
            if(align == TextAlign.CENTER)
            {
                var x = PositionX + Width / 2 - Text.GetLocalBounds().Width / 2 - Elevation;
                var y = PositionY + Height / 2 - Text.GetLocalBounds().Height / 2 - Elevation;
                Text.Position = new Vector2f(x, y);
            }
        }

        public void AddText(string text, Font font)
        {
            Text.DisplayedString = text;
            Text.Font = font;
        }

        public void SetTextColor(Color color)
        {
            Text.Color = color;
        }

        public void SetTextSize(uint size)
        {
            Text.CharacterSize = size;
        }

        public void SetColorTopLayer(Color color)
        {
            TopLayer.FillColor = color;
        }

        public void SetColorBottomLayer(Color color)
        {
            BottomLayer.FillColor = color;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            BottomLayer.Draw(target, states);
            TopLayer.Draw(target, states);
            Text.Draw(target, states);
        }

        public void Press()
        {
            TopLayer.Position = new Vector2f(PositionX + Elevation, PositionY + Elevation);
            
            if (Align == TextAlign.CENTER)
            {
                var x = PositionX + Width / 2 - Text.GetLocalBounds().Width / 2;
                var y = PositionY + Height / 2 - Text.GetLocalBounds().Height / 2;
                Text.Position = new Vector2f(x, y);
            }
        }

        public void Release()
        {
            TopLayer.Position = new Vector2f(PositionX, PositionY);

            if (Align == TextAlign.CENTER)
            {
                var x = PositionX + Width / 2 - Text.GetLocalBounds().Width / 2 - Elevation;
                var y = PositionY + Height / 2 - Text.GetLocalBounds().Height / 2 - Elevation;
                Text.Position = new Vector2f(x, y);
            }
        }

        public bool IsOverButton(float mouseX, float mouseY)
        {
            if ((mouseX >= PositionX) && (mouseX <= PositionX + Width) && (mouseY >= PositionY) && (mouseY <= PositionY + Height))
                return true;
            return false;
        }
    }

    public enum TextAlign
    {
        CENTER
    }
}
