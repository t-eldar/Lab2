namespace Lab2;
public class Person
{
	private string _name;
	private string _surname;
	private DateTime _birthDate;

	public Person()
	{
		_name = "No name";
		_surname = "No surname";
		_birthDate = DateTime.MinValue;
	}
	public Person(string name, string surname, DateTime birthDate)
	{
		_name = name;
		_surname = surname;
		_birthDate = birthDate;
	}

	public string Name
	{
		get => _name; 
		set => _name = value;
	}
	public string Surname
	{
		get => _surname;
		set => _surname = value;
	}
	public DateTime BirthDate
	{
		get => _birthDate;
		set => _birthDate = value;
	}
	public int YearOfBirth 
	{
		get => (int)_birthDate.Year;
		set 
		{ 
			_birthDate = new DateTime(value, 
				_birthDate.Month, _birthDate.Day); 
		}
	}
	public override string ToString()
		=> $"Имя: {_name} Фамилия: {_surname} Год рождения: {_birthDate.Year}";
	public override bool Equals(object obj)
	{
		if (obj is Person person)
			return _birthDate == person.BirthDate
				&& _name == person.Name
				&& _surname == person.Surname;
		return false;
	}
	public override int GetHashCode()
	{
		var hash = 17;

		hash = hash * 23 + _name.GetHashCode();
		hash = hash * 23 + _surname.GetHashCode();
		hash = hash * 23 + _birthDate.GetHashCode();

		return hash;
	}
	public static bool operator ==(Person person1, Person person2)
		=> person1.Equals(person2);
	
	public static bool operator !=(Person person1, Person person2)
		=> !person1.Equals(person2);

	public object DeepCopy()
	{
		var newPerson = new Person();

		newPerson.Name = Name;
		newPerson.Surname = Surname;
		newPerson.BirthDate = BirthDate;
		
		return newPerson;
	}
}
