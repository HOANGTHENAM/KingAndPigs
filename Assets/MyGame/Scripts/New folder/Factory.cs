using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    //Dinh nghia class base cho moi doi tuong
    public abstract class GameObjectBase
    {
        public abstract void Spawn (Vector3 position, Quaternion rotation);
    }
     
    //Dinh nghia class Factory
    public static class GameObjectFactory
    {
        public static GameObjectBase CreateGameObject (string objectType)
        {
            GameObjectBase gameObject = null;
            switch (objectType)
            {
                case "Enemy":
                    gameObject = new Enemy();
                    break;
                case "PowerUp":
                    gameObject = new PowerUp();
                    break;
                case "Item":
                    gameObject = new Item();
                    break;
                default:
                    Debug.LogError("Unknown object type: " + objectType);
                    break;
            }
            return gameObject;
        }

    }
    public class Enemy : GameObjectBase
    {
        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            
        }
        //Doing sth
    }
    public class PowerUp : GameObjectBase
    {
        public override void Spawn(Vector3 position, Quaternion rotation)
        {

        }
        //Doing sth
    }
    public class Item : GameObjectBase
    {
        public override void Spawn(Vector3 position, Quaternion rotation)
        {

        }
        //Doing sth
    }

}
