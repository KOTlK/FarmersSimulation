namespace Game.Runtime.TileMap.Tiles
{
    public interface ITileBuilder
    {
        ITile Build(ITile tile);
        void Build(ITileBlueprint blueprint);
    }
}