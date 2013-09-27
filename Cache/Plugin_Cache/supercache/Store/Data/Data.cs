using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.Data
{
	/// <summary>
	/// Represents a data with 1 component.
 	/// </summary>
	public class Data<TSlot0> : IData
	{
		public TSlot0 Slot0;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0)
		{
			Slot0 = slot0;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0})", Slot0);
		}
	}
	
	/// <summary>
	/// Represents a data with 2 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1)
		{
			Slot0 = slot0;
			Slot1 = slot1;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1})", Slot0, Slot1);
		}
	}
	
	/// <summary>
	/// Represents a data with 3 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2})", Slot0, Slot1, Slot2);
		}
	}
	
	/// <summary>
	/// Represents a data with 4 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3})", Slot0, Slot1, Slot2, Slot3);
		}
	}
	
	/// <summary>
	/// Represents a data with 5 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4})", Slot0, Slot1, Slot2, Slot3, Slot4);
		}
	}
	
	/// <summary>
	/// Represents a data with 6 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5);
		}
	}
	
	/// <summary>
	/// Represents a data with 7 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6);
		}
	}
	
	/// <summary>
	/// Represents a data with 8 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7);
		}
	}
	
	/// <summary>
	/// Represents a data with 9 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8);
		}
	}
	
	/// <summary>
	/// Represents a data with 10 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9);
		}
	}
	
	/// <summary>
	/// Represents a data with 11 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10);
		}
	}
	
	/// <summary>
	/// Represents a data with 12 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11);
		}
	}
	
	/// <summary>
	/// Represents a data with 13 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12);
		}
	}
	
	/// <summary>
	/// Represents a data with 14 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13);
		}
	}
	
	/// <summary>
	/// Represents a data with 15 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14);
		}
	}
	
	/// <summary>
	/// Represents a data with 16 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15);
		}
	}
	
	/// <summary>
	/// Represents a data with 17 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16);
		}
	}
	
	/// <summary>
	/// Represents a data with 18 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17);
		}
	}
	
	/// <summary>
	/// Represents a data with 19 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18);
		}
	}
	
	/// <summary>
	/// Represents a data with 20 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19);
		}
	}
	
	/// <summary>
	/// Represents a data with 21 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20);
		}
	}
	
	/// <summary>
	/// Represents a data with 22 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21);
		}
	}
	
	/// <summary>
	/// Represents a data with 23 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22);
		}
	}
	
	/// <summary>
	/// Represents a data with 24 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23);
		}
	}
	
	/// <summary>
	/// Represents a data with 25 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24);
		}
	}
	
	/// <summary>
	/// Represents a data with 26 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25);
		}
	}
	
	/// <summary>
	/// Represents a data with 27 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26);
		}
	}
	
	/// <summary>
	/// Represents a data with 28 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27);
		}
	}
	
	/// <summary>
	/// Represents a data with 29 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28);
		}
	}
	
	/// <summary>
	/// Represents a data with 30 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29);
		}
	}
	
	/// <summary>
	/// Represents a data with 31 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30);
		}
	}
	
	/// <summary>
	/// Represents a data with 32 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31);
		}
	}
	
	/// <summary>
	/// Represents a data with 33 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32);
		}
	}
	
	/// <summary>
	/// Represents a data with 34 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33);
		}
	}
	
	/// <summary>
	/// Represents a data with 35 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34);
		}
	}
	
	/// <summary>
	/// Represents a data with 36 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35);
		}
	}
	
	/// <summary>
	/// Represents a data with 37 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36);
		}
	}
	
	/// <summary>
	/// Represents a data with 38 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37);
		}
	}
	
	/// <summary>
	/// Represents a data with 39 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38);
		}
	}
	
	/// <summary>
	/// Represents a data with 40 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39);
		}
	}
	
	/// <summary>
	/// Represents a data with 41 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40);
		}
	}
	
	/// <summary>
	/// Represents a data with 42 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41);
		}
	}
	
	/// <summary>
	/// Represents a data with 43 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42);
		}
	}
	
	/// <summary>
	/// Represents a data with 44 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43);
		}
	}
	
	/// <summary>
	/// Represents a data with 45 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44);
		}
	}
	
	/// <summary>
	/// Represents a data with 46 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45);
		}
	}
	
	/// <summary>
	/// Represents a data with 47 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46);
		}
	}
	
	/// <summary>
	/// Represents a data with 48 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47);
		}
	}
	
	/// <summary>
	/// Represents a data with 49 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48);
		}
	}
	
	/// <summary>
	/// Represents a data with 50 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49);
		}
	}
	
	/// <summary>
	/// Represents a data with 51 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50);
		}
	}
	
	/// <summary>
	/// Represents a data with 52 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51);
		}
	}
	
	/// <summary>
	/// Represents a data with 53 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52);
		}
	}
	
	/// <summary>
	/// Represents a data with 54 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53);
		}
	}
	
	/// <summary>
	/// Represents a data with 55 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54);
		}
	}
	
	/// <summary>
	/// Represents a data with 56 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55);
		}
	}
	
	/// <summary>
	/// Represents a data with 57 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56);
		}
	}
	
	/// <summary>
	/// Represents a data with 58 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57);
		}
	}
	
	/// <summary>
	/// Represents a data with 59 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57, TSlot58> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
		public TSlot58 Slot58;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57, TSlot58 slot58)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
			Slot58 = slot58;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode() ^ Slot58.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57, Slot58);
		}
	}
	
	/// <summary>
	/// Represents a data with 60 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57, TSlot58, TSlot59> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
		public TSlot58 Slot58;
		public TSlot59 Slot59;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57, TSlot58 slot58, TSlot59 slot59)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
			Slot58 = slot58;
			Slot59 = slot59;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode() ^ Slot58.GetHashCode() ^ Slot59.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57, Slot58, Slot59);
		}
	}
	
	/// <summary>
	/// Represents a data with 61 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57, TSlot58, TSlot59, TSlot60> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
		public TSlot58 Slot58;
		public TSlot59 Slot59;
		public TSlot60 Slot60;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57, TSlot58 slot58, TSlot59 slot59, TSlot60 slot60)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
			Slot58 = slot58;
			Slot59 = slot59;
			Slot60 = slot60;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode() ^ Slot58.GetHashCode() ^ Slot59.GetHashCode() ^ Slot60.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59}, {60})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57, Slot58, Slot59, Slot60);
		}
	}
	
	/// <summary>
	/// Represents a data with 62 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57, TSlot58, TSlot59, TSlot60, TSlot61> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
		public TSlot58 Slot58;
		public TSlot59 Slot59;
		public TSlot60 Slot60;
		public TSlot61 Slot61;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57, TSlot58 slot58, TSlot59 slot59, TSlot60 slot60, TSlot61 slot61)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
			Slot58 = slot58;
			Slot59 = slot59;
			Slot60 = slot60;
			Slot61 = slot61;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode() ^ Slot58.GetHashCode() ^ Slot59.GetHashCode() ^ Slot60.GetHashCode() ^ Slot61.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59}, {60}, {61})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57, Slot58, Slot59, Slot60, Slot61);
		}
	}
	
	/// <summary>
	/// Represents a data with 63 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57, TSlot58, TSlot59, TSlot60, TSlot61, TSlot62> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
		public TSlot58 Slot58;
		public TSlot59 Slot59;
		public TSlot60 Slot60;
		public TSlot61 Slot61;
		public TSlot62 Slot62;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57, TSlot58 slot58, TSlot59 slot59, TSlot60 slot60, TSlot61 slot61, TSlot62 slot62)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
			Slot58 = slot58;
			Slot59 = slot59;
			Slot60 = slot60;
			Slot61 = slot61;
			Slot62 = slot62;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode() ^ Slot58.GetHashCode() ^ Slot59.GetHashCode() ^ Slot60.GetHashCode() ^ Slot61.GetHashCode() ^ Slot62.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59}, {60}, {61}, {62})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57, Slot58, Slot59, Slot60, Slot61, Slot62);
		}
	}
	
	/// <summary>
	/// Represents a data with 64 components.
 	/// </summary>
	public class Data<TSlot0, TSlot1, TSlot2, TSlot3, TSlot4, TSlot5, TSlot6, TSlot7, TSlot8, TSlot9, TSlot10, TSlot11, TSlot12, TSlot13, TSlot14, TSlot15, TSlot16, TSlot17, TSlot18, TSlot19, TSlot20, TSlot21, TSlot22, TSlot23, TSlot24, TSlot25, TSlot26, TSlot27, TSlot28, TSlot29, TSlot30, TSlot31, TSlot32, TSlot33, TSlot34, TSlot35, TSlot36, TSlot37, TSlot38, TSlot39, TSlot40, TSlot41, TSlot42, TSlot43, TSlot44, TSlot45, TSlot46, TSlot47, TSlot48, TSlot49, TSlot50, TSlot51, TSlot52, TSlot53, TSlot54, TSlot55, TSlot56, TSlot57, TSlot58, TSlot59, TSlot60, TSlot61, TSlot62, TSlot63> : IData
	{
		public TSlot0 Slot0;
		public TSlot1 Slot1;
		public TSlot2 Slot2;
		public TSlot3 Slot3;
		public TSlot4 Slot4;
		public TSlot5 Slot5;
		public TSlot6 Slot6;
		public TSlot7 Slot7;
		public TSlot8 Slot8;
		public TSlot9 Slot9;
		public TSlot10 Slot10;
		public TSlot11 Slot11;
		public TSlot12 Slot12;
		public TSlot13 Slot13;
		public TSlot14 Slot14;
		public TSlot15 Slot15;
		public TSlot16 Slot16;
		public TSlot17 Slot17;
		public TSlot18 Slot18;
		public TSlot19 Slot19;
		public TSlot20 Slot20;
		public TSlot21 Slot21;
		public TSlot22 Slot22;
		public TSlot23 Slot23;
		public TSlot24 Slot24;
		public TSlot25 Slot25;
		public TSlot26 Slot26;
		public TSlot27 Slot27;
		public TSlot28 Slot28;
		public TSlot29 Slot29;
		public TSlot30 Slot30;
		public TSlot31 Slot31;
		public TSlot32 Slot32;
		public TSlot33 Slot33;
		public TSlot34 Slot34;
		public TSlot35 Slot35;
		public TSlot36 Slot36;
		public TSlot37 Slot37;
		public TSlot38 Slot38;
		public TSlot39 Slot39;
		public TSlot40 Slot40;
		public TSlot41 Slot41;
		public TSlot42 Slot42;
		public TSlot43 Slot43;
		public TSlot44 Slot44;
		public TSlot45 Slot45;
		public TSlot46 Slot46;
		public TSlot47 Slot47;
		public TSlot48 Slot48;
		public TSlot49 Slot49;
		public TSlot50 Slot50;
		public TSlot51 Slot51;
		public TSlot52 Slot52;
		public TSlot53 Slot53;
		public TSlot54 Slot54;
		public TSlot55 Slot55;
		public TSlot56 Slot56;
		public TSlot57 Slot57;
		public TSlot58 Slot58;
		public TSlot59 Slot59;
		public TSlot60 Slot60;
		public TSlot61 Slot61;
		public TSlot62 Slot62;
		public TSlot63 Slot63;
	
		public Data()
		{
		}
	
		public Data(TSlot0 slot0, TSlot1 slot1, TSlot2 slot2, TSlot3 slot3, TSlot4 slot4, TSlot5 slot5, TSlot6 slot6, TSlot7 slot7, TSlot8 slot8, TSlot9 slot9, TSlot10 slot10, TSlot11 slot11, TSlot12 slot12, TSlot13 slot13, TSlot14 slot14, TSlot15 slot15, TSlot16 slot16, TSlot17 slot17, TSlot18 slot18, TSlot19 slot19, TSlot20 slot20, TSlot21 slot21, TSlot22 slot22, TSlot23 slot23, TSlot24 slot24, TSlot25 slot25, TSlot26 slot26, TSlot27 slot27, TSlot28 slot28, TSlot29 slot29, TSlot30 slot30, TSlot31 slot31, TSlot32 slot32, TSlot33 slot33, TSlot34 slot34, TSlot35 slot35, TSlot36 slot36, TSlot37 slot37, TSlot38 slot38, TSlot39 slot39, TSlot40 slot40, TSlot41 slot41, TSlot42 slot42, TSlot43 slot43, TSlot44 slot44, TSlot45 slot45, TSlot46 slot46, TSlot47 slot47, TSlot48 slot48, TSlot49 slot49, TSlot50 slot50, TSlot51 slot51, TSlot52 slot52, TSlot53 slot53, TSlot54 slot54, TSlot55 slot55, TSlot56 slot56, TSlot57 slot57, TSlot58 slot58, TSlot59 slot59, TSlot60 slot60, TSlot61 slot61, TSlot62 slot62, TSlot63 slot63)
		{
			Slot0 = slot0;
			Slot1 = slot1;
			Slot2 = slot2;
			Slot3 = slot3;
			Slot4 = slot4;
			Slot5 = slot5;
			Slot6 = slot6;
			Slot7 = slot7;
			Slot8 = slot8;
			Slot9 = slot9;
			Slot10 = slot10;
			Slot11 = slot11;
			Slot12 = slot12;
			Slot13 = slot13;
			Slot14 = slot14;
			Slot15 = slot15;
			Slot16 = slot16;
			Slot17 = slot17;
			Slot18 = slot18;
			Slot19 = slot19;
			Slot20 = slot20;
			Slot21 = slot21;
			Slot22 = slot22;
			Slot23 = slot23;
			Slot24 = slot24;
			Slot25 = slot25;
			Slot26 = slot26;
			Slot27 = slot27;
			Slot28 = slot28;
			Slot29 = slot29;
			Slot30 = slot30;
			Slot31 = slot31;
			Slot32 = slot32;
			Slot33 = slot33;
			Slot34 = slot34;
			Slot35 = slot35;
			Slot36 = slot36;
			Slot37 = slot37;
			Slot38 = slot38;
			Slot39 = slot39;
			Slot40 = slot40;
			Slot41 = slot41;
			Slot42 = slot42;
			Slot43 = slot43;
			Slot44 = slot44;
			Slot45 = slot45;
			Slot46 = slot46;
			Slot47 = slot47;
			Slot48 = slot48;
			Slot49 = slot49;
			Slot50 = slot50;
			Slot51 = slot51;
			Slot52 = slot52;
			Slot53 = slot53;
			Slot54 = slot54;
			Slot55 = slot55;
			Slot56 = slot56;
			Slot57 = slot57;
			Slot58 = slot58;
			Slot59 = slot59;
			Slot60 = slot60;
			Slot61 = slot61;
			Slot62 = slot62;
			Slot63 = slot63;
		}
	
		public override int GetHashCode()
		{
			return Slot0.GetHashCode() ^ Slot1.GetHashCode() ^ Slot2.GetHashCode() ^ Slot3.GetHashCode() ^ Slot4.GetHashCode() ^ Slot5.GetHashCode() ^ Slot6.GetHashCode() ^ Slot7.GetHashCode() ^ Slot8.GetHashCode() ^ Slot9.GetHashCode() ^ Slot10.GetHashCode() ^ Slot11.GetHashCode() ^ Slot12.GetHashCode() ^ Slot13.GetHashCode() ^ Slot14.GetHashCode() ^ Slot15.GetHashCode() ^ Slot16.GetHashCode() ^ Slot17.GetHashCode() ^ Slot18.GetHashCode() ^ Slot19.GetHashCode() ^ Slot20.GetHashCode() ^ Slot21.GetHashCode() ^ Slot22.GetHashCode() ^ Slot23.GetHashCode() ^ Slot24.GetHashCode() ^ Slot25.GetHashCode() ^ Slot26.GetHashCode() ^ Slot27.GetHashCode() ^ Slot28.GetHashCode() ^ Slot29.GetHashCode() ^ Slot30.GetHashCode() ^ Slot31.GetHashCode() ^ Slot32.GetHashCode() ^ Slot33.GetHashCode() ^ Slot34.GetHashCode() ^ Slot35.GetHashCode() ^ Slot36.GetHashCode() ^ Slot37.GetHashCode() ^ Slot38.GetHashCode() ^ Slot39.GetHashCode() ^ Slot40.GetHashCode() ^ Slot41.GetHashCode() ^ Slot42.GetHashCode() ^ Slot43.GetHashCode() ^ Slot44.GetHashCode() ^ Slot45.GetHashCode() ^ Slot46.GetHashCode() ^ Slot47.GetHashCode() ^ Slot48.GetHashCode() ^ Slot49.GetHashCode() ^ Slot50.GetHashCode() ^ Slot51.GetHashCode() ^ Slot52.GetHashCode() ^ Slot53.GetHashCode() ^ Slot54.GetHashCode() ^ Slot55.GetHashCode() ^ Slot56.GetHashCode() ^ Slot57.GetHashCode() ^ Slot58.GetHashCode() ^ Slot59.GetHashCode() ^ Slot60.GetHashCode() ^ Slot61.GetHashCode() ^ Slot62.GetHashCode() ^ Slot63.GetHashCode();
		}
	
		public override string ToString()
		{
			return String.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50}, {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59}, {60}, {61}, {62}, {63})", Slot0, Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10, Slot11, Slot12, Slot13, Slot14, Slot15, Slot16, Slot17, Slot18, Slot19, Slot20, Slot21, Slot22, Slot23, Slot24, Slot25, Slot26, Slot27, Slot28, Slot29, Slot30, Slot31, Slot32, Slot33, Slot34, Slot35, Slot36, Slot37, Slot38, Slot39, Slot40, Slot41, Slot42, Slot43, Slot44, Slot45, Slot46, Slot47, Slot48, Slot49, Slot50, Slot51, Slot52, Slot53, Slot54, Slot55, Slot56, Slot57, Slot58, Slot59, Slot60, Slot61, Slot62, Slot63);
		}
	}
}
