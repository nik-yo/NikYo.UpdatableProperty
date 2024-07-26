# NikYo.UpdatableProperty

Manage updatable properties of a class.

## Version

0.1.0

## Installation

Run the following command in the Nuget Package Manager Console:

```
PM> Install-Package NikYo.UpdatableProperty
```

### Target Framework

.NET Standard 2.0

## Usage

Add [Updatable] attribute on the property that can be updated
```
public class Pet
{
    public string Type { get; set; } = null!;
	
    [Updatable]
    public string Name { get; set; } = null!;
    
	[Updatable(Condition = UpdateCondition.NotDefault)]
    public bool Tagged { get; set; }
    
	[Updatable(Condition = UpdateCondition.StringNotNullOrEmpty)]
    public string Color { get; set; } = null!;
    
	[Updatable(Condition = UpdateCondition.IntegerZeroOrMore)]
    public int Friends { get; set; }
    
	[Updatable(Condition = UpdateCondition.IntegerMoreThanZero)]
    public int Age { get; set; }
}
```
Update current object with properties of new object using UpdateWith extension.

```
var dog = new Pet { Type = "dog", Name = "Pochi", Color = "white", Friends = 1, Age = 2 };

Console.WriteLine($"Before: {JsonSerializer.Serialize(dog)}");

var updatedDog = new Pet { Type = "doggo", Name = "Max", Color = "brown" }; //Friends = 0, Age = 0

// Name, Color, and Friends will be updated
dog.UpdateWith(updatedDog);

Console.WriteLine($"Updated: {JsonSerializer.Serialize(dog)}");

// Name, Tagged, Age will be updated
var updatedDog2 = new Pet { Type = "doggy", Name = "Maxi", Tagged = true, Friends = -1, Age = 3 }; //Color = null

dog.UpdateWith(updatedDog2);

Console.WriteLine($"Updated2: {JsonSerializer.Serialize(dog)}");
```

## Limitations

- It uses reflection.
- For loop is used over all the properties.

## License

MIT License