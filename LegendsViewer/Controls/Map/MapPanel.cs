using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LegendsViewer.Legends;

namespace LegendsViewer.Controls.Map
{
    class MapPanel : Panel
    {
        public World World;

        public DwarfTabControl TabControl;
        public RectangleF View, Map, Tile;
        public Point MousePanStart, MouseClickLocation, MouseLocation;
        public double PixelWidth = 1.0, PixelHeight = 1.0;
        public float MinWidth = 0.05F, MaxWidth = 1.5F, Aspect;

        public int YearMin, YearMax;

        public List<MapModual> Moduals;

        public MapPanel(World world, IEnumerable<MapModual> moduals, DwarfTabControl dwarfTabControl)
        {
            World = world;
            TabControl = dwarfTabControl;
            Moduals = moduals.ToList();
        }

        public void AddModual(MapModual m)
        {
            Moduals.Add(m);
        }

        public void SetView(Rectangle v)
        {
            View = v;
            Refresh();
        }

        public void Pan(float X, float Y)
        {
            View.Offset(X, Y);
            Refresh();
        }

        public void SetViewCenter(Point c)
        {
            Pan(c.X - (View.Left - View.Width / 2),
                c.Y - (View.Top - View.Height / 2));
        }

        public void SetYear(int min, int max)
        {
            YearMin = min;
            YearMax = max;
            Refresh();
        }

        public void SetYear(int year)
        {
            SetYear(year, year);
        }

        public void SetWidth(float width)
        {
            View.Width = Math.Max(MinWidth, Math.Min(MaxWidth, width));
            View.Height = View.Width * Aspect;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (MapModual m in Moduals)
                m.Draw(e);

            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }
    }

    class MapModual : Control
    {
        public void Draw(PaintEventArgs e)
        {

        }
    }

    class MapBitmapModual : MapModual
    {
        Bitmap map;


    }
}
