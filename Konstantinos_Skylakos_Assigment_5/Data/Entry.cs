using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konstantinos_Skylakos_Assigment_5
{

	public class Rootobject
	{
		public Class1[] Property1 { get; set; }
	}

	public class Class1
	{
		public Roomtype[] roomtypes { get; set; }
		public Entry[] entries { get; set; }
	}

	public class Roomtype
	{
		public string name { get; set; }
	}

	public class Entry
	{
		public string hotelName { get; set; }
		public int rating { get; set; }
		public string city { get; set; }
		public string thumbnail { get; set; }
		public float guestrating { get; set; }
		public Ratings ratings { get; set; }
		public string mapurl { get; set; }
		public Filter[] filters { get; set; }
		public int price { get; set; }
	}

	public class Ratings
	{
		public float no { get; set; }
		public string text { get; set; }
	}

	public class Filter
	{
		public string name { get; set; }
	}

}
