// See https://aka.ms/new-console-template for more information
using NikYo.UpdatableProperty;
using NikYo.UpdatableProperty.Example;
using System.Text.Json;

Console.WriteLine("Hello, World!");

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