using SFML.Graphics;
using SFMLButton;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace SFMLViewItems
{
    public class ButtonList: Drawable
    {
        private float PositionX;
        private float PositionY;
        private float ButtonWidth;
        private float ButtonHeight;
        private float ButtonSpace;
        private float HeaderSpace;
        private List<Button> ListItems;
        private ListStats ListStat;
        private Font Font;
        private TextView Header;
        private Button Collapser;
        private string CollapsedText = "▼";
        private string DetailedText = "▲";
        public readonly List<Action> Releases;
        public readonly List<Action> Pressed;
        public readonly List<Func<float, float, bool>> IsOvers;
        public readonly List<Func<string>> Texts;

        public ButtonList(float x, float y, float btnWidth, float bthHeight, Font font)
        {
            ListItems = new List<Button>();
            ListStat = ListStats.COLLAPSED;

            PositionX = x;
            PositionY = y;
            ButtonWidth = btnWidth;
            ButtonHeight = bthHeight;

            ButtonSpace = 2;
            HeaderSpace = 6;

            Font = font;

            Header = new TextView(x, y, btnWidth - 52, bthHeight);
            Header.SetColorBottomLayer(Color.Black);
            Header.SetColorTopLayer(Color.Red);
            Header.SetText("Select", font);
            Header.SetTextPosition(TextAlign.CENTER);
            Header.SetTextColor(Color.Yellow);

            Collapser = new Button(x + 150, y, 50, bthHeight);
            Collapser.SetColorBottomLayer(Color.Black);
            Collapser.SetColorTopLayer(Color.Red);
            Collapser.SetText(CollapsedText, font);
            Collapser.SetTextPosition(TextAlign.CENTER);
            Collapser.SetTextColor(Color.Yellow);

            Releases = new List<Action>();
            Pressed = new List<Action>();
            IsOvers = new List<Func<float, float, bool>>();
            Texts = new List<Func<string>>();
        }

        public void SetSelected(string text)
        {
            Header.SetText(text, Font);
        }

        public void AddItem(string text)
        {
            var y = PositionY + (ListItems.Count + 1) * ButtonHeight + ListItems.Count * ButtonSpace + HeaderSpace;
            
            var item = new Button(PositionX, y, ButtonWidth, ButtonHeight);
            item.SetColorBottomLayer(Color.Black);
            item.SetColorTopLayer(Color.Red);
            item.SetText(text, Font);
            item.SetTextPosition(TextAlign.CENTER);
            item.SetTextColor(Color.Yellow);

            ListItems.Add(item);

            Releases.Add(item.Release);
            Pressed.Add(item.Press);
            IsOvers.Add(item.IsOverView);
            Texts.Add(item.GetText);
        }

        /// <summary>
        /// Check mouse position
        /// </summary>
        /// <param name="mouseX">Mouse position on x-axis</param>
        /// <param name="mouseY">Mouse position on y-axis</param>
        /// <returns>True if mouse over button</returns>
        public bool IsOverHeader(float mouseX, float mouseY)
        {
            return Collapser.IsOverView(mouseX, mouseY) || Header.IsOverView(mouseX, mouseY);
        }

        public bool IsOverView(float mouseX, float mouseY)
        {
            if (IsOverHeader(mouseX, mouseY))
                return true;

            if(ListStat == ListStats.DETAILED)
            {
                for(int i = 0; i < IsOvers.Count; i++)
                {
                    if (IsOvers[i](mouseX, mouseY))
                        return true;
                }
            }

            return false;
        }

        public void Toggle()
        {
            if (ListStat == ListStats.COLLAPSED)
            {
                Collapser.Press();
                Collapser.SetText(DetailedText, Font);
                ListStat = ListStats.DETAILED;
            }
            else
            {
                Collapser.Release();
                Collapser.SetText(CollapsedText, Font);
                ListStat = ListStats.COLLAPSED;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Header.Draw(target, states);
            Collapser.Draw(target, states);

            if(ListStat == ListStats.DETAILED)
                for (int i = 0; i < ListItems.Count; i++)
                    ListItems[i].Draw(target, states);
        }

        public void Press(float x, float y)
        {
            for(int i = 0; i < IsOvers.Count; i++)
            {
                if (IsOvers[i](x, y))
                {
                    Pressed[i]();
                    SetSelected(Texts[i]());

                    return;
                }
            }
        }
    }

    enum ListStats
    {
        COLLAPSED,
        DETAILED
    }
}
