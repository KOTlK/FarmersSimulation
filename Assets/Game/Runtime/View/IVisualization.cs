namespace Game.Runtime.View
{
    public interface IVisualization<in TView>
    {
        void Visualize(TView view);
    }

    public interface IVisualization<in TFirst, in TSecond>
    {
        void Visualize(TFirst first);
        void Visualize(TSecond second);
    }
    
    public interface IVisualization<in TFirst, in TSecond, in TThird>
    {
        void Visualize(TFirst first);
        void Visualize(TSecond second);
        void Visualize(TThird third);
    }
    
    public interface IVisualization<in TFirst, in TSecond, in TThird, in TFourth>
    {
        void Visualize(TFirst first);
        void Visualize(TSecond second);
        void Visualize(TThird third);
        void Visualize(TFourth fourth);
    }
    
    public interface IVisualization<in TFirst, in TSecond, in TThird, in TFourth, in TFifth>
    {
        void Visualize(TFirst first);
        void Visualize(TSecond second);
        void Visualize(TThird third);
        void Visualize(TFourth fourth);
        void Visualize(TFifth fifth);
    }
}