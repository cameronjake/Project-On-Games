using GXPEngine;

    public class HUD : GameObject
    {
        private Player _player;
        private TextBoard _textBoardsouls;
        
        public HUD(Player player)
        {
            _player = player;
            
            _textBoardsouls = new TextBoard(128, 32);
            AddChild(_textBoardsouls);
            _textBoardsouls.x += 128 + 4;
        }

        public void Update()
        {
            _textBoardsouls.SetText("Souls" + _player.GetSouls());
        }
    }
    
    
