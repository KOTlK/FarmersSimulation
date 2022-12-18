namespace Game.Runtime.Environment.Crops
{
    public interface IPlant<out T> : ICollectable, IRecoverable<T>
    {
    }
}