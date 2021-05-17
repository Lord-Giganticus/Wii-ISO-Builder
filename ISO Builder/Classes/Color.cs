using System.Drawing;
using System.Collections.Generic;
using System;

namespace ISO_Builder.Classes
{
    class Colors
    {
        private List<Color> GetColors()
        {
            List<Color> lists = new List<Color>
            {
                SystemColors.ActiveBorder,
                SystemColors.ActiveCaption,
                SystemColors.ActiveCaptionText,
                SystemColors.AppWorkspace,
                SystemColors.ButtonFace,
                SystemColors.ButtonHighlight,
                SystemColors.ButtonShadow,
                SystemColors.Control,
                SystemColors.ControlDark,
                SystemColors.ControlDarkDark,
                SystemColors.ControlLight,
                SystemColors.ControlLightLight,
                SystemColors.ControlText,
                SystemColors.Desktop,
                SystemColors.GradientActiveCaption,
                SystemColors.GradientInactiveCaption,
                SystemColors.GrayText,
                SystemColors.Highlight,
                SystemColors.HighlightText,
                SystemColors.HotTrack,
                SystemColors.InactiveBorder,
                SystemColors.InactiveCaption,
                SystemColors.InactiveCaptionText,
                SystemColors.Info,
                SystemColors.InfoText,
                SystemColors.Menu,
                SystemColors.MenuBar,
                SystemColors.MenuHighlight,
                SystemColors.MenuText,
                SystemColors.ScrollBar,
                SystemColors.Window,
                SystemColors.WindowFrame,
                SystemColors.WindowText
            };
            return lists;
        }

        private static Color GetRandomColor(List<Color> list)
        {
            Random rnd = new Random();
            int r = rnd.Next(list.Count);
            return list[r];
        }

        public Color RandomColor 
        { get 
            { return GetRandomColor(GetColors()); }
        }
    }
}
