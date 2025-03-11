using System;
using System.ComponentModel;
using System.Linq;

namespace Cod3rsGrowth.DOMINIO.Extencoes
{
    public static class ExtensaoEnum
    {
        public static string[] GetEnumDescriptions<T>()
        {
            return Enum.GetNames(typeof(T))
                       .Select(enumName => GetDescription<T>(enumName))
                       .ToArray();
        }

        public static string GetDescription<T>(int indexEnum)
        {
            string enumName = Enum.GetNames(typeof(T)).ToArray()[indexEnum];
            return GetDescription<T>(enumName);
        }

        public static T GetEnum<T>(int indexEnum)
        {
            T result = (T)Enum.ToObject(typeof(T), indexEnum);
            return result;
        }

        private static string GetDescription<T>(string enumName)
        {
            var fieldInfo = typeof(T).GetField(enumName);
            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return descriptionAttributes?.Length > 0 ? descriptionAttributes[0].Description : enumName;
        }
    }
}