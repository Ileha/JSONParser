using System;
namespace JSONParserLibrary
{
	public interface IPartValue
	{
		string value { get; }
		void SetValue(object _value);

		void AddPart(Part element);
		void RemovePart(string name);
		Part GetPart(string name);
		void RemovePart(int index);
		Part GetPart(int index);
		int Count { get; }

		string ToJSON();
	}
}
