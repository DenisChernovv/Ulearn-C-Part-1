using System.Collections.Generic;
using GeometryTasks;
using System.Drawing;

namespace GeometryPainting
{
    //Напишите здесь код, который заставит работать методы segment.GetColor и segment.SetColor
    static class SegmentExtensions
    {
        public static Dictionary <Segment, Color> MyColor = new Dictionary<Segment, Color>();
        public static void SetColor(this Segment segment, Color color)
        {
            if (MyColor.ContainsKey(segment)) MyColor[segment] = color;
            else MyColor.Add(segment, color);
        }

        public static Color GetColor(this Segment segment)
        {
            if (!MyColor.ContainsKey(segment)) return Color.Black;
            return MyColor[segment];
        }
    }
}
