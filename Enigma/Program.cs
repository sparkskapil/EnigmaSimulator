using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Program
    {
        public class Enigma
        {
            public Enigma()
            {
                m_rotor3 = EnigmaComponents.Rotor3;
                m_rotor2 = EnigmaComponents.Rotor2;
                m_rotor1 = EnigmaComponents.Rotor1;

                m_reflector = EnigmaComponents.ReflectorB;
            }

            public void SetKey(string key)
            {
                if (key.Length != 3)
                    throw new Exception("There are only 3 rotors and Key must have 3 characters");
                key = key.ToUpper();
                var chars = key.ToCharArray();
                m_rotor1.SetKey(chars[0]);
                m_rotor2.SetKey(chars[1]);
                m_rotor3.SetKey(chars[2]);
            }

            public string GetKey()
            {
                string key = "";
                key += m_rotor1.GetKey();
                key += m_rotor2.GetKey();
                key += m_rotor3.GetKey();
                return key;
            }

            public char Submit(char ch)
            {
                ch = ch >= 97 ? (char)(ch - 32) : ch;
                var index = ch - 'A';

                //Rotate rotors
                m_rotor3.Rotate();
                if (m_rotor3.isCycleComplete())
                {
                    m_rotor2.Rotate();
                }
                if (m_rotor3.isCycleComplete())
                {
                    m_rotor1.Rotate();
                }

                var res = m_rotor3.InputForward(index);
                res = m_rotor2.InputForward(res);
                res = m_rotor1.InputForward(res);
                res = m_reflector.Reflect(res);
                res = m_rotor1.InputBackward(res);
                res = m_rotor2.InputBackward(res);
                res = m_rotor3.InputBackward(res);
                return (char)(res + 'A');
            }

            private Rotor m_rotor1;
            private Rotor m_rotor2;
            private Rotor m_rotor3;

            private Reflector m_reflector;
        }
        static void Main(string[] args)
        {
            string InputString = "enigma";
            string RotorConfiguration = "dog";
            Console.WriteLine("Input String: {0}", InputString.ToUpper());
            Console.WriteLine("Rotor Configuration: {0}", RotorConfiguration.ToUpper());
            Enigma enigma = new Enigma();
            enigma.SetKey(RotorConfiguration);
            Console.WriteLine("Output String: \n");
            foreach (var ch in InputString.ToCharArray())
            {
                Console.Write(enigma.Submit(ch));
            }
        }
    }
}
