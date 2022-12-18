namespace Game.Runtime.TileMap.Tiles
{
    public class TileBuilder : ITileBuilder
    {
        private readonly ITileMap _tileMap;

        public TileBuilder(ITileMap tileMap)
        {
            _tileMap = tileMap;
        }

        public ITile Build(ITile tile)
        {
            _tileMap.Replace(tile.Position, tile);
            return tile;
        }

        public void Build(ITileBlueprint blueprint)
        {
            foreach (var tile in blueprint)
            {
                _tileMap.Replace(tile.Position, tile);
            }
        }
    }
}