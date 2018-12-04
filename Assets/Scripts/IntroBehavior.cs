using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehavior : StateMachineBehaviour {

    private float timer;
    public float minTime;
    public float maxTime;
	private int rand;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        timer = Random.Range(minTime, maxTime);

		


	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (timer <= 0)
        {
			 timer = Random.Range(minTime, maxTime);
            rand = Random.Range(0, 4);

            if (rand == 0)
            {
                animator.SetTrigger("Jump");
            }
            else if (rand == 4)
            {
                animator.SetTrigger("Iddle");

            }
            else if (rand == 2)
            {
                animator.SetTrigger("Fire");

            }
            else
            {
                animator.SetTrigger("Laugh");

            }

           
		}
        else
        {
            timer -= Time.deltaTime;
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
