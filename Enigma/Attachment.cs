using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public interface Attachment
    {
        void Attach(Attachment attachment);
        void AttachRight(Attachment attachment);
        UInt16 InputForward(UInt16 index);
        UInt16 InputBackward(UInt16 index);
    }
}
