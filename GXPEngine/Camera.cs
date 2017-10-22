using GXPEngine;


public class Camera : Sprite{
//    private float x;
//    private float y;
    private GameObject hGameObject;
    public Camera(GameObject hGameObject) : base("transparent.png"){
        this.hGameObject = hGameObject;
        SetOrigin(32,32);
        x = hGameObject.x;
        y = hGameObject.y;
    }

    void Update(){
        x = hGameObject.x;
        y = hGameObject.y;
    }
    
}