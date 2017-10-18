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
    public Array groundtiles;
    private Sprite ground;
    private TmxMap _map;
    private TmxTileset _myTileset;
    private TmxLayer _myLayer;
    private String _version;
    private bool delay = false;
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
        Camera cameron  = new Camera(player);
        AddChild(cameron);
        
        
//        _map = new TmxMap("gamemap.tmx");
//        _version = _map.Version;
//        _myTileset = _map.Tilesets["myTileset"];
//        _myLayer = _map.Layers[3];
        
        

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

    public void draw(){
        for (var i = 0; i < _map.Layers[2].Tiles.Count; i++)
        {
            int gid = _map.Layers[2].Tiles[i].Gid;

            // Empty tile, do nothing
            if (gid == 0) {

            }
            else {
                int tileFrame = gid - 1;
                int row = tileFrame / (_myTileset.Tiles.Count / _myTileset.TileHeight);

                float x = (i % _map.Width) * _map.TileWidth;
                float y = (float)Math.Floor(i / (double)_map.Width) * _map.TileHeight;

                Rectangle tilesetRec = new Rectangle(_myTileset.TileWidth * tileFrame, _myTileset.TileHeight * row, 32, 32);
//                Sprite sprite = new Sprite(tileFrame);
//                spriteBatch.Draw(_tileset, new Rectangle((int)x, (int)y, 32, 32), tilesetRec, Color.White);
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
        }
        if (Input.GetKeyDown(Key.TAB)){
            switchCharacter();
        }

        //check if tab key is pushed, then change playerd
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