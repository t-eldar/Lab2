namespace Lab2;

public class Paper
{
	public string Name { get; set; }
	public Person Author { get; set; }
	public DateTime PublicationTime { get; set; }
	
	public Paper()
	{
		Name = "No name";
		Author = new Person();
		PublicationTime = DateTime.MinValue;
	}
	public Paper(string name, Person author, DateTime publicationTime)
	{
		Name = name;
		Author = author;
		PublicationTime = publicationTime;
	}
	public override string ToString()
		=> $"Название: {Name}, \nАвтор: {Author}, \nОпубликовано: {PublicationTime}";
	public override bool Equals(object obj)
	{
		if (obj is Paper paper)
			return Author == paper.Author
				&& Name == paper.Name
				&& PublicationTime == paper.PublicationTime;
		return false;
	}
	public override int GetHashCode()
	{
		var hash = 17;

		hash = hash * 23 + Name.GetHashCode();
		hash = hash * 23 + Author.GetHashCode();
		hash = hash * 23 + PublicationTime.GetHashCode();

		return hash;
	}
	public static bool operator ==(Paper paper1, Paper paper2)
		=> paper1.Equals(paper2);
	
	public static bool operator !=(Paper paper1, Paper paper2)
		=> !paper1.Equals(paper2);

	public object DeepCopy()
	{
		var newPaper = new Paper();

		newPaper.Name = Name;
		newPaper.Author = Author.DeepCopy() as Person;
		newPaper.PublicationTime = PublicationTime;

		return newPaper;
	}
}
