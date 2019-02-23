using System;
using SkiaSharp;

namespace SkiaCalendar.Sources.Drawing
{
    public class SkiaGrid : SkiaSprite
    {
        private int _nbLines { get; set; }
        private int _nbColumns { get; set; }
        private readonly int _maxYlines;
        private SKPaint _paint;

        private float _posStartAtTop;
        private float _gridHeight;

        public SkiaGrid(int nbLines, int maxYlines, int nbColumn, SKPaint paint, float posStartAtTop, float gridHeight = 0)
        {
            _nbLines = nbLines;
            _maxYlines = maxYlines;
            _nbColumns = nbColumn;
            _paint = paint;
            _posStartAtTop = posStartAtTop;
            _gridHeight = gridHeight;
        }

        protected override void DrawRect(SKCanvas canvas, SKRect size)
        {
            base.DrawRect(canvas, size);

            float rectW = size.Width / _nbColumns;

            float rectH;
            if (_gridHeight == 0)
                rectH = size.Height / _maxYlines;
            else
                rectH = _gridHeight / _maxYlines;

            for (var i = 0; i <= _nbLines; i++)
            {
                canvas.DrawLine(new SKPoint(0, i * rectH + _posStartAtTop), new SKPoint(size.Width, i * rectH + _posStartAtTop), _paint);
            }
            for (var j = 0; j <= _nbColumns; j++)
            {
                canvas.DrawLine(new SKPoint(j * rectW, size.Top), new SKPoint(j * rectW, (rectH * _nbLines + _posStartAtTop)), _paint);
            }
        }

        public override SKRect GetRect(SKRect size)
        {
            return new SKRect(size.Left, size.Top + _posStartAtTop, size.Right, size.Bottom);
        }
    }
}
