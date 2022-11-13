using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public string itemName;
    public enum Type
    {
        POTION,
        HERB,
        GEM,
        REMAINS,
        DEFAULT
    }

    public Type type = Type.DEFAULT;

    public List<Item> compatibleItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
