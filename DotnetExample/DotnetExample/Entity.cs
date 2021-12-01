namespace DotnetExample;

abstract public class Entity
{
    public int Id { get; set; }  
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}