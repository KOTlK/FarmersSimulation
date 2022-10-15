namespace Game.Runtime.Random
{
    public interface IRandomGenerator<out T>
    {
        T Next();
    }
}