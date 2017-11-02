
using GXPEngine; // GXPEngine contains the engine

public class MyGame : Game
{
    private Level _level;

    public MyGame() : base(1920, 1080, false)
    {
        StartScreen startScreen = new StartScreen();
        AddChild(startScreen);
    }

    void Update()
    {
    }

    static void Main()
    {
        new MyGame().Start();
    }
}