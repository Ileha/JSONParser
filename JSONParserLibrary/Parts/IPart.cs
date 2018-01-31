using System;
namespace JSONParserLibrary
{
	public interface IPart : IToJSON
	{
		string name { get; set; }
		string value { get; }
		IPart parent { get; set; }
		void SetValue(object _value);

		void AddPart(IPart element);
		void RemovePart(string name);
		IPart GetPart(string name);
		IPart GetPart(int index);
		void RemovePart(int index);
		int Count { get; }
	}
}
