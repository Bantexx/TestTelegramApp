namespace TestTelegramApp.Helpers;

public static class CurrencyFormatter
{
    public static string Format(decimal value)
    {
        if (value >= 1000)
            return $"{value / 1000:0.##}K ₿";
        
        if (value >= 1)
            return $"{value:0.##} Ξ";         
        
        return $"{value:0.000} §";
    }
}