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
                print("�� ����");
                key.hasKey = false;
            }
            else
            {
                print("�� ����");
            }
        }
        else
        {
            print("��");
        }
    }

    private void KeyCheck()
    {
        if (_key.hasKey)
        {
            print("�� ����");
        }
        else
        {
            print("�� ����");
        }
    }
}
