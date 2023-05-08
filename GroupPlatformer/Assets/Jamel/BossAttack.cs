using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : StateMachineBehaviour
{
    BossBehavior bossBehavior;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehavior = animator.GetComponent<bossBehavior>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateinfo stateInfo, int layerIndex)
    {
        bossBehavior.ProjectileShoot();
    }
}
