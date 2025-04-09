using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AniManager : MonoBehaviour
{
    private Animator EnemyAnim;
    public Ennemy Stats;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void Animate()
    {
        
        if (Stats.maldicion == 0 && Stats.vida == 0)
        {
            EnemyAnim.SetTrigger("Die");
        }
    }
}
