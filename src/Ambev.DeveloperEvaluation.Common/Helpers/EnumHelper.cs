using System.ComponentModel;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Common.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescriptionFromStatusValue<T>(T status)
        {
            FieldInfo field = status.GetType().GetField(status.ToString());
            DescriptionAttribute attribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : status.ToString();
        }
    }
}
