namespace Blazor_PDF
{
    public static class Extensions
    {
        public static float ToDpi(this float centimeter)
        {
            var inch = centimeter / 2.54;
            return (float)(inch * 72);
        }
    }
}