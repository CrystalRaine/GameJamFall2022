using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWin : MonoBehaviour
{ 
    public GameObject boss;
    // Start is called before the first frame update

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public bool isFinished()
    {
        return boss.GetComponent<Boss>().phase == BossPhase.FINISHED;
    }

    private void Update()
    {
        if (isFinished())
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.parent.GetComponentInChildren<HealthBar>().won = true;
        }
    }
}
