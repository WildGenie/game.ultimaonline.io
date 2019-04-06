using System;
using System.Collections.Generic;
using UltimaOnline;

namespace UltimaOnline.Mobiles
{
    public class Fisherman : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override NpcGuild NpcGuild { get { return NpcGuild.FishermensGuild; } }

        [Constructable]
        public Fisherman() : base("the fisher")
        {
            SetSkill(SkillName.Fishing, 75.0, 98.0);
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBFisherman());
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem(new UltimaOnline.Items.FishingPole());
        }

        public Fisherman(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}