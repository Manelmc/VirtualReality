using UnityEngine;
using System.Collections;


public class runBehaviour : StateMachineBehaviour {
    private GameObject me;
    private GameObject enemy;
    private float step = 0.1f;
    private Vector3 targetSize;
    PlayerBehaviour p;
     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameObject arCamera = GameObject.Find("ARCamera");
        sceneBehaviour scene = (sceneBehaviour)arCamera.GetComponent(typeof(sceneBehaviour));
        me = scene.getMe();
        enemy = scene.getEnemy();
        p = (PlayerBehaviour)me.GetComponent(typeof(PlayerBehaviour));
       
    }


	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // me.transform.position = Vector3.MoveTowards(me.transform.position, enemy.transform.position, step);
        me.transform.Translate(0.0f, 0.0f, step);
        if (p.isColliding()) {//System.Math.Abs(Vector3.Distance(me.transform.position, enemy.transform.position)) < 3) {
            Debug.Log("Here we Are!");
            animator.SetBool("Loop", false);
        }

    }
    
	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	 /*override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        me.transform.position = initialPosition;
        me.transform.rotation = initialRotation;
    }*/

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
