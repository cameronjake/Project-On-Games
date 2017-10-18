using System;
using System.Collections;
using System.Drawing;
//using TiledSharp;
// System contains a lot of default C# libraries 
using GXPEngine; // GXPEngine contains the engine

public class MyGame : Game{
    public CollisionManager collisionManager;
    public Player player;
    public Enemy enemy;
    public Array groundtiles;
    private Sprite ground;
    public static int[] groundY = new int[1920];
//    Rectangle mapView;
//    Map map;
    public MyGame() : base(1920, 1080, true) // Create a window that's 800x600 and NOT fullscreen
    {
        Background background = new Background();
        ground = new Sprite("colored_desert_underground.png");
//        AddChild(ground);
        getCollisions();
//		collisionManager = new CollisionManager();

//		background.collisionManager.Add(player);
//		background.collisionManager.GetCurrentCollisions(player);
        player = new Player("player_tilesheet.png", 9, 3, 24);
        AddChild(player);
        enemy = new Enemy("zombie_tilesheet.png", 9, 3, 24);
        AddChild(enemy);
        
//		AddChild(new Bullet(player));
        
    }
//    protected override void Initialize() {
////        base.Initialize();
//        map = Content.Load<Map>("desert");
//    }
    public Character GetPlayer(){
        return player;
    }

    protected void Loadcontent(){
        
        
        
        
    }
    
    public void getCollisions(){
        for (int i = 0; i < Game.main.width; i++){
            for (int j = 630; j < Game.main.height; j++){
                Color c = ground.texture.bitmap.GetPixel((int) Utils.Clamp(i, 0, main.width), j);
                
                if (c.R == 255 && c.G == 255 && c.B == 255){
                    groundY[i] =  j;
                    break;
                }
            }
        }
    }

    void Update(){
        // Empty
        if (Input.GetKeyDown(Key.SPACE)){
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