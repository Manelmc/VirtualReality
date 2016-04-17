using UnityEngine;
using System.Collections;

public class attack1Zombie : StateMachineBehaviour {
    ParticleSystem attack;

     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameObject arCamera = GameObject.Find("ARCamera");
        sceneBehaviour scene = (sceneBehaviour)arCamera.GetComponent(typeof(sceneBehaviour));
        attack = GameObject.Find("GreenCore").GetComponent<ParticleSystem>();
        attack.transform.position = scene.getEnemy().transform.position;
        attack.Emit(120);
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (!attack.isPlaying)
        {
            animator.SetBool("Loop", false);
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
