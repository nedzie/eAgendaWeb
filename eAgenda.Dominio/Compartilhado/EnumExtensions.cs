using System;
using System.ComponentModel;
using System.Linq;

namespace eAgenda.Dominio.Compartilhado
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if(e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                        return descriptionAttribute.Description;
                }
            }

            return null;
        }
    }
}
