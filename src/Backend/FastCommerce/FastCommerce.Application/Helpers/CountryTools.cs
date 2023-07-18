namespace FastCommerce.Application.Helpers;

internal static class CountryTools
{
    internal static bool IsValidEUCountry(string? countryCode)
    {
        return !string.IsNullOrWhiteSpace(countryCode) && EUCountries.Contains(countryCode.ToUpper());
    }

    private static string[] EUCountries = new[]
        { "NL", "B", "BG", "D", "CY", "DK", "EE", "FIN", "F", "GR", "H", "IRL", "I", "HR", "LV", "LT", "L", "M", "A", "PL", "P", "RO", "SK", "SLO", "E", "CZ", "S" };
}
