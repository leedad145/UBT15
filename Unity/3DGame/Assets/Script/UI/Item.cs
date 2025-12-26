using UnityEngine;
using UnityEngine.UI;
public class Item
{
    Image _image;
    string _name;
    int _atk;
    int _def;
    int _hp;
    int _mp;
    int _spd;
    public Item()
    {
        _image = Resources.Load<Image>("");
    }
}
