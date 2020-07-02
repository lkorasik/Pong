using SFML.Graphics;
using SFML.System;
using System;
using System.Text;

namespace Pong.Models
{
    class Board: Drawable
    {
        private readonly RectangleShape Background;
        private readonly Texture BackTexture;

        public Board()
        {
            Background = new RectangleShape(new Vector2f(Constants.WindowWidth, Constants.WindowHeight));
            Background.Position = new Vector2f(0, 0);
            BackTexture = new Texture(Constants.FullPathToBoardBack);
            Background.Texture = BackTexture;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Background.Draw(target, states);
        }
    }
}
