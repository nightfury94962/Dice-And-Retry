public static class Utils
{
    /// <summary>
    /// Convertir une chaîne de caractères en chiffre
    /// </summary>
    /// <param name="value">chaîne de caractères à convertir</param>
    public static int ConvertStringToInt(string value)
    {
        int _value;
        int.TryParse(value, out _value);
        return _value;
    }

    /// <summary>
    /// Convertir une chaîne de caractères en decimal
    /// </summary>
    /// <param name="value">chaîne de caractères à convertir</param>
    public static float ConvertStringToFloat(string value)
    {
        float _value;
        float.TryParse(value, out _value);
        return _value;
    }

    /// <summary>
    /// Convertir une chaîne de caractères en booleen
    /// </summary>
    /// <param name="value">chaîne de caractères à convertir</param>
    public static bool ConvertStringToBoolean(string value)
    {
        bool _value;
        bool.TryParse(value, out _value);
        return _value;
    }
}
