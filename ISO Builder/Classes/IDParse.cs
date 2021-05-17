using System.Text;

//Code borrowed from https://codereview.stackexchange.com/a/109517

namespace ISO_Builder.Classes
{
    class IDParse
    {
        const string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string RemoveUnwantedChar(string input)
        {
            StringBuilder builder = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (allowedCharacters.Contains(input[i]))
                {
                    builder.Append(input[i]);
                }
            }
            return builder.ToString();
        }
    }
}
