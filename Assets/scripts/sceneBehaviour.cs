using UnityEngine;
using System.Collections;
using System;

public class sceneBehaviour: MonoBehaviour {
    private int numberOfTracksFound = 4; //initial value cuz -4
    private GameObject player1;
    private GameObject player2;
    private bool player1Assigned = false;
    private Vector3 p1InitialPosition;
    private Quaternion p1InitialRotation;
    private bool player2Assigned = false;
    private bool p1Attacksp2 = false;
    private PlayerBehaviour p1;
    private PlayerBehaviour p2;

    //on start
    void Start()
    {
        initParticleSystems();
    }

    //on Update
    void Update()
    {   
        if (Input.GetKeyDown("1"))
        {
            attack(1);
        }
        else if (Input.GetKeyDown("2"))
        {
            attack(2);
        }
        else if (Input.GetKeyDown("3"))
        {
            attack(3);
        }
    }

    //when attack button pressed
    private void attack(int numberAttack)
    {
        PlayerBehaviour aux;
        if (p1Attacksp2)
        {
            p1Attacksp2 = false;
            aux = p2;   
        }
        else
        {
            p1Attacksp2 = true;
            aux = p1;
        }
        switch (numberAttack) {
            case 1:
                aux.attack1();
                break;
            case 2:
                aux.attack2();
                break;
            default:
                aux.attack3();
                break;
        }
    }

    //on Initialize
    private void init()
    {
        p1 = (PlayerBehaviour)player1.GetComponent(typeof(PlayerBehaviour));
        p2 = (PlayerBehaviour)player2.GetComponent(typeof(PlayerBehaviour));

        p1.setEnemy(player2);
        p2.setEnemy(player1);
    }

    //On tracking Found
    public void onTrackingFound(string name)
    {
        ++numberOfTracksFound;
        Debug.Log("HELLO: " + numberOfTracksFound + " NAme: " + name);
        switch (numberOfTracksFound)
        {
            case 1:
                if (!player1Assigned)
                {
                    player1 = GameObject.Find(name);
                    Debug.Log("NAme: " + player1.name);
                    player1Assigned = true;
                }
                break;

            case 2:
                if (!player2Assigned)
                {
                    player2 = GameObject.Find(name);
                    Debug.Log("NAme: " + player2.name);
                    player2Assigned = true;
                    init();
                }
                else { stopGame(); }
                break;

            default:
                break;
        }
    }

    //
    private void stopGame()
    {
       
    }

    //on Player Dead
    public void onPlayerDead(string name)
    {
        if(name == player1.name)
        {
            p1.dead();
        }else if(name == player2.name)
        {
            p2.dead();
        }
    }

    //on Tracking Lost
    public void onTrackingLost(string name)
    {
        --numberOfTracksFound;
        /*if(player1.name == name)
        {

        }else if(player2.name == name)
        {
            
        }*/
    }

    //returns the attacked in this turn
    public GameObject getEnemy()
    {
        if (p1Attacksp2) return player2;
        else return player1;
    }

    //returns the attacker in this turn
    public GameObject getMe()
    {
        GameObject aux;
        if (p1Attacksp2) aux = player1;
        else aux = player2;
        p1InitialPosition = aux.transform.position;
        p1InitialRotation = aux.transform.rotation;
        return aux;
    }

    //return the initial position of the attacker in this turn
    public Vector3 getInitialPosition()
    {
        return p1InitialPosition;
    }

    //return the initial rotation of the attacker in this turn
    public Quaternion getInitialRotation()
    {
        return p1InitialRotation;
    }

    //Initialize the particle systems
    public void initParticleSystems()
    {
        //ParticleSystem core = GameObject.Find("Eternal Light").GetComponent<ParticleSystem>();
        //core.Stop();
    }

    //on Attack Ended
    public void onAttackEnded(float damagePoints, String attacker)
    {
        if(attacker == player1.name)
        {
            p2.hit(damagePoints, attacker);
        }else if(attacker == player2.name)
        {
            p1.hit(damagePoints, attacker);
        }
    }
    
}
