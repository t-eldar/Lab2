namespace Lab2;
public class ResearchTeam : Team, INameAndCopy
{
	private string _researchTheme;
	private TimeFrame _researchDuration;
	private List<Person> _members;
	private List<Paper> _papers;

	public ResearchTeam()
		: base()
	{
		_researchTheme = "No theme";
		_researchDuration = TimeFrame.Year;
		_papers = new List<Paper>();
		_members = new List<Person>();
	}
	public ResearchTeam(string researchTheme, string teamName,
		int registrationNumber, TimeFrame researchDuration)
		: base(teamName, registrationNumber)
	{
		_researchTheme = researchTheme;
		_researchDuration = researchDuration;
		_papers = new List<Paper>();
		_members = new List<Person>();
	}

	public string ResearchTheme
	{
		get => _researchTheme;
		set => _researchTheme = value;
	}
	public TimeFrame ResearchDuration
	{
		get => _researchDuration;
		set => _researchDuration = value;
	}
	public List<Paper> Papers
	{
		get => _papers;
		set => _papers = value;
	}
	public List<Person> Members
	{
		get => _members;
		set => _members = value;
	}
	public Paper LatePaper
	{
		get
		{
			if (_papers is null || _papers.Count == 0)
				return null;
			return _papers.MinBy(pub => pub.PublicationTime);
		}
	}
	public Team Team
	{
		get => new Team(Name, RegistrationNumber);
		set
		{
			OrganizationName = value.Name;
			NumberOfRegistration = value.RegistrationNumber;
		}
	}
	public bool this[TimeFrame timeFrame] 
		=> _researchDuration == timeFrame;

	public void AddPapers(params Paper[] papers) 
		=> _papers.AddRange(papers);
	public void AddMembers(params Person[] people)
		=> _members.AddRange(people);

	public IEnumerable<Person> MembersWithouPapers()
	{
		for (int i = 0; i < _members.Count; i++)
		{
			var hasPaper = false;
			for (int j = 0; j < _papers.Count && !hasPaper; j++)
			{
				if (_members[i] == _papers[j].Author)
					hasPaper = true;
			}
			if (!hasPaper)
				yield return _members[i];
		}
	}
	public IEnumerable<Paper> PapersInLastYears(int years)
	{
		var currentTime = DateTime.Now;
		var minDate = new DateTime(currentTime.Year - years,
			currentTime.Month, currentTime.Day);

		foreach (var paper in _papers)
		{
			if (paper.PublicationTime >= minDate)
				yield return paper;
		}
	}

	public virtual string ToShortString() => 
		$"Тема: {_researchTheme}\n" +
		$"Название команды: {Name}\n" +
		$"Регистационный номер: {RegistrationNumber}\n" +
		$"Время исследования: {_researchDuration}\n";

	public override string ToString()
	{
		var papersString = "\n";
		var membersString = "\n";
		if (_members.Count == 0 || _members is null)
			membersString = "Нет участников";
		else
			foreach (var member in _members)
				membersString += $"{member}\n";

		if (_papers.Count == 0 || _papers is null)
			papersString = "Нет публикаций";
		else
			foreach(var paper in _papers)
				papersString += $"{paper}\n\n";

		return ToShortString() +
			$"Публикации: {papersString}" +
			$"Участники: {membersString}";
	}
	public override bool Equals(object obj)
	{
		if (obj is ResearchTeam team)
			return _researchTheme == team.ResearchTheme
				&& OrganizationName == team.Name
				&& _researchDuration == team.ResearchDuration
				&& NumberOfRegistration == team.RegistrationNumber
				&& _papers.SequenceEqual(team.Papers);
		return false;
	}
	public override int GetHashCode()
	{
		var hash = 17;
		
		hash = hash * 23 + _researchTheme.GetHashCode();
		hash = hash * 23 + OrganizationName.GetHashCode();
		hash = hash * 23 + NumberOfRegistration.GetHashCode();
		hash = hash * 23 + _researchDuration.GetHashCode();

		foreach (var member in _members)
			hash = hash * 23 + member.GetHashCode();
		foreach (var paper in _papers)
			hash = hash * 23 + paper.GetHashCode();

		return hash;
	}

	public static bool operator ==(ResearchTeam team1, ResearchTeam team2) 
		=> team1.Equals(team2);
	public static bool operator !=(ResearchTeam team1, ResearchTeam team2) 
		=> !team1.Equals(team2);

	public override object DeepCopy()
	{
		var newTeam = new ResearchTeam();

		newTeam.RegistrationNumber = NumberOfRegistration;
		newTeam.ResearchTheme = _researchTheme;
		newTeam.ResearchDuration = _researchDuration;
		newTeam.Name = OrganizationName;

		var newTeamPapers = new List<Paper>();
		foreach(var paper in _papers)
			newTeamPapers.Add(paper.DeepCopy() as Paper);

		var newTeamMembers = new List<Person>();
		foreach(var member in _members)
			newTeamMembers.Add(member.DeepCopy() as Person);
		newTeam.Members = newTeamMembers;
		newTeam.Papers = newTeamPapers;

		return newTeam;
	}

}


