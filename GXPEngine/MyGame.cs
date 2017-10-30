using System;
using System.Collections;
using System.Drawing;
using TiledSharp;
// System contains a lot of default C# libraries 
using GXPEngine; // GXPEngine contains the engine

public class MyGame : Game{
    public CollisionManager collisionManager;
    public Player player;
    public Enemy enemy;
    public Enemy enemy2;
    public Array groundtiles;
    private Sprite ground;
    private TmxMap _map;
    private TmxTileset _myTileset;
    private TmxLayer _myLayer;
    private String _version;
    private bool delay = false;
    private HUD _hud;
    public static int[] groundY = new int[1920];
    
//    Rectangle mapView;
//    Map map;
    public MyGame() : base(1920, 1080, false) // Create a window that's 800x600 and NOT fullscreen
    {
        Background background = new Background();
        ground = new Sprite("colored_desert_underground.png");
//        AddChild(ground);
        getCollisions();
//		collisionManager = new CollisionManager();

//		background.collisionManager.Add(player);
//		background.collisionManager.GetCurrentCollisions(player);
        player = new Player("player_tilesheet.png", 8, 4, 33);
        AddChild(player);
        enemy = new Enemy("zombie_tilesheet.png", 9, 3, 24);
        AddChild(enemy);
        enemy2 = new Enemy("zombie_tilesheet.png", 9, 3, 24);
        AddChild(enemy2);
        enemy2.x = 60;
        Camera cameron  = new Camera(player);
        AddChild(cameron);
        _hud = new HUD(player);
        AddChild(_hud);
        
        
        _map = new TmxMap("gamemap.tmx");
        _version = _map.Version;
        _myTileset = _map.Tilesets[0];
        _myLayer = _map.Layers[3];
        
        draw();

    }
//    protected void Initialize() {
////        base.Initialize();
//        map = Content.Load<Map>("desert");
//    }
    public Character GetPlayer(){
        return player;
    }

    protected void Loadcontent(){
        
        
        
        
    }

    public void draw(){
        for (var i = 0; i < _map.Layers[3].Tiles.Count; i++)
        {
            int gid = _map.Layers[3].Tiles[i].Gid;

            // Empty tile, do nothing
            if (gid == 0) {

            }
            else {
                int tileFrame = gid -1;
                int row = tileFrame / (_myTileset.Tiles.Count / _myTileset.TileHeight);

                float x1 = (i % _map.Width) * _map.TileWidth;
                float y1 = (float)Math.Floor(i / (double)_map.Width) * _map.TileHeight;
                GroundSprite sprite = new GroundSprite(_myTileset.Tiles[tileFrame].Image.Source){
                    x = x1,
                    y = y1 
                };
                AddChild(sprite);
}
        }    }
    
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
        // Check if spacebar is pushed, then spawn bullet
        if (Input.GetKeyDown(Key.SPACE)){
            Bullet bullet = new Bullet(player);
            AddChild(bullet);
            player.SetFrame(32);
            
        }
        
        enemy.MoveToPlayer(50,200);
        enemy2.MoveToPlayer(60,600);
        
        while (Player.souls >= 2)
        {
            if (Input.GetKeyDown(Key.TAB))
            {
                switchCharacter();
            }
            else
            {
                break;
            }            
        }
        //check if tab key is pushed, then change player as long as souls is more than or equal to two
    }

    void switchCharacter(){

        if (!delay){
            player.changeplayer();
        }
        else return;
       
        delay = true;
        AddChild(new Timer(18000,changeDelay));

    }

    void changeDelay(){
        delay = false;
    }

    static void Main() // Main() is the first method that's called when the program is run
    {
        new MyGame().Start(); // Create a "MyGame" and start it
    }
}