using OstreC.Database;

namespace OstreC.Services
{
    public class Services
    {
        public static string ChangeText(string text)
        {
            text = Database.Database.ChangeText(text);
            return text + "abc";
        }
    }
}