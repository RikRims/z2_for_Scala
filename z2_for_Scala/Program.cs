using z2_for_Scala;


List<Car> CarsRead;

Car car = new("aa123 as12", "VAZ 2113", "red", 37);
Car car2 = new("mk893 at11", "VAZ 2101", "red", 3);
Car car3 = new("mk892 at11", "VAZ 2102", "red", 3);
Car car4 = new("mk895 at11", "VAZ 2101", "black", 3);
Car car5 = new("mk896 at11", "VAZ 2101", "red", 3);
Car car6 = new("sd132 js23", "VAZ 2109", "red", 7);

Console.WriteLine(Car.SaveInJson(car));
Console.WriteLine(Car.SaveInJson(car2));
Console.WriteLine(Car.SaveInJson(car3));
Console.WriteLine(Car.SaveInJson(car4));
Console.WriteLine(Car.SaveInJson(car5));
Console.WriteLine(Car.SaveInJson(car6));

Console.WriteLine(Car.StatystycKol());
Console.WriteLine($"красного цвета: {Car.StatystycKolParametr("red")} шт.");
Console.WriteLine($"Копеек: {Car.StatystycKolParametr("VAZ 2101")} шт.");
Console.WriteLine(Car.Remove(car2.Number));

Car.SortBulBul();

CarsRead = Car.GetCars();


for(int i = 0; i<CarsRead.Count; i++)
{
    Console.WriteLine($"Номер: {CarsRead[i].Number}\nМарка: {CarsRead[i].Marka}\nЦвет: {CarsRead[i].Color}\nГод выпуска: {CarsRead[i].Year}\n");
}
