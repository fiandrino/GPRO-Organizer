using System.Globalization;

#nullable disable
namespace go.Api
{
    // The API sometimes sends numbers as text, and an empty text when a value is missing.
    // These methods return 0 when the text is not a number.
    public static class ApiNumber
    {
        public static int ToInt(string value)
        {
            int result;

            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            return 0;
        }

        public static double ToDouble(string value)
        {
            double result;

            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            return 0;
        }
    }
}
