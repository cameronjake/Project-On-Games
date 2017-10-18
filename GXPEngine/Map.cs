using System.Xml;
using GXPEngine;
using static GXPEngine.Tileset;


public class Map{

        public Map(){
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Cameron\\RiderProjects\\Project-On-Games\\GXPEngine\\bin\\Debug\\gamemap.tmx");

            XmlNode node = doc.DocumentElement.SelectSingleNode("");

        }
        
        
        
    }
