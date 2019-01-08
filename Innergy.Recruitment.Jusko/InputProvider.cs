using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innergy.Recruitment.Jusko
{
    public class InputProvider:IDisposable
    {
        public void Dispose() => _input?.Dispose();
        private TextReader _input;
        private ILineValidator _validator;
        public InputProvider(TextReader input, ILineValidator validator)
        {
            _input = input;
            _validator = validator;
        }
        public IEnumerable<string> ReadValidLines()
        {
            string line = _input.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                if(_validator.Validate(line))
                {
                    yield return line;
                }
                 line = _input.ReadLine();
            }
        }

     
    }
}
