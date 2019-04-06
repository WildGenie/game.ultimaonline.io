using System;
using UltimaOnline;

namespace UltimaOnline.Network
{
    public class UpdateStatueAnimation : Packet
    {
        public UpdateStatueAnimation(Mobile m, int status, int animation, int frame) : base(0xBF, 17)
        {
            Stream.Write((short)0x11);
            Stream.Write((short)0x19);
            Stream.Write((byte)0x5);
            Stream.Write((int)m.Serial);
            Stream.Write((byte)0);
            Stream.Write((byte)0xFF);
            Stream.Write((byte)status);
            Stream.Write((byte)0);
            Stream.Write((byte)animation);
            Stream.Write((byte)0);
            Stream.Write((byte)frame);
        }
    }
}
