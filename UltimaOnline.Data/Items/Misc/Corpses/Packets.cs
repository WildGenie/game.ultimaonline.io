using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UltimaOnline;
using UltimaOnline.Items;

namespace UltimaOnline.Network
{
	public sealed class CorpseEquip : Packet
	{
		public CorpseEquip( Mobile beholder, Corpse beheld ) : base( 0x89 )
		{
			List<Item> list = beheld.EquipItems;

			int count = list.Count;
			if( beheld.Hair != null && beheld.Hair.ItemID > 0 )
				count++;
			if( beheld.FacialHair != null && beheld.FacialHair.ItemID > 0 )
				count++;

			EnsureCapacity( 8 + (count * 5) );

			Stream.Write( (int) beheld.Serial );

			for ( int i = 0; i < list.Count; ++i )
			{
				Item item = list[i];

				if ( !item.Deleted && beholder.CanSee( item ) && item.Parent == beheld )
				{
					Stream.Write( (byte) (item.Layer + 1) );
					Stream.Write( (int) item.Serial );
				}
			}

			if( beheld.Hair != null && beheld.Hair.ItemID > 0 )
			{
				Stream.Write( (byte)(Layer.Hair + 1) );
				Stream.Write( (int)HairInfo.FakeSerial( beheld.Owner ) - 2 );
			}

			if( beheld.FacialHair != null && beheld.FacialHair.ItemID > 0 )
			{
				Stream.Write( (byte)(Layer.FacialHair + 1) );
				Stream.Write( (int)FacialHairInfo.FakeSerial( beheld.Owner ) - 2 );
			}

			Stream.Write( (byte) Layer.Invalid );
		}
	}

	public sealed class CorpseContent : Packet
	{
		public CorpseContent( Mobile beholder, Corpse beheld )
			: base( 0x3C )
		{
			List<Item> items = beheld.EquipItems;
			int count = items.Count;

			if( beheld.Hair != null && beheld.Hair.ItemID > 0 )
				count++;
			if( beheld.FacialHair != null && beheld.FacialHair.ItemID > 0 )
				count++;

			EnsureCapacity( 5 + (count * 19) );

			long pos = Stream.Position;

			int written = 0;

			Stream.Write( (ushort)0 );

			for( int i = 0; i < items.Count; ++i )
			{
				Item child = items[i];

				if( !child.Deleted && child.Parent == beheld && beholder.CanSee( child ) )
				{
					Stream.Write( (int)child.Serial );
					Stream.Write( (ushort)child.ItemID );
					Stream.Write( (byte)0 ); // signed, itemID offset
					Stream.Write( (ushort)child.Amount );
					Stream.Write( (short)child.X );
					Stream.Write( (short)child.Y );
					Stream.Write( (int)beheld.Serial );
					Stream.Write( (ushort)child.Hue );

					++written;
				}
			}

			if( beheld.Hair != null && beheld.Hair.ItemID > 0 )
			{
				Stream.Write( (int)HairInfo.FakeSerial( beheld.Owner ) - 2 );
				Stream.Write( (ushort)beheld.Hair.ItemID );
				Stream.Write( (byte)0 ); // signed, itemID offset
				Stream.Write( (ushort)1 );
				Stream.Write( (short)0 );
				Stream.Write( (short)0 );
				Stream.Write( (int)beheld.Serial );
				Stream.Write( (ushort)beheld.Hair.Hue );

				++written;
			}

			if( beheld.FacialHair != null && beheld.FacialHair.ItemID > 0 )
			{
				Stream.Write( (int)FacialHairInfo.FakeSerial( beheld.Owner ) - 2 );
				Stream.Write( (ushort)beheld.FacialHair.ItemID );
				Stream.Write( (byte)0 ); // signed, itemID offset
				Stream.Write( (ushort)1 );
				Stream.Write( (short)0 );
				Stream.Write( (short)0 );
				Stream.Write( (int)beheld.Serial );
				Stream.Write( (ushort)beheld.FacialHair.Hue );

				++written;
			}

			Stream.Seek( pos, SeekOrigin.Begin );
			Stream.Write( (ushort)written );
		}
	}

	public sealed class CorpseContent6017 : Packet
	{
		public CorpseContent6017(Mobile beholder, Corpse beheld)
			: base(0x3C)
		{
			List<Item> items = beheld.EquipItems;
			int count = items.Count;

			if (beheld.Hair != null && beheld.Hair.ItemID > 0)
				count++;
			if (beheld.FacialHair != null && beheld.FacialHair.ItemID > 0)
				count++;

			EnsureCapacity(5 + (count * 20));

			long pos = Stream.Position;

			int written = 0;

			Stream.Write((ushort)0);

			for (int i = 0; i < items.Count; ++i)
			{
				Item child = items[i];

				if (!child.Deleted && child.Parent == beheld && beholder.CanSee(child))
				{
					Stream.Write((int)child.Serial);
					Stream.Write((ushort)child.ItemID);
					Stream.Write((byte)0); // signed, itemID offset
					Stream.Write((ushort)child.Amount);
					Stream.Write((short)child.X);
					Stream.Write((short)child.Y);
					Stream.Write((byte)0); // Grid Location?
					Stream.Write((int)beheld.Serial);
					Stream.Write((ushort)child.Hue);

					++written;
				}
			}

			if (beheld.Hair != null && beheld.Hair.ItemID > 0)
			{
				Stream.Write((int)HairInfo.FakeSerial(beheld.Owner) - 2);
				Stream.Write((ushort)beheld.Hair.ItemID);
				Stream.Write((byte)0); // signed, itemID offset
				Stream.Write((ushort)1);
				Stream.Write((short)0);
				Stream.Write((short)0);
				Stream.Write((byte)0); // Grid Location?
				Stream.Write((int)beheld.Serial);
				Stream.Write((ushort)beheld.Hair.Hue);

				++written;
			}

			if (beheld.FacialHair != null && beheld.FacialHair.ItemID > 0)
			{
				Stream.Write((int)FacialHairInfo.FakeSerial(beheld.Owner) - 2);
				Stream.Write((ushort)beheld.FacialHair.ItemID);
				Stream.Write((byte)0); // signed, itemID offset
				Stream.Write((ushort)1);
				Stream.Write((short)0);
				Stream.Write((short)0);
				Stream.Write((byte)0); // Grid Location?
				Stream.Write((int)beheld.Serial);
				Stream.Write((ushort)beheld.FacialHair.Hue);

				++written;
			}

			Stream.Seek(pos, SeekOrigin.Begin);
			Stream.Write((ushort)written);
		}
	}
}