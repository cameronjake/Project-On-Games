using System;
using System.Collections;
// System contains a lot of default C# libraries 
using GXPEngine; // GXPEngine contains the engine

public class MyGame : Game{
    public CollisionManager collisionManager;
    public Player player;
    public Enemy enemy;
    public Array groundtiles;

    public MyGame() : base(1280, 720, false) // Create a window that's 800x600 and NOT fullscreen
    {
        Background background = new Background();
//		collisionManager = new CollisionManager();

//		background.collisionManager.Add(player);
//		background.collisionManager.GetCurrentCollisions(player);
        player = new Player("player_tilesheet.png", 9, 3, 24);
        AddChild(player);
        enemy = new Enemy("zombie_tilesheet.png", 9, 3, 24);
        AddChild(enemy);
//		AddChild(new Bullet(player));
    }

    public Character GetPlayer(){
        return player;
    }


    void Update(){
        // Empty
        if (Input.GetKey(Key.SPACE)){
            Bullet bullet = new Bullet(player);
            AddChild(bullet);
        }
        if (Input.GetKeyDown(Key.TAB)){
            player.changeplayer();
        }
    }

    static void Main() // Main() is the first method that's called when the program is run
    {
        new MyGame().Start(); // Create a "MyGame" and start it
    }
}