using StudyProject.Core.Exceptions;
using System.Text.RegularExpressions;

namespace StudyProject.Core.Models
{
    public class HexId
    {
        private readonly string hexId;

        public HexId(string hexId)
        {
            if(!IsHexadecimal(hexId))
            {
                throw new InvalidHexValueException("Invalid hexadecimal value provided.");
            }

            this.hexId = hexId;
        }

        public override string ToString() => hexId;

        private static bool IsHexadecimal(string input)
        {
            return Regex.IsMatch(input, @"(0x|0X)?[a-fA-F0-9]+$");
        }
    }
}
