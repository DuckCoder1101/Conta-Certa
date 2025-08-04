using System.Reflection;

namespace Conta_Certa.Utils;

public static class ClassUtils
{
    public static PropertyInfo[] GetClassProperties<T>()
    {
        var t = typeof(T);
        var properties = t.GetProperties();

        return properties;
    }
}
