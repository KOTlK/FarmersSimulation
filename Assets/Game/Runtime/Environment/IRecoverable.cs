using System;

namespace Game.Runtime.Environment
{
    public interface IRecoverable<out T>
    {
        event Action<T> Recovered;
    }
}