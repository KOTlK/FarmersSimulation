using System;

namespace Game.Runtime.Input
{
    public interface IClickInput<out T>
    {
        event Action<T> Clicked;
    }
}