﻿using System.Linq;
using System.Text;
using LegendsViewer.Legends;

namespace LegendsViewer.Controls
{
    class RegionPrinter : HTMLPrinter
    {
        WorldRegion Region;
        World World;

        public RegionPrinter(WorldRegion region, World world)
        {
            Region = region;
            World = world;
        }

        public override string GetTitle()
        {
            return Region.Name;
        }

        public override string Print()
        {
            HTML = new StringBuilder();

            HTML.AppendLine("<h1>" + Region.Name + ", " + Region.Type + "</h1><br />");

            if (Region.Battles.Count(battle => !World.FilterBattles || battle.Notable) > 0)
            {
                int battleCount = 1;
                HTML.AppendLine("<b>Warfare</b> " + MakeLink("[Load]", LinkOption.LoadRegionBattles));
                if (World.FilterBattles) HTML.Append(" (Notable)");
                HTML.Append("<table border=\"0\">");
                foreach (Battle battle in Region.Battles.Where(battle => !World.FilterBattles || battle.Notable))
                {
                    HTML.AppendLine("<tr>");
                    HTML.AppendLine("<td width=\"20\"  align=\"right\">" + battleCount + ".</td><td width=\"10\"></td>");
                    HTML.AppendLine("<td>" + battle.StartYear + "</td>");
                    HTML.AppendLine("<td>" + battle.ToLink() + "</td>");
                    HTML.AppendLine("<td>as part of</td>");
                    HTML.AppendLine("<td>" + battle.ParentCollection.ToLink() + "</td>");
                    HTML.AppendLine("<td>" + battle.Attacker.PrintEntity());
                    if (battle.Victor == battle.Attacker) HTML.Append("<td>(V)</td>");
                    else HTML.AppendLine("<td></td>");
                    HTML.AppendLine("<td>Vs.</td>");
                    HTML.AppendLine("<td>" + battle.Defender.PrintEntity());
                    if (battle.Victor == battle.Defender) HTML.AppendLine("<td>(V)</td>");
                    else HTML.AppendLine("<td></td>");

                    HTML.AppendLine("<td>(Deaths: " + (battle.AttackerDeathCount + battle.DefenderDeathCount) + ")</td>");
                    HTML.AppendLine("</tr>");
                    battleCount++;
                }
                HTML.AppendLine("</table></br>");
            }

            if (World.FilterBattles && Region.Battles.Count(battle => !battle.Notable) > 0)
                HTML.AppendLine("<b>Battles</b> (Unnotable): " + Region.Battles.Count(battle => !battle.Notable) + "</br></br>");

            if (Region.Events.OfType<HFDied>().Any() || Region.Battles.Count > 0)
            {
                HTML.AppendLine("<b>Deaths</b> " + MakeLink("[Load]", LinkOption.LoadRegionDeaths) + LineBreak);
                HTML.AppendLine("<ol>");
                foreach (HFDied death in Region.Events.OfType<HFDied>())
                    HTML.AppendLine("<li>" + death.HistoricalFigure.ToLink() + ", in " + death.Year + " (" + death.Cause + ")");
                HTML.AppendLine("<li>Population in Battle: " + Region.Battles.OfType<Battle>().Sum(battle => battle.AttackerSquads.Sum(squad => squad.Deaths) + battle.DefenderSquads.Sum(squad => squad.Deaths)));
                HTML.AppendLine("</ol>");
            }

            PrintEventLog(Region.Events, WorldRegion.Filters, Region);

            return HTML.ToString();
        }
    }
}
