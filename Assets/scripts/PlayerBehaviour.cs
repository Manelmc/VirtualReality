using UnityEngine;
using System.Collections;
using System;

public class PlayerBehaviour : MonoBehaviour {
    private GameObject enemy;
    private Animator anim;
    private sceneBehaviour scene;
    charactersDefinition ch;
    private bool collides = false;
    private bool attacking = false;

    private float lifePoints = 1000;
    private float attackCoef = 1.2f;
    private float defenseCoef = 0.8f;
    private float speed = 300;
    private float attack1Damage = 200;
    private float attack2Damage = 200;
    private float attack3Damage = 200;

    // Use this for initialization
    void Start () {
        GameObject arCamera = GameObject.Find("ARCamera");
        scene = (sceneBehaviour)arCamera.GetComponent(typeof(sceneBehaviour));
        enemy = gameObject;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(enemy.transform.position);
        if(lifePoints <= 0)
        {
            scene.onPlayerDead(gameObject.name);
            //Debug.Log("I'm dead: " + gameObject.name);
            lifePoints = float.MaxValue;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!: " + gameObject.name + "against: " + other.transform.name);
        collides = true;
    }

    void OnTriggerExit(Collider other)
    {
        print("No longer in contact with " + other.transform.name);
        collides = false;
    }

    public bool isColliding()
    {
        return collides;
    }

    public void attackisEnded()
    {
        attacking = false;
        scene.onAttackEnded(attack1Damage, gameObject.name); //TODO: proper attack points
    }

    public bool isAttacking()
    {
        return attacking;
    }

    public void setEnemy(GameObject enemyPointer)
    {
        enemy = enemyPointer;
        GameObject arCamera = GameObject.Find("ARCamera");
        ch = (charactersDefinition)arCamera.GetComponent(typeof(charactersDefinition));
        ArrayList attributes = ch.getAttributes(gameObject.name);
        lifePoints = (float)attributes[0];
        attackCoef = (float)attributes[1];
        defenseCoef = (float)attributes[2];
        speed = (float)attributes[3];
        attack1Damage = (float)attributes[4];
        attack2Damage = (float)attributes[5];
        attack3Damage = (float)attributes[6];

        Debug.Log(lifePoints + "," + attackCoef + "," + defenseCoef + "," + speed
    + "," + attack1Damage);
    }

    public void dead()
    {
        anim.Play("Death", -1, 0f);
    }
    public void attack1()
    {
        anim.Play("Attack1", -1, 0f);
        attacking = true;
        
    }
    public void attack2()
    {
        anim.Play("Attack2", -1, 0f);
        attacking = true;
    }
    public void attack3()
    {
        anim.Play("Attack3", -1, 0f);
        attacking = true;

    }
    public void hit(float damagePoints, String enemyName)
    {
        anim.Play("Hit", -1, 0f);
        float damage = damagePoints * ((defenseCoef + ch.getWeakness(enemyName, gameObject.name)) / 2f);
        lifePoints = lifePoints - damage;
        Debug.Log("Auch!! " + gameObject.name + " received: " + damage + " points, LifePoints: " + lifePoints);

    }
}
