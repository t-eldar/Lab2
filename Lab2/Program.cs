using Lab2;

var team1 = new Team("New team", 12);
var team2 = new Team("New team", 12);

Console.WriteLine($"Равенство ссылок: {Object.ReferenceEquals(team1, team2)}");
Console.WriteLine($"Равенство объектов: {team1.Equals(team2)}");

Console.WriteLine($"Хэш код первой команды: {team1.GetHashCode()}");
Console.WriteLine($"Хэш код второй команды: {team2.GetHashCode()}");

try
{
	team1.RegistrationNumber = -12;
}
catch (Exception e)
{
	Console.WriteLine($"Ошибка: {e.Message}");
}
Console.WriteLine();

var researchTeam = new ResearchTeam("Польза воды", "Команда А", 123, TimeFrame.Year);

var person1 = new Person("Виктор", "Корнеплод", new DateTime(1993, 12, 4));
var person2 = new Person("Сергей", "Иванов", new DateTime(1960, 10, 24));
var person3 = new Person("Петр", "Петров", new DateTime(2000, 1, 21));

researchTeam.AddMembers(person1, person2, person3);
researchTeam.AddPapers(new[]
{
	new Paper("Польза минеральной воды", person1, new DateTime(2018, 12, 4)),
	new Paper("Польза родниковой воды", person1, new DateTime(2019, 9, 14)),
	new Paper("Ошибки принятия воды", person2, new DateTime(2021, 5, 10))
});

Console.WriteLine(researchTeam);

Console.WriteLine($"Team: {researchTeam.Team}");

var researchTeamCopy = researchTeam.DeepCopy() as ResearchTeam;

researchTeam.Team = new Team("Новая команда А", 1212);
researchTeam.Papers[1] = new Paper("Риск обезвоживания", person3, DateTime.Now);
researchTeam.AddMembers(new Person("Андрей", "Алексеев", new DateTime(1993, 7, 12)));

Console.WriteLine();

Console.WriteLine("Оригинал: ");
Console.WriteLine(researchTeam);
Console.WriteLine("Копия: ");
Console.WriteLine(researchTeamCopy);

Console.WriteLine("Участники без публикаций: ");
foreach (var member in researchTeam.MembersWithouPapers())
{
	Console.WriteLine(member);
}

Console.WriteLine();
Console.WriteLine("Публикации за последние 2 года: ");
foreach (var paper in researchTeam.PapersInLastYears(2))
{
	Console.WriteLine(paper);
}