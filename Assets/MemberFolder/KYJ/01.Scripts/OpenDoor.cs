using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Key _key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collision.gameObject.GetComponent<Key>();

        if (key != null)
        {
            if (key.hasKey)
            {
                print("¹® ¿­¸²");
                key.hasKey = false;
            }
            else
            {
                print("¹® ´ÝÈû");
            }
        }
        else
        {
            print("³Î");
        }
    }

    private void KeyCheck()
    {
        if (_key.hasKey)
        {
            print("¹® ¿­¸²");
        }
        else
        {
            print("¹® ´ÝÈû");
        }
    }
}
