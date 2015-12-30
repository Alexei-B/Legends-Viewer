using LegendsViewer.Legends;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LegendsViewer.Controls.Map
{
    class MapPage : PageControl
    {
        public MapPanel MapPanel;

        public MapPage(DwarfTabControl dwarfTabControl, MapPanel mapPanel)
        {
            Title = "Map";
            MapPanel = mapPanel;
            TabControl = dwarfTabControl;
        }

        public override Control GetControl()
        {
            return MapPanel;
        }

        public override void Refresh()
        {
            MapPanel.Refresh();
        }

        public override void Dispose()
        {
            if (MapPanel != null)
                MapPanel.Dispose();
        }
    }
}
