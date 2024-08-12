using System.Diagnostics;
using Reflection;
using Newtonsoft.Json;

var instance = new F().Get();
var iterationCnt = 1000;
Serializer serializer = new Serializer();

string serialization = "";
Stopwatch timer = Stopwatch.StartNew();

for (int i = 0; i < iterationCnt; i++)
{
    serialization = serializer.CsvSerialize(instance);
}
timer.Stop();
Console.WriteLine($"Серилизация в CSV выполнена за {timer.ElapsedMilliseconds} мс. (количество итераций = {iterationCnt}).\nРезультат сериализации:\n{serialization}");

F deserialization = new F();
timer.Restart();

for (int i = 0; i < iterationCnt; i++)
{
    deserialization = serializer.CsvDeserialize<F>(serialization);
}
timer.Stop();
Console.WriteLine($"Десерилизация из CSV выполнена за {timer.ElapsedMilliseconds} мс. (количество итераций = {iterationCnt}).\nРезультат сериализации:\n{deserialization.ToString()}");

timer.Restart();



string serialization_ = "";

for (int i = 0; i < iterationCnt; i++)
{
    serialization_ = JsonConvert.SerializeObject(instance);
}
timer.Stop();
Console.WriteLine($"Серилизация в Json выполнена за {timer.ElapsedMilliseconds} мс. (количество итераций = {iterationCnt}).\nРезультат сериализации:\n{serialization_}");

F deserialization_ = new F();
timer.Restart();

for (int i = 0; i < iterationCnt; i++)
{
    deserialization_ = JsonConvert.DeserializeObject<F>(serialization_);
}
timer.Stop();
Console.WriteLine($"Десерилизация из Json выполнена за {timer.ElapsedMilliseconds} мс. (количество итераций = {iterationCnt}).\nРезультат сериализации:\n{deserialization_.ToString()}");