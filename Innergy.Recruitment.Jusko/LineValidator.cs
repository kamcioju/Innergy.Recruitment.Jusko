using System;
using System.Linq;
namespace Innergy.Recruitment.Jusko
{
    public class LineValidator : ILineValidator
    {
        public bool SuppressExceptions { get; set; } = true;
        public bool Validate(string line)
        {
            try
            {
                if (line.StartsWith("#"))
                {
                    return false;
                }
                if (line.Split(';').Count() != 3)
                {
                    throw new ArgumentException("Does not contain valid parts", nameof(line));
                }
                if (line.Split(';').Last().Split('|').All(x => x.Contains(',') == false))
                {
                    throw new ArgumentException("Does not contain valid parts", nameof(line));
                }
                return true;
            }
            catch (ArgumentException)
            {
                if (SuppressExceptions)
                {
                    return false;
                }
                else throw;
            }

        }
    }
}