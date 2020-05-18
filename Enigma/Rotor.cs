using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Rotor
    {
        public Rotor(string configuration, int cycleIndex)
        {
            m_forwardConversion = new int[26];
            m_backwardConversion = new int[26];
            m_cycleIndex = cycleIndex;
            m_rotation = 0;

            CreateConversionMap(configuration);
        }

        public bool isCycleComplete()
        {
            return m_cycleIndex - m_rotation == -1;
        }

        public char GetKey()
        {
            return (char)(m_rotation + 'A');
        }

        public void SetKey(char key)
        {
            int ctr = key - 'A';
            while(ctr-- > 0)
            {
                Rotate();
            }
        }

        public void Rotate()
        {
            m_rotation++;
            m_rotation %= 26;
        }

        public int InputForward(int characterIndex)
        {
            int index = (int)(characterIndex + m_rotation) % 26;
            var res = m_forwardConversion[index] - m_rotation;
            return res >= 0 ? res : 26 + res;
        }

        public int InputBackward(int characterIndex)
        {
            int index = (int)(characterIndex + m_rotation) % 26;
            var res = m_backwardConversion[index] - m_rotation;
            return res >= 0 ? res : 26 + res;
        }

        private void CreateConversionMap(string configuration)
        {
            configuration = configuration.ToUpper();
            var chars = configuration.ToCharArray();
            int ctr = 0;
            foreach (var ch in chars)
            {
                m_forwardConversion[ctr] = ch - 'A';
                m_backwardConversion[ch - 'A'] = ctr;
                ctr++;
            }
        }

        private int[] m_forwardConversion;
        private int[] m_backwardConversion;
        private int m_cycleIndex;
        private int m_rotation;
    }
}
