namespace Billing.Presentation.Models
{
    using PdfSharp.Fonts;
    public class CustomFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            // Example: Load font from file
            string fontFilePath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "fonts", "Roboto-Black.ttf");
            return File.ReadAllBytes(fontFilePath);
        }

         public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            return new FontResolverInfo("Verdana", isBold, isItalic);
        }
    }
}
