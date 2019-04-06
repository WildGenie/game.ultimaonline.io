using System;
using System.Collections.Generic;
using System.Text;

namespace UltimaOnline.Ethics.Evil
{
    public sealed class UnholyShield : Power
    {
        public UnholyShield()
        {
            m_Definition = new PowerDefinition(
                    20,
                    "Unholy Shield",
                    "Velgo K'blac",
                    ""
                );
        }

        public override void BeginInvoke(Player from)
        {
            if (from.IsShielded)
            {
                from.Mobile.LocalOverheadMessage(UltimaOnline.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of an unholy shield.");
                return;
            }

            from.BeginShield();

            from.Mobile.LocalOverheadMessage(UltimaOnline.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of an unholy shield.");

            FinishInvoke(from);
        }
    }
}
