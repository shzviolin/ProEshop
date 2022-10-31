namespace ProEshop.Common.GuardToolkit;

public static class GuardExtension
{
    /// <summary>
    /// Check if the argument is null
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void CheckArgumentIsNull(this object obj, string name)
    {
        if (obj == null)
            throw new ArgumentNullException(name);
    }
}
