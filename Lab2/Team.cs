namespace Lab2;
public class Team : INameAndCopy
{
	protected string OrganizationName;
	protected int NumberOfRegistration;

	public Team()
	{
		OrganizationName = "No organization name";
		RegistrationNumber = 1;
	}
	public Team(string organizationName, int registrationNumber)
	{
		Name = organizationName;
		RegistrationNumber = registrationNumber;
	}
	public string Name
	{
		get => OrganizationName;
		set => OrganizationName = value;
	}
	public int RegistrationNumber
	{
		get => NumberOfRegistration;
		set
		{
			if (value <= 0)
				throw new ArgumentException(
					"Registration Number must be more than zero");
			NumberOfRegistration = value;
		}
	}
	public override bool Equals(object obj)
	{
		if (obj is Team team)
			return team.Name == Name
				&& team.RegistrationNumber == RegistrationNumber;
		return false;
	}
	public override int GetHashCode()
	{
		var hash = 17;

		hash = hash * 23 + OrganizationName.GetHashCode();
		hash = hash * 23 + NumberOfRegistration.GetHashCode();

		return hash;
	}
	public override string ToString()
		=> $"Название организации: {Name}, " +
		$"Регистрационный номер: {RegistrationNumber}";
	public static bool operator ==(Team team1, Team team2)
		=> team1.Equals(team2);
	public static bool operator !=(Team team1, Team team2)
		=> !team1.Equals(team2);
	public virtual object DeepCopy()
	{
		var newTeam = new Team();
		
		newTeam.Name = OrganizationName;
		newTeam.RegistrationNumber = NumberOfRegistration;
		
		return newTeam;
	}
}