using System;
namespace SkiaCalendar.Sources.Drawing
{
    public abstract class SkiaButton : SkiaSprite
    {
        protected Action<SkiaButton> OnPressAction { get; set; }

        public void OnPress()
        {
            OnPressAction?.Invoke(this);
            SetNeedsDisplayAction?.Invoke(this);
        }
    }
}
