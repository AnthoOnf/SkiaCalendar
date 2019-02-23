using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;

namespace SkiaCalendar.Sources.Drawing
{
    public abstract class BaseDrawable
    {
        private readonly List<SkiaSprite> _displayList;
        protected List<SkiaSprite> GetDisplayList() => _displayList;

        private SKRect _drawnRect;


        public BaseDrawable()
        {
            _displayList = new List<SkiaSprite>();
        }


        public virtual void Draw(SKCanvas canvas, SKRect size, bool isDebug = false)
        {
            _drawnRect = size; //new SKRect(0, 0, size.Width, size.Height);

            // display list
            foreach (SkiaSprite sprite in _displayList)
                sprite.Draw(canvas, _drawnRect, isDebug: false);
        }

        public virtual T GetSpriteAt<T>(SKPoint point)
            where T : SkiaSprite
            => _displayList
                    .Where(s => s is T)
                    .Where(s => s.IsSelectable)
                    .LastOrDefault(s =>
                    {
                        var rect = s.GetRect(_drawnRect);
                        return rect.Contains(point);
                    })
                as T;

        public virtual void Clear()
        {
            _displayList.ForEach(s => s.SetNeedsDisplayAction = null);
            _displayList.Clear();
        }

        public virtual void Add(SkiaSprite sprite)
        {
            sprite.SetNeedsDisplayAction = SetNeedsDisplay;
            _displayList.Add(sprite);
        }

        // TODO : only redraw at the sprite rect
        protected virtual void SetNeedsDisplay(SkiaSprite sprite = null) => SetNeedsDisplayAction?.Invoke(sprite);

        public virtual Action<SkiaSprite> SetNeedsDisplayAction { get; set; }
    }
}
