using System.Runtime.Remoting.Activation;
using System.Security.Principal;
using GXPEngine;

    public class StartScreen : GameObject
    {
        private Sprite _startButton;
        private Sprite _logo;

        public StartScreen()
        {
            _startButton = new Sprite("Start.png");
            AddChild(_startButton);
            
            _logo = new Sprite("Logo.png");
            AddChild(_logo);

            _startButton.x = (game.width / 2);
            _startButton.y = (600);
            _startButton.SetOrigin(95, 40 );

            _logo.x = (game.width / 2);
            _logo.y = (200);
            _logo.SetOrigin(492, 124);
            
            


        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    startGame();
                    this.Destroy();
                    _logo.Destroy();
            }
            }
        }

        public void startGame()
        {
            Level level = new Level();
            game.AddChild(level);
            
        }
    }
