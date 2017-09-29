using GXPEngine;

public class Bullet : AnimationSprite
{
    private Player player;
    private int timeOutBetweenFrames;
    private int counter;
    private int direction = -1;

    public Bullet(Player player) : base("bullet.png", 2, 1)
    {
        this.player = player;
        this.x = player.x;
        this.y = player.y - 60;
        direction = player.getDirection();

        this.counter = 0;
        this.timeOutBetweenFrames = 4;
    }

    public void Update()
    {
        counter = counter + 1;
        if (counter == timeOutBetweenFrames)
        {
            counter = counter - timeOutBetweenFrames;
            NextFrame();
        }
        Move(direction * 8, 0);

        if (x > Game.main.width || x < 0 || y > Game.main.height || y < 0)
        {
            Destroy();
        }
    }
}