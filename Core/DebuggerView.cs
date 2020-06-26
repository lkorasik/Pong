using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace Core
{
    public class DebuggerView: Drawable
    {
        private readonly List<IDebuggable> DebuggableObjects;
        private readonly Font Font;

        public DebuggerView(params IDebuggable[] debuggableObjects)
        {
            DebuggableObjects = new List<IDebuggable>();
            Font = new Font(@"C:\C#\Pong\arial.ttf");

            for(int i = 0; i < debuggableObjects.Length; i++)
            {
                DebuggableObjects.Add(debuggableObjects[i]);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var shift = 0;
            for(int i = 0; i < DebuggableObjects.Count; i++)
            {
                var text = new Text(DebuggableObjects[i].GetDebugDisplayInfo(), Font);
                text.FillColor = Color.White;
                text.CharacterSize = 12;
                text.Position = new Vector2f(0, text.CharacterSize * shift);
                text.Draw(target, states);
                shift += DebuggableObjects[i].GetDebugDisplayInfoLinesCount();
            }
        }
    }
}
