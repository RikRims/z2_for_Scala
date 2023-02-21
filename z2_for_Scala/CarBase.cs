using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace z2_for_Scala
{
    public class Car
    {
        //номер автомобиля
        public string? Number { get; }
        //марка автомобиля
        public string? Marka { get; }
        //цвет автомобиля
        public string? Color { get; }
        //год выпуска автомобиля
        public int Year { get; set; }

        public Car(string? number, string? marka, string? color, int year)
        {
            Number=number;
            Marka=marka;
            Color=color;
            Year=year;
        }
        //переопределение сравнения
        public bool Equals(Car obj)
        {
            if((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Car temp = obj;
                return (Number == temp.Number);
            }
        }
        //удаление из файла
        public static string Remove(string? num)
        {
            string result = "";

            try
            {
                List<Car> list = GetCars();

                File.Delete("Cars.json");

                for(int i = 0; i<list.Count; i++)
                {
                    if(list[i].Number == num)
                    {
                        list.RemoveAt(i);
                        result = "Удалён!";
                        i--;
                    }
                    else
                    {
                        SaveInJson(list[i]);
                    }
                }
                if(result == "")
                {
                    result = "объект не найден";
                }
            }
            catch(Exception ex)
            {
                return result = ex.Message;
            }

            return result;
        }
        public static string SaveInJson(Car cars)
        {
            string result = "";

            try
            {
                List<Car> list = GetCars();

                foreach(Car car in list)
                {
                    if(car.Equals(cars))
                    {
                        return result = "Этот автомобиль уже есть в файле!";

                    }
                }

                if(result == "")
                {
                    WriteToJson(cars);
                    return result = "Успешно!";
                }
            }
            catch(Exception e)
            {
                if(e.HResult == -2147024894)
                {
                    WriteToJson(cars);
                    return result = "Успешно!";
                }
                return result = e.Message;
            }
            return result;
        }
        //добавление в Json файл
        private static void WriteToJson(Car cars)
        {
            using(StreamWriter fs = File.AppendText("Cars.json"))
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize(cars, options);
                fs.Write(json);
            }
        }
        //чтение из Json файла
        public static List<Car> GetCars()
        {
            var cars = new List<Car>();
            JsonTextReader reader = new(new StreamReader("Cars.json"))
            {
                SupportMultipleContent = true
            };
            while(true)
            {
                if(!reader.Read())
                {
                    break;
                }

                Newtonsoft.Json.JsonSerializer serializer = new();
                Car temp_car = serializer.Deserialize<Car>(reader);
                cars.Add(temp_car);
            }
            reader.Close();

            return cars;
        }
        //получение статистики по количеству записей
        public static int StatystycKol()
        {
            int result = 0;
            try
            {
                List<Car> list = GetCars();
                result = list.Count;
            }
            catch(Exception e)
            {
                return result = e.HResult;
            }
            return result;
        }
        //получение статистики по количеству записей одинакковым цветом или маркой
        public static int StatystycKolParametr(string parametr)
        {
            int result = 0;
            try
            {
                List<Car> list = GetCars();
                foreach(Car car in list)
                {
                    if(car.Color == parametr)
                    {
                        result += 1;
                    }
                    if(car.Marka == parametr)
                    {
                        result += 1;
                    }
                }
            }
            catch(Exception e)
            {
                return result = e.HResult;
            }
            return result;
        }

        public static void SortBulBul()
        {
            try
            {
                List<Car> list = GetCars();
                File.Delete("Cars.json");
                list.Sort(delegate(Car x, Car y) {
                    return x.Year.CompareTo(y.Year);
                });
                foreach(Car car in list)
                {

                    SaveInJson(car);
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}