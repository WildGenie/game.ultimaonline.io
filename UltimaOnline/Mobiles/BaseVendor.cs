using System;
using System.Collections;
using UltimaOnline.Items;
using UltimaOnline.Network;
using UltimaOnline.ContextMenus;
using UltimaOnline.Mobiles;
using System.Collections.Generic;

namespace UltimaOnline.Mobiles
{
    public class BuyItemStateComparer : IComparer<BuyItemState>
    {
        public int Compare(BuyItemState l, BuyItemState r)
        {
            if (l == null && r == null) return 0;
            if (l == null) return -1;
            if (r == null) return 1;

            return l.MySerial.CompareTo(r.MySerial);
        }
    }

    public class BuyItemResponse
    {
        private Serial m_Serial;
        private int m_Amount;

        public BuyItemResponse(Serial serial, int amount)
        {
            m_Serial = serial;
            m_Amount = amount;
        }

        public Serial Serial
        {
            get
            {
                return m_Serial;
            }
        }

        public int Amount
        {
            get
            {
                return m_Amount;
            }
        }
    }

    public class SellItemResponse
    {
        private Item m_Item;
        private int m_Amount;

        public SellItemResponse(Item i, int amount)
        {
            m_Item = i;
            m_Amount = amount;
        }

        public Item Item
        {
            get
            {
                return m_Item;
            }
        }

        public int Amount
        {
            get
            {
                return m_Amount;
            }
        }
    }

    public class SellItemState
    {
        private Item m_Item;
        private int m_Price;
        private string m_Name;

        public SellItemState(Item item, int price, string name)
        {
            m_Item = item;
            m_Price = price;
            m_Name = name;
        }

        public Item Item
        {
            get
            {
                return m_Item;
            }
        }

        public int Price
        {
            get
            {
                return m_Price;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }
    }

    public class BuyItemState
    {
        private Serial m_ContSer;
        private Serial m_MySer;
        private int m_ItemID;
        private int m_Amount;
        private int m_Hue;
        private int m_Price;
        private string m_Desc;

        public BuyItemState(string name, Serial cont, Serial serial, int price, int amount, int itemID, int hue)
        {
            m_Desc = name;
            m_ContSer = cont;
            m_MySer = serial;
            m_Price = price;
            m_Amount = amount;
            m_ItemID = itemID;
            m_Hue = hue;
        }

        public int Price
        {
            get
            {
                return m_Price;
            }
        }

        public Serial MySerial
        {
            get
            {
                return m_MySer;
            }
        }

        public Serial ContainerSerial
        {
            get
            {
                return m_ContSer;
            }
        }

        public int ItemID
        {
            get
            {
                return m_ItemID;
            }
        }

        public int Amount
        {
            get
            {
                return m_Amount;
            }
        }

        public int Hue
        {
            get
            {
                return m_Hue;
            }
        }

        public string Description
        {
            get
            {
                return m_Desc;
            }
        }
    }
}
