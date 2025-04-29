using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals_Dificult : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public int Dificult;
  

    //Update is called once per frame
    void Update()
    {


        if (Dificult == 1)
        {
            portal1.gameObject.SetActive(true);
            portal2.gameObject.SetActive(false);
            portal3.gameObject.SetActive(false);
        }
        if (Dificult == 2)
        {
            portal1.gameObject.SetActive(false);
            portal2.gameObject.SetActive(true);
            portal3.gameObject.SetActive(true);
        }
        if (Dificult == 3)
        {
            portal1.gameObject.SetActive(true);
            portal2.gameObject.SetActive(true);
            portal3.gameObject.SetActive(true);
        }
        if (Dificult >= 4 || Dificult <= 0) 
        {
            portal1.gameObject.SetActive(false);
            portal2.gameObject.SetActive(false);
            portal3.gameObject.SetActive(false);
        }
    }
    public void ChangeDificult(int nuevaDificultad)
    {
        Dificult = nuevaDificultad;
    }


}
