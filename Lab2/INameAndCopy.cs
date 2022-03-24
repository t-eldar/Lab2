namespace Lab2;
public interface INameAndCopy
{
	string Name { get; }
	object DeepCopy();
}