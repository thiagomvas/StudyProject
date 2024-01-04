using StudyProject.Core.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace StudyProject.Core.Models
{
    /// <summary>
    /// Represents a hexadecimal identifier.
    /// </summary>
    public class HexId
    {
        private readonly string hexId;

        /// <summary>
        /// Initializes a new instance of the <see cref="HexId"/> class with the specified hexadecimal value.
        /// </summary>
        /// <param name="hexId">The hexadecimal value.</param>
        /// <exception cref="InvalidHexValueException">Thrown when an invalid hexadecimal value is provided.</exception>
        public HexId(string hexId)
        {
            if (!IsHexadecimal(hexId))
            {
                throw new InvalidHexValueException("Invalid hexadecimal value provided.");
            }

            this.hexId = hexId;
        }

        /// <summary>
        /// Gets the string representation of the hexadecimal identifier.
        /// </summary>
        /// <returns>The hexadecimal identifier as a string.</returns>
        public override string ToString() => hexId;

        /// <summary>
        /// Checks if the input string is a valid hexadecimal value.
        /// </summary>
        /// <param name="input">The input string to be validated.</param>
        /// <returns><c>true</c> if the input is a valid hexadecimal value; otherwise, <c>false</c>.</returns>
        private static bool IsHexadecimal(string input)
        {
            return Regex.IsMatch(input, @"(0x|0X)?[a-fA-F0-9]+$");
        }

        /// <summary>
        /// Implicitly converts a hexadecimal identifier to a string.
        /// </summary>
        /// <param name="hexId">The hex id to be converted</param>
        public static implicit operator string(HexId hexId) => hexId.ToString();

        /// <summary>
        /// Generates a new random hexadecimal identifier.
        /// </summary>
        /// <returns>A new <see cref="HexId"/> instance with a randomly generated hexadecimal value.</returns>
        public static HexId NewHexId()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            while (stringBuilder.Length < 10)
            {
                stringBuilder.Append(random.Next(0, 16).ToString("X"));
            }
            return new HexId(stringBuilder.ToString());
        }

        
        public static bool operator ==(HexId hexId1, HexId hexId2)
        {
            if(hexId1.hexId == hexId2.hexId)
            {
                return true;
            }
            return false;
        }
        
        public static bool operator !=(HexId hexId1, HexId hexId2)
        {
            return !(hexId1 == hexId2);
        }
    }
}
