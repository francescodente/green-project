using GreenProject.Backend.Core.Utils.PasswordHashing;
using System;
using System.Linq;
using System.Text;

namespace GreenProject.Backend.Infrastructure.PasswordHashing
{
    public class HexEncoding : IStringEncoding
    {
        public string BytesToString(byte[] bytes)
        {
            return bytes.Select(b => string.Format("{0:x2}", b))
                .Aggregate(new StringBuilder(), (s, c) => s.Append(c))
                .ToString();
        }

        public byte[] StringToBytes(string message)
        {
            return Enumerable.Range(0, message.Length / 2)
                .Select(x => Convert.ToByte(message.Substring(x * 2, 2), 16))
                .ToArray();
        }
    }
}
