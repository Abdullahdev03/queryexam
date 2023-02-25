List<string> words = new List<string> { "apple", "banana", "orange", "grape", "mango", "blablablabla"};


var longest = (from w in words 
              orderby w.Length descending select w).Take(1);
foreach (var item in longest)
{
  System.Console.WriteLine(item);
}