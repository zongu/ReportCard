
namespace ReportCard.Model
{
    using System;
    using System.Linq;

    public class EnumDisplayAttribute : Attribute
    {
        public EnumDisplayAttribute(string display)
        {
            Display = display;
        }

        public string Display { get; private set; }
    }

    public static class EnumExtention
    {
        public static string ToDisplay(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                var attr = field.GetCustomAttributes(typeof(EnumDisplayAttribute), true).FirstOrDefault() as EnumDisplayAttribute;

                if (attr != null)
                {
                    return attr.Display;
                }
            }

            return string.Empty;
        }
    }
}
