using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Reflector
    {
        public Reflector(string configuration)
        {
            var chars = configuration.ToCharArray();
            int ctr = 0;
            m_conversion = new int[26];
            foreach(var ch in chars)
            {
                m_conversion[ctr] = ch - 'A';
                ctr++;
            }
        }

        public int Reflect(int characterIndex)
        {
            return m_conversion[characterIndex];
        }

        private int[] m_conversion;
    }
}
