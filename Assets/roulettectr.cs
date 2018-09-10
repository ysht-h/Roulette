using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roulettectr : MonoBehaviour
{

    float rotspd = 0.0f;

    enum SPINST
    {
        INIT,
        UP,
        WAIT,
        DOWN,
        RESULT,
    };

    SPINST spinst = SPINST.INIT;
    int timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spinst == SPINST.INIT)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.rotspd = -2.0f;
                spinst = SPINST.UP;
            }
        }
        else
        if (spinst == SPINST.UP)
        {
            this.rotspd *= 2.0f;
            if (this.rotspd < -32.0f)
            {
                this.rotspd = -32.0f;
                spinst = SPINST.WAIT;
            }
        }
        else
        if (spinst == SPINST.WAIT)
        {
            if (Input.GetMouseButtonDown(0))
            {
                spinst = SPINST.DOWN;
            }
        }
        else
        if (spinst == SPINST.DOWN)
        {
            this.rotspd *= 0.98f;
            if (this.rotspd >= -0.1f)
            {
                this.rotspd = 0.0f;
                spinst = SPINST.RESULT;
            }
        }
        else
        if(spinst == SPINST.RESULT)
        {
            timer++;
            if(timer >= 20)
            {
                spinst = SPINST.INIT;
            }
        }

        transform.Rotate(0.0f, 0.0f, this.rotspd);
	}
}
