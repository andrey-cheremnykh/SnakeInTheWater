using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreationTest : MonoBehaviour
{
    public void CheckPresence()
    {
        print(gameObject.name + " is here");
    }
    private void OnDestroy()
    {
        print(gameObject.name + " is gone");
    }
}
