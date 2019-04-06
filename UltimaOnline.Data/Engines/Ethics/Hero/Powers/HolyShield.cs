using System;
using System.Collections.Generic;
using System.Text;

namespace UltimaOnline.Ethics.Hero
{
    public sealed class HolyShield : Power
    {
        public HolyShield()
        {
            m_Definition = new PowerDefinition(
                    20,
                    "Holy Shield",
                    "Erstok K'blac",
                    ""
                );
        }

        public override void BeginInvoke(Player from)
        {
            if (from.IsShielded)
            {
                from.Mobile.LocalOverheadMessage(UltimaOnline.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of a holy shield.");
                return;
            }

            from.BeginShield();

            from.Mobile.LocalOverheadMessage(UltimaOnline.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of a holy shield.");

            FinishInvoke(from);
        }
    }
}
