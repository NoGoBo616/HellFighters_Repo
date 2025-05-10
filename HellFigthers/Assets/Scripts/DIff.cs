using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public int DificultBase;
    public void ChangeDificult(int nuevaDificultad)
    {
        DificultBase = nuevaDificultad;
    }

}
