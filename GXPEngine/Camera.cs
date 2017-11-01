using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GXPEngine;


public class Camera : Sprite{
//    private float x;
//    private float y;
    
    public float Xv;
    private float xv;
    private int Movespeed = 5;
    readonly float gravity = 0.98f;
    private float Yv;
    private float yv;
    
    private GameObject hGameObject;
    public Camera(GameObject hGameObject) : base("transparent.png"){
        this.hGameObject = hGameObject;
        SetOrigin(32,32);
        x = hGameObject.x;
        y = hGameObject.y;
    }

    public void udate(){
        x = hGameObject.x;
        y = hGameObject.y;
       
    }
    
    
    
}