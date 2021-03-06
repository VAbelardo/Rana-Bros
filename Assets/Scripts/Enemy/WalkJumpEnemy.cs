using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkJumpEnemy : Enemy
{

    private void FixedUpdate()
    {
        if (estaMuerto) return;
        if (!DetectarPiso())
        {
            necesitaBrincar = true;
        }

        if (DetectarPared())
        {
            necesitaBrincar = true;
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (estaMuerto) return;
        Walk();
        if (necesitaBrincar)
        {
            Jump();
            necesitaBrincar = false;
        }
    }
}
