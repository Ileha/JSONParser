using System;
namespace JSONParserLibrary
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//string r = "{\"firstName\": \"Иван\", \"lastName\": \"Иванов\", \"address\": {\"streetAddress\": \"Московское ш., 101, кв.101\", \"city\": \"Ленинград\", \"postalCode\": 101101}, \"phoneNumbers\": [\"812 123-1234\", \"916 123-4567\"]}";
            //string r = "{\"name\":\"Иванов Михаил\",\"age\":21}";
            //string r = "[\"C\",\"C++\",\"Java\",\"Python\"]";
            //string r = "[{\"name\":\"C\"},{\"name\":\"C++\"},{\"name\":\"Java\"}]";
            string r = "{\"integerData\": 3, \"stringData\": \"StringValue\", \"foo\": [16, 2, 77, 40, 12071]}";
            IPart data;
			JSONParser.Convert(out data, r);
            Console.WriteLine(data.ToJSON());
			Console.WriteLine();
		}
	}
}
