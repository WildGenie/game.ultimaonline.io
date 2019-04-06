using System;
using UltimaOnline.Network;
using UltimaOnline.Items;

namespace UltimaOnline.Items
{
	public class ArtifactVase : Item
	{
		[Constructable]
		public ArtifactVase() : base( 0x0B48 )
		{
		}

		public ArtifactVase( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}