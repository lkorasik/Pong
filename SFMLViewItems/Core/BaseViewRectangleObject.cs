using SFML.Graphics;
using SFML.System;
using SFMLView.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = SFML.Graphics.Color;

namespace SFMLView.Core
{
    public class BaseViewRectangleObject: Drawable
    {
        protected float PositionX;
        protected float PositionY;
        protected float Width;
        protected float Height;
        protected float ElevationX;
        protected float ElevationY;
        protected RectangleShape TopLayer;
        protected RectangleShape BottomLayer;
        protected ShdowVerticalTypes ShdowVerticalType;
        protected ShadowHorizontalTypes ShadowHorizontalType;
        protected bool IsClickable;
        protected bool IsClickAnimate;
        protected Action OnClick;

        /// <summary>
        /// Use it for create drawable object (aka Matherial Design)
        /// </summary>
        /// <param name="x">Position on x-axis</param>
        /// <param name="y">Position on y-axis</param>
        /// <param name="width">View width. Should be positive</param>
        /// <param name="height">View height. Should be positive</param>
        /// <param name="elevationX">Elevation. If value equal zero you will not see shadow. On x-axis. Should be positive</param>
        /// <param name="elevationY">Elevation. If value equal zero you will not see shadow. On y-axis. Should be positive</param>
        /// <param name="shadowType">Position of shadow</param>
        public BaseViewRectangleObject(
            float x, float y,
            float width, float height,
            float elevationX = 0, float elevationY = 0,
            bool isClickable = false, bool isClickAnimtate = false,  
            ShadowTypes shadowType = ShadowTypes.BOTTOM_RIGHT)
        {
            InitBaseDimensions(x, y, width, height, elevationX, elevationY, isClickable, isClickAnimtate);

            InitShadowMarkers(shadowType);

            InitTopLayer();

            InitBottomLayer();
        }

        /// <summary>
        /// Init type of shadow
        /// </summary>
        /// <param name="shadowType">Shadow type</param>
        private void InitShadowMarkers(ShadowTypes shadowType)
        {
            switch (shadowType)
            {
                case ShadowTypes.BOTTOM_LEFT:
                    ShadowHorizontalType = ShadowHorizontalTypes.LEFT;
                    ShdowVerticalType = ShdowVerticalTypes.BOTTOM;
                    break;
                case ShadowTypes.BOTTOM_RIGHT:
                    ShadowHorizontalType = ShadowHorizontalTypes.RIGHT;
                    ShdowVerticalType = ShdowVerticalTypes.BOTTOM;
                    break;
                case ShadowTypes.TOP_LEFT:
                    ShadowHorizontalType = ShadowHorizontalTypes.LEFT;
                    ShdowVerticalType = ShdowVerticalTypes.TOP;
                    break;
                case ShadowTypes.TOP_RIGHT:
                    ShadowHorizontalType = ShadowHorizontalTypes.RIGHT;
                    ShdowVerticalType = ShdowVerticalTypes.TOP;
                    break;
            }
        }

        /// <summary>
        /// Init base values
        /// </summary>
        /// <param name="x">Position on x-axis</param>
        /// <param name="y">Position on y-axis</param>
        /// <param name="width">View width. Should be positive</param>
        /// <param name="height">View height. Should be positive</param>
        /// <param name="elevationX">Elevation. If value equal zero you will not see shadow. On x-axis. Should be positive</param>
        /// <param name="elevationY">Elevation. If value equal zero you will not see shadow. On y-axis. Should be positive</param>
        private void InitBaseDimensions(float x, float y, float width, float height, float elevationX, float elevationY, bool isClickable, bool isAnimate)
        {
            PositionX = x;
            PositionY = y;
            Width = Math.Abs(width);
            Height = Math.Abs(height);
            ElevationX = Math.Abs(elevationX);
            ElevationY = Math.Abs(elevationY);
            IsClickable = isClickable;
            IsClickAnimate = isAnimate;

            OnClick = () => { };
        }

        /// <summary>
        /// Init top layer
        /// </summary>
        private void InitTopLayer()
        {
            TopLayer = new RectangleShape(new Vector2f(Width, Height));
            TopLayer.FillColor = Color.Red;
            TopLayer.Position = new Vector2f(PositionX, PositionY);
        }
        
        /// <summary>
        /// Init bottom layer
        /// </summary>
        private void InitBottomLayer()
        {
            BottomLayer = new RectangleShape(new Vector2f(Width, Height));
            BottomLayer.FillColor = Color.Black;

            if((ShdowVerticalType == ShdowVerticalTypes.BOTTOM) && (ShadowHorizontalType == ShadowHorizontalTypes.LEFT))
                BottomLayer.Position = new Vector2f(PositionX - ElevationX, PositionY + ElevationY);
            if ((ShdowVerticalType == ShdowVerticalTypes.BOTTOM) && (ShadowHorizontalType == ShadowHorizontalTypes.RIGHT))
                BottomLayer.Position = new Vector2f(PositionX + ElevationX, PositionY + ElevationY);
            if ((ShdowVerticalType == ShdowVerticalTypes.TOP) && (ShadowHorizontalType == ShadowHorizontalTypes.LEFT))
                BottomLayer.Position = new Vector2f(PositionX - ElevationX, PositionY - ElevationY);
            if ((ShdowVerticalType == ShdowVerticalTypes.TOP) && (ShadowHorizontalType == ShadowHorizontalTypes.RIGHT))
                BottomLayer.Position = new Vector2f(PositionX + ElevationX, PositionY - ElevationY);
        }

        /// <summary>
        /// Call it when user pres on this element
        /// </summary>
        public virtual void AnimatePress()
        {
            if(IsClickable)
                TopLayer.Position = new Vector2f(BottomLayer.Position.X, BottomLayer.Position.Y);
        }

        /// <summary>
        /// Call it when user release this element
        /// </summary>
        public virtual void AnimationRelease()
        {
            if(IsClickable)
                TopLayer.Position = new Vector2f(PositionX, PositionY);
        }

        /// <summary>
        /// Get View Width (Width top layer + elevation)
        /// </summary>
        /// <returns>Width</returns>
        public float GetViewWidth()
        {
            return Width + ElevationX;
        }

        /// <summary>
        /// Get View height (height top layer + elevation)
        /// </summary>
        /// <returns>Height</returns>
        public float GetViewHeight()
        {
            return Height + ElevationY;
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
        /// Set image for top layer
        /// </summary>
        /// <param name="color">Color</param>
        public void SetTextureTopLayer(string path)
        {
            var texture = new Texture(path);
            TopLayer.Texture = texture;
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
        /// Call it when you need to execute code from SetOnClick
        /// </summary>
        public void Press()
        {
            if(OnClick != null)
                OnClick();
        }
        
        /// <summary>
        /// Set code for execute when user click
        /// </summary>
        /// <param name="click">Write your code here (look-like android)</param>
        public void SetOnClick(Action click)
        {
            OnClick = click;
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            BottomLayer.Draw(target, states);
            TopLayer.Draw(target, states);
        }
    }
}
