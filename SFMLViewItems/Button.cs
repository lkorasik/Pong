using SFML.Graphics;
using SFML.System;
using SFMLViewItems;
using SFMLViewItems.Core;
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace SFMLViewItems
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
        public Button(float x, float y, float width, float height, float elevationX = 0, float elevationY = 0, ShadowTypes shadowType = ShadowTypes.BOTTOM_RIGHT):
            base(x, y, width, height, elevationX, elevationY, true, true, shadowType)
        {
            
        }

        public override void AnimatePress()
        {
            base.AnimatePress();

            TextPositionX = Text.Position.X;
            TextPositionY = Text.Position.Y;

            if ((ShadowHorizontalType == ShadowHorizontalTypes.LEFT) && (ShdowVerticalType == ShdowVerticalTypes.BOTTOM))
                Text.Position = new Vector2f(Text.Position.X - ElevationX, Text.Position.Y + ElevationY);
            if ((ShadowHorizontalType == ShadowHorizontalTypes.LEFT) && (ShdowVerticalType == ShdowVerticalTypes.TOP))
                Text.Position = new Vector2f(Text.Position.X - ElevationX, Text.Position.Y - ElevationY);
            if ((ShadowHorizontalType == ShadowHorizontalTypes.RIGHT) && (ShdowVerticalType == ShdowVerticalTypes.TOP))
                Text.Position = new Vector2f(Text.Position.X + ElevationX, Text.Position.Y - ElevationY);
            if ((ShadowHorizontalType == ShadowHorizontalTypes.RIGHT) && (ShdowVerticalType == ShdowVerticalTypes.BOTTOM))
                Text.Position = new Vector2f(Text.Position.X + ElevationX, Text.Position.Y + ElevationY);
        }

        public override void AnimationRelease()
        {
            base.AnimationRelease();

            Text.Position = new Vector2f(TextPositionX, TextPositionY);
        }
    }
}
