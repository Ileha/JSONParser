using System;
namespace JSONParserLibrary
{
	public class Part : IToJSON
	{
		private string _name;
		private IPartValue _value;
		private Part _parent;

		public string Name { get { return _name; } }
		public IPartValue Value { get { return _value; } }
		public Part Parent { get { return _parent; } }

		public Part(string name) {
			_name = name;
		}
		//public Part(string name, Part parent) {
		//	_name = name;
		//	_parent = parent;
		//}
		public Part(string name, IPartValue value) {
			_name = name;
			_value = value;
			_value.OnAddingToPart(this);
		}
		//public Part(string name, Part parent ,IPartValue value) {
		//	_name = name;
		//	_value = value;
		//	_parent = parent;
		//	_value.OnAddingToPart(this);
		//}

		public void ChangeName(string new_name) {
			_name = new_name;
		}
		public void SetValue(IPartValue new_value) {
			_value = new_value;
			_value.OnAddingToPart(this);
		}
		public void ChangeParent(Part new_parent)
		{
			_parent = new_parent;
		}

		public string ToJSON() {
			return string.Format("\"{0}\": {1}", _name, _value.ToJSON());
		}
	}
}
