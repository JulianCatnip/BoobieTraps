using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public string itemName;
    public enum Type
    {
        POTION,
        NATURE_CATALYST,
        GEM,
        REMAINS,
        DEFAULT
    }

    public Type type = Type.DEFAULT;
    public string itemDescription;

    public List<ItemObject> compatibleItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
