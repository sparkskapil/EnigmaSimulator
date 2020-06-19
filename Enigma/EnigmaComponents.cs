using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaComponents
    {
        // M3 Army December 1938
        public static Rotor Rotor5 = new Rotor("VZBRGITYUPSDNHLXAWMJQOFECK", 25);
        public static Rotor Rotor4 = new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB", 9);
        //=========================================================================

        // Enigma I 1930
        public static Rotor Rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 21);
        public static Rotor Rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 4);
        public static Rotor Rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 17);
        //=========================================================================

        public static Reflector ReflectorA = new Reflector("EJMZALYXVBWFCRQUONTSPIKHGD");
        public static Reflector ReflectorB = new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");
        public static Reflector ReflectorC = new Reflector("FVPJIAOYEDRZXWGCTKUQSBNMHL");
    }
}
