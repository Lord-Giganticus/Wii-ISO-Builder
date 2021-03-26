using System.Drawing;
using System.Collections.Generic;
using System;

namespace ISO_Builder.Classes
{
    class Color
    {
        private List<System.Drawing.Color> GetColors()
        {
            List<System.Drawing.Color> lists = new List<System.Drawing.Color>();
            lists.Add(SystemColors.ActiveBorder);
            lists.Add(SystemColors.ActiveCaption);
            lists.Add(SystemColors.ActiveCaptionText);
            lists.Add(SystemColors.AppWorkspace);
            lists.Add(SystemColors.ButtonFace);
            lists.Add(SystemColors.ButtonHighlight);
            lists.Add(SystemColors.ButtonShadow);
            lists.Add(SystemColors.Control);
            lists.Add(SystemColors.ControlDark);
            lists.Add(SystemColors.ControlDarkDark);
            lists.Add(SystemColors.ControlLight);
            lists.Add(SystemColors.ControlLightLight);
            lists.Add(SystemColors.ControlText);
            lists.Add(SystemColors.Desktop);
            lists.Add(SystemColors.GradientActiveCaption);
            lists.Add(SystemColors.GradientInactiveCaption);
            lists.Add(SystemColors.GrayText);
            lists.Add(SystemColors.Highlight);
            lists.Add(SystemColors.HighlightText);
            lists.Add(SystemColors.HotTrack);
            lists.Add(SystemColors.InactiveBorder);
            lists.Add(SystemColors.InactiveCaption);
            lists.Add(SystemColors.InactiveCaptionText);
            lists.Add(SystemColors.Info);
            lists.Add(SystemColors.InfoText);
            lists.Add(SystemColors.Menu);
            lists.Add(SystemColors.MenuBar);
            lists.Add(SystemColors.MenuHighlight);
            lists.Add(SystemColors.MenuText);
            lists.Add(SystemColors.ScrollBar);
            lists.Add(SystemColors.Window);
            lists.Add(SystemColors.WindowFrame);
            lists.Add(SystemColors.WindowText);
            return lists;
        }

        private System.Drawing.Color GetRandomColor(List<System.Drawing.Color> list)
        {
            Random rnd = new Random();
            int r = rnd.Next(list.Count);
            return list[r];
        }

        public System.Drawing.Color RandomColor 
        { get 
            { return GetRandomColor(GetColors()); }
        }
    }
}
