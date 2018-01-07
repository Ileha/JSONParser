### How to use  
#### For parsing from json format
You need use code like this  
*json string example*
```json
{
  "firstName": "Иван",
  "lastName": "Иванов",
  "address": {
    "streetAddress": "Московское ш., 101, кв.101",
    "city": "Ленинград",
    "postalCode": 101101
  },
  "phoneNumbers": [
    "812 123-1234",
    "916 123-4567"
  ]
}
```
*json string on C#*
```cs
string for_parse = "{\"firstName\": \"Иван\",\"lastName\": \"Иванов\",\"address\": {\"streetAddress\": \"Московское ш., 101, кв.101\",\"city\": \"Ленинград\",\"postalCode\": 101101},\"phoneNumbers\": [\"812 123-1234\",\"916 123-4567\"]}";
```
```cs
JSONParser pars = new JSONParser(for_parse);
Console.WriteLine(pars["phoneNumbers.1"].Value.value);

/*
output:
916 123-4567
*/
```
Or like this  
```cs
Part part = JSONParser.ConvertFromJSON(for_parse);
Console.WriteLine(part.Value.GetPart("address").Value.GetPart("postalCode").Value.value);

/*
output:
101101
*/
```  

#### Create object from code
For construct ```JSONParser``` from code you should use code like this
```cs
JSONParser pars = new JSONParser();
	pars.Data.SetValue(
		new PartStruct(new Part("firstName",new PartString("Иван")), 
		new Part("lastName", new PartString("Иванов")), 
		new Part("address", new PartStruct(
			new Part("streetAddress", new PartString("Московское ш., 101, кв.101")),
			new Part("city", new PartString("Ленинград")),
			new Part("postalCode", new PartNotString("101101"))
		)),
		new Part("phoneNumbers", new PartArray(
			new Part("0", new PartString("812 123-1234")),
			new Part("1", new PartString("916 123-4567"))
		))
));
```  
```Part``` you can get from field ```pars.Data```  

#### For parsing to json format
if you use ```JSONParser``` you should invoke method ```ConvertToJSON()```. Also you can use ```Part``` so you should invoke ```part.Value.ToJSON()```.

#### Part
Name            | Description                                            |
--------------- | ------------------------------------------------------ |
string Name     | Key from json pair key:value                           |
IPartValue Value| Get IPartValue from json pair key:value                |
Part Parent     | link to the top object in the hierarchy                |
string ToJSON() | return string in format "name_of_key": Value.ToJSON()  |

#### IPartValue
Name                                   | Description                                                          |
-------------------------------------- | -------------------------------------------------------------------- |
string value                           | Get value in string. Implemented in PartString and PartNotString     |
void SetValue(object _value)           | Set _value to value. Implemented in PartString and PartNotString     |
void AddPart(Part element)             | Add Part to itself. Implemented in PartStruct and PartArray          |
void RemovePart(string name)(int index)| Remove Part by name or index. Implemented in PartStruct and PartArray|
Part GetPart(string name)(int index)   | Get Part by name or index. Implemented in PartStruct and PartArray   |
int Count                              | Get length of array. Implemented in PartArray                        |
string ToJSON()                        | return its content.                                                  |
