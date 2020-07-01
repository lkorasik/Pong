using SFML.Graphics;
using SFML.System;

namespace Pong.Models
{
    class Counter: Drawable
    {
        private Text CountView;
        private int Count;
        private Font Font;
        private PositionTypes PositionType;

        public Counter(PositionTypes positionTypes)
        {
            Count = 0;

            PositionType = positionTypes;

            Font = new Font(Constants.FullPathToFontFile);

            CountView = new Text(Count.ToString(), Font);
            if (PositionType == PositionTypes.LEFT)
                CountView.Position = new Vector2f(Constants.WindowWidth / 3, 20);
            else
                CountView.Position = new Vector2f(Constants.WindowWidth * 2 / 3, 20);
            CountView.CharacterSize = 20;
            CountView.FillColor = Color.Red;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            CountView.Draw(target, states);
        }
    }
}
