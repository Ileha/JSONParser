using System;
namespace JSONParserLibrary
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string r = "{\"firstName\": \"Иван\", \"lastName\": \"Иванов\", \"address\": {\"streetAddress\": \"Московское ш., 101, кв.101\", \"city\": \"Ленинград\", \"postalCode\": 101101}, \"phoneNumbers\": [\"812 123-1234\", \"916 123-4567\"]}";
			IPart data;
			JSONParser.Convert(out data, r);
			Console.WriteLine();
		}
	}
}
