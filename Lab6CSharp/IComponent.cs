namespace Lab6;

public interface IComponent : IDisplayable
{
    string Material { get; set; }
    double Weight { get; set; }
}