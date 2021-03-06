﻿using System;
using System.Globalization;

namespace RevStack.OrientDb
{
    public static class Extensions
    {
        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (!char.IsUpper(value[0]))
                return value;

            string camelCase = char.ToLower(value[0], CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
            if (value.Length > 1)
                camelCase += value.Substring(1);

            return camelCase;
        }
    }
}
