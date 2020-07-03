using SFML.Graphics;
using SFML.System;
using SFMLViewItems;
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace SFMLButton
{
    public class Button: TextView, Drawable
    {   
        /// <summary>
        /// Create button
        /// </summary>
        /// <param name="x">Position on x-axis</param>
        /// <param name="y">Position on y-axis</param>
        /// <param name="width">Buttons width</param>
        /// <param name="height">Buttons height</param>
        public Button(float x, float y, float width, float height): base(x, y, width, height)
        {
            
        }

        /// <summary>
        /// Call it when user press on button
        /// </summary>
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

        /// <summary>
        /// Call it when user release button
        /// </summary>
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

    }
}
