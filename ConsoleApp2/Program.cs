using tg;

string name = "чубирик";
string password = "siu";
sql.RegisterUser(name, password);
var s = sql.GetUsers();
foreach(string d in s)
{

    Console.WriteLine(d);
}

