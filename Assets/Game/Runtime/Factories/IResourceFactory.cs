using Game.Runtime.View;

namespace Game.Game.Runtime.Factories
{
    public interface IResourceFactory<out T> : IFactory<T>, ISceneObject
    {
    }
}