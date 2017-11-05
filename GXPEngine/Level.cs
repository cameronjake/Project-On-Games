using System;
using System.Collections;
using System.Drawing;
using TiledSharp;
// System contains a lot of default C# libraries 
using GXPEngine; // GXPEngine contains the engine

    public class Level : GameObject
    {
        public CollisionManager collisionManager;
        public static Player Player;
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
        
        
            public Level() 
    {
        
        
        Background background = new Background();
       
        AddChild(background);
        ground = new Sprite("colored_desert_underground.png");
//        AddChild(ground);
        getCollisions();
//		collisionManager = new CollisionManager();

//		background.collisionManager.Add(Player);
//		background.collisionManager.GetCurrentCollisions(Player);
        Player = new Player("player_tilesheet.png", 8, 4, 33);
        Player.x = 960;
        Player.y = 100;
        AddChild(Player);
        enemy = new Enemy("ghost-spritesheet.png", 9, 1, 9);
        enemy.y = 10;
        AddChild(enemy);
        enemy2 = new Enemy("ghost-spritesheet.png", 9, 1, 9);
        AddChild(enemy2);
        enemy2.x = 600;
        enemy2.y = 10;
        Camera cameron  = new Camera(Player);
        AddChild(cameron);
        _hud = new HUD(Player);
        AddChild(_hud);
//        addStars();

        
        
        _map = new TmxMap("mirror.tmx");
        _version = _map.Version;
        _myTileset = _map.Tilesets[0];
        _myLayer = _map.Layers[0];
        
        draw();

    }
//    protected void Initialize() {
////        base.Initialize();
//        map = Content.Load<Map>("desert");
//    }
    public Character GetPlayer(){
        return Player;
    }

    protected void Loadcontent(){
        
        
        
        
    }

    public void addStars(){
//        Random rnd = new Random();
        for (int i = 0; i < 1000; i++){
            

            Star star = new Star("star.png");
            
           
            AddChild(star);
        }
    }
    
    public void draw(){
        for (var i = 0; i < _map.Layers[0].Tiles.Count; i++)
        {
            int gid = _map.Layers[0].Tiles[i].Gid;

            // Empty tile, do nothing
            if (gid == 0) {

            }
            else {
                int tileFrame = gid -1;
                if (_myTileset.TileHeight != 0)
                {
                    if (_myTileset.Tiles.Count / _myTileset.TileHeight != 0)
                    {
                        int row = tileFrame / (_myTileset.Tiles.Count / _myTileset.TileHeight);
                    }
                }
                float x1 = (i % _map.Width) * _map.TileWidth;
                float y1 = (float)Math.Floor(i / (double)_map.Width) * _map.TileHeight;
                GroundSprite sprite = new GroundSprite(_myTileset.Tiles[tileFrame].Image.Source, x1, y1);
                AddChild(sprite);
}
        }    }
    
    public void getCollisions(){
        for (int i = 0; i < Game.main.width; i++){
            for (int j = 630; j < Game.main.height; j++){
                Color c = ground.texture.bitmap.GetPixel((int) Utils.Clamp(i, 0, Game.main.width), j);
                
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
            Bullet bullet = new Bullet(Player);
            AddChild(bullet);
            Player.SetFrame(32);
            
        }
        
        enemy.MoveToPlayer(50,200);
        enemy2.MoveToPlayer(60,600);
        
//        while (Player.souls >= 2)
//        {
            if (Input.GetKeyDown(Key.TAB))
            {
                switchCharacter();
            }
//            else
//            {
//                break;
//            }            
//        }
        //check if tab key is pushed, then change Player as long as souls is more than or equal to two
    }

    void switchCharacter(){

        if (!delay){
            Player.changeplayer();
        }
        else return;
       
        delay = true;
        AddChild(new Timer(18000,changeDelay));

    }

    public Player getPlayer(){
        return Player;
    }
    
    void changeDelay(){
        delay = false;
    }
    }
