using System.IO;

namespace ISO_Builder.Classes
{
    public class Manager
    {
        public class ExtractRecourse
        {
            public static void ViaBytes(string name, byte[] array)
            {
                File.WriteAllBytes(name, array);
            }

            public static void ViaString(string name, string array)
            {
                File.WriteAllText(name, array);
            }

            public static async void ViaBytesAsync(string name, byte[] array)
            {
                await File.WriteAllBytesAsync(name, array);
            }

            public static async void ViaStringAsync(string name, string array)
            {
                await File.WriteAllTextAsync(name, array);
            }
        }
    }
}
