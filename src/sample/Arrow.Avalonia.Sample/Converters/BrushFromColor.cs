﻿using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace Arrow.Avalonia.Sample.Converters;

internal sealed class BrushFromColor : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Color color)
        {
            return null;
        }

        return new SolidColorBrush(color);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not SolidColorBrush brush)
        {
            return null;
        }

        return brush.Color;
    }
}