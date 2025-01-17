using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Singleton<Observer>
{
    Dictionary<string, List<Action<object>>> listAction = new Dictionary<string, List<Action<object>>>();
    public Observer AddListener(string key, Action<object> callback)
    {
        if (!listAction.ContainsKey(key))
            listAction.Add(key, new List<Action<object>>());
        listAction[key].Add(callback);
        return this;
    }
    
    public Observer RemoveListener(string key, Action<object> callback)
    {
        if (!listAction.ContainsKey(key))
            return this;
        if (!listAction[key].Contains(callback))
            return this;
        listAction[key].Remove(callback);
        return this;
    }
    public Observer Notify(string key, object data)
    {
        if(!listAction.ContainsKey(key))
            return this;
        foreach(var action in listAction[key])
        {
            action?.Invoke(data);
        }
        return this;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField] Text HP;
    private void Start()
    {
        Observer.Instance.AddListener("HP", ChangeUI);
    }
    public void ChangeUI(object HP)
    {
        this.HP.text = ((float)HP).ToString();
    }
    private void OnDestroy()
    {
        Observer.Instance.RemoveListener("HP", ChangeUI);
    }
}
*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _HP;
    public void GetHit(float dmg)
    {
        this._HP -= dmg;
        if (this._HP <= 0)
            this._HP = 0;
        Observer.Instance.Notify("HP", _HP);
    }

}
*/
