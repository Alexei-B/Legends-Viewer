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
        public Rectangle ZoomBounds;
        public Point MousePanStart, Center, MouseClickLocation, MouseLocation;
        public double Zoom = 1.0, PixelWidth = 1.0, PixelHeight = 1.0, ZoomChange = 0.15, ZoomMax = 10.0, ZoomMin = 0.2;

        public int YearMin, YearMax;

        public List<MapModual> Moduals;

        public MapPanel(World world, IEnumerable<MapModual> moduals, DwarfTabControl dwarfTabControl)
        {
            World = world;
            TabControl = dwarfTabControl;
            Moduals = moduals.ToList();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }

    class MapModual : Control
    {

    }

    class MapBitmapModual : MapModual
    {
        Bitmap map;


    }
}
