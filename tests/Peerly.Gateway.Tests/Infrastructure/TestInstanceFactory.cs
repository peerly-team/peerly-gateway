using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Google.Protobuf;

namespace Peerly.Gateway.Tests.Infrastructure;

internal static class TestInstanceFactory
{
    public static object CreateInstance(Type type)
    {
        if (typeof(IMessage).IsAssignableFrom(type))
            return Activator.CreateInstance(type)!;

        var instance = RuntimeHelpers.GetUninitializedObject(type);
        PopulateProperties(instance, type, depth: 0);
        return instance;
    }

    private static void PopulateProperties(object instance, Type type, int depth)
    {
        if (depth > 3) return;

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.CanWrite || prop.GetIndexParameters().Length > 0) continue;

            try
            {
                var value = CreateDefaultValue(prop.PropertyType, depth);
                if (value is not null)
                    prop.SetValue(instance, value);
            }
            catch
            {
                // Skip properties that can't be set
            }
        }
    }

    private static object? CreateDefaultValue(Type type, int depth)
    {
        if (type == typeof(string)) return "test";
        if (type == typeof(long)) return 1L;
        if (type == typeof(int)) return 1;
        if (type == typeof(bool)) return false;
        if (type == typeof(double)) return 1.0;
        if (type == typeof(float)) return 1.0f;
        if (type == typeof(decimal)) return 1.0m;
        if (type == typeof(DateTimeOffset)) return new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);
        if (type == typeof(DateTime)) return new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        if (type == typeof(Guid)) return Guid.NewGuid();

        if (type.IsEnum)
        {
            var values = Enum.GetValues(type);
            foreach (var v in values)
            {
                if (Convert.ToInt32(v) != 0) return v;
            }

            return values.GetValue(0);
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            return null;

        if (typeof(IMessage).IsAssignableFrom(type))
            return Activator.CreateInstance(type);

        if (type.IsGenericType)
            return TryCreateCollection(type, depth);

        if (type.IsArray)
        {
            var elementType = type.GetElementType()!;
            return Array.CreateInstance(elementType, 0);
        }

        if (type.IsClass && type != typeof(string))
        {
            var instance = RuntimeHelpers.GetUninitializedObject(type);
            PopulateProperties(instance, type, depth + 1);
            return instance;
        }

        return null;
    }

    private static object? TryCreateCollection(Type type, int depth)
    {
        var genericDef = type.GetGenericTypeDefinition();
        var args = type.GetGenericArguments();

        if (genericDef == typeof(IReadOnlyList<>) ||
            genericDef == typeof(IList<>) ||
            genericDef == typeof(IEnumerable<>) ||
            genericDef == typeof(ICollection<>) ||
            genericDef == typeof(IReadOnlyCollection<>) ||
            genericDef == typeof(List<>))
        {
            var listType = typeof(List<>).MakeGenericType(args[0]);
            return Activator.CreateInstance(listType);
        }

        if (genericDef == typeof(IReadOnlyDictionary<,>) ||
            genericDef == typeof(IDictionary<,>) ||
            genericDef == typeof(Dictionary<,>))
        {
            var dictType = typeof(Dictionary<,>).MakeGenericType(args);
            return Activator.CreateInstance(dictType);
        }

        return null;
    }
}
