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
IPart part = JSONParser.ConvertFromJSON(for_parse);
Console.WriteLine(part.GetPart("address").GetPart("postalCode").value);

/*
output:
101101
*/
```  

#### Create object from code
For construct ```JSONParser``` from code you should use code like this
```cs
JSONParser pars = new JSONParser(
  new PartStruct("root",
    new PartString("firstName", "Иван"),
    new PartString("lastName", "Иванов"),
    new PartStruct("address",
      new PartString("streetAddress", "Московское ш., 101, кв.101"),
      new PartString("city", "Ленинград"),
      new PartNotString("postalCode", "101101")
    ),
    new PartArray("phoneNumbers",
      new PartString("", "812 123-1234"),
      new PartString("", "916 123-4567")
    )
  )
);
```  
```IPart``` you can get from field ```pars.Data```  

#### For parsing to json format
if you use ```JSONParser``` you should invoke method ```ConvertToJSON()```. Also you can use ```IPart``` so you should invoke ```part.ToJSON()```.

#### IPart
Name                                   | Description                                                          |
-------------------------------------- | -------------------------------------------------------------------- |
string name                            | Key from json pair key:value                                         |
IPart parent                           | link to the top object in the hierarchy                              |
string value                           | Get value in string. Implemented in PartString and PartNotString     |
void SetValue(object _value)           | Set _value to value. Implemented in PartString and PartNotString     |
void AddPart(IPart element)            | Add IPart to itself. Implemented in PartStruct and PartArray         |
void RemovePart(string name)(int index)| Remove Part by name or index. Implemented in PartStruct and PartArray|
IPart GetPart(string name)(int index)  | Get IPart by name or index. Implemented in PartStruct and PartArray  |
int Count                              | Get length of array. Implemented in PartArray                        |
string ToJSON()                        | return its content in format key:value.                              |
string ValueToJSON()                   | return its content in format value.                                  |
