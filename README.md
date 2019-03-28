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
*parsing*
```cs
JSONParser pars = new JSONParser(for_parse);
Console.WriteLine(pars["phoneNumbers.1"].value);
Console.WriteLine(pars.Data.Get("address").Get("postalCode").value);
/*
output:
916 123-4567
101101
*/
```

#### Create object from code
For construct ```JSONParser``` from code you should use code like this
```cs
JSONParser pars = new JSONParser(new PartStruct()
  .Add("firstName", new PartValue("Иван"))
  .Add("lastName", new PartValue("Иванов"))
  .Add("address", new PartStruct()
    .Add("streetAddress", new PartValue("Московское ш., 101, кв.101"))
    .Add("city", new PartValue("Ленинград"))
    .Add("postalCode", new PartValue(101101))
  )
  .Add("phoneNumbers", new PartArray()
    .Add(new PartValue("812 123-1234"))
    .Add(new PartValue("916 123-4567"))
  )
);
```  
or like this
```cs
JSONParser pars = new JSONParser(new PartStruct()
  .Add("firstName", "Иван")
  .Add("lastName", "Иванов")
  .Add("address", new PartStruct()
    .Add("streetAddress", "Московское ш., 101, кв.101")
    .Add("city", "Ленинград")
    .Add("postalCode", 101101)
  )
  .Add("phoneNumbers", new PartArray()
    .Add("812 123-1234")
    .Add("916 123-4567")
  )
);
```  
```IPart``` you can get from field ```pars.Data```  

#### For parsing to json format
if you use ```JSONParser``` or ```IPart``` you should invoke method ```ToJSON()``` for serialize your data

#### IPart
Name                                   | Description                                                               |
-------------------------------------- | ------------------------------------------------------------------------- |
string value                           | Get value in string. Implemented in PartValue                             |
void SetValue(Object)                  | Set value. Implemented in PartValue                                       |
void Add(IPart)/(string, IPart)        | Add IPart to itself. Implemented in PartStruct and PartArray              |
void Add(Object)/(string, Object)      | Create IPart and add it to itself. Implemented in PartStruct and PartArray|
void Remove(string)/(int)              | Remove Part by name or index. Implemented in PartStruct and PartArray     |
IPart Get(string)(int)                 | Get IPart by name or index. Implemented in PartStruct and PartArray       |
int Count                              | Get length of array. Implemented in PartArray                             |
string ToJSON()                        | return its content in format key:value.                                   |
