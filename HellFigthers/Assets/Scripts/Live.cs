using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live : MonoBehaviour
{
    [SerializeField] Image player_Live;
    public float liveMax = 1f;
    public float liveCur;
    // Start is called before the first frame update
    void Start()
    {
        liveCur = liveMax;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStatus();
    }

    public void PlayerStatus()
    {
        player_Live.fillAmount = liveCur;
        if (liveCur <= 0 )
        {
            liveCur = 0;
            gameObject.SetActive( false );
        }
    }

    public void Damage(float damage)
    {
        liveCur -= damage;
    }
}
