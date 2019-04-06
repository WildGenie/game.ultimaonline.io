using System;
using UltimaOnline;
using UltimaOnline.Engines.Craft;

namespace UltimaOnline.Items
{
	public class RunicFletcherTool : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBowFletching.CraftSystem; } }

		public override int LabelNumber
		{
			get
			{
				int index = CraftResources.GetIndex( Resource );

				if ( index >= 1 && index <= 6 )
					return 1072627 + index;
					
				return 1044559; // Fletcher's Tools
			}
		}
		
		[Constructable]
		public RunicFletcherTool( CraftResource resource ) : base( resource, 0x1022 )
		{
			Weight = 2.0;
			Hue = CraftResources.GetHue( resource );
		}

		[Constructable]
		public RunicFletcherTool( CraftResource resource, int uses ) : base( resource, uses, 0x1022 )
		{
			Weight = 2.0;
			Hue = CraftResources.GetHue( resource );
		}

		public RunicFletcherTool( Serial serial ) : base( serial )
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