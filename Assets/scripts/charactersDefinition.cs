using UnityEngine;
using System.Collections;

public class charactersDefinition : MonoBehaviour {
    private static float lifePointsMetal = 1000;
    private static float attackCoefMetal = 1.2f;
    private static float defenseCoefMetal = 0.8f;
    private static float speedMetal = 300;
    private static float attack1DamageMetal = 200;
    private static float attack2DamageMetal = 200;
    private static float attack3DamageMetal = 200;

    private static float lifePointsWood = 1000;
    private static float attackCoefWood = 1.2f;
    private static float defenseCoefWood = 0.8f;
    private static float speedWood = 300;
    private static float attack1DamageWood = 2000;
    private static float attack2DamageWood = 200;
    private static float attack3DamageWood = 200;

    private static float lifePointsFire = 1000;
    private static float attackCoefFire = 1.2f;
    private static float defenseCoefFire = 0.8f;
    private static float speedFire = 300;
    private static float attack1DamageFire = 200;
    private static float attack2DamageFire = 200;
    private static float attack3DamageFire = 200;

    private static float lifePointsWater = 1000;
    private static float attackCoefWater = 1.2f;
    private static float defenseCoefWater = 0.8f;
    private static float speedWater = 300;
    private static float attack1DamageWater = 200;
    private static float attack2DamageWater = 200;
    private static float attack3DamageWater = 200;

    private static float lifePointsEarth = 1000;
    private static float attackCoefEarth = 1.2f;
    private static float defenseCoefEarth = 0.8f;
    private static float speedEarth = 300;
    private static float attack1DamageEarth = 200;
    private static float attack2DamageEarth = 200;
    private static float attack3DamageEarth = 200;

    private static float lifePointsLightning = 1000;
    private static float attackCoefLightning = 1.2f;
    private static float defenseCoefLightning = 0.8f;
    private static float speedLightning = 300;
    private static float attack1DamageLightning = 200;
    private static float attack2DamageLightning = 200;
    private static float attack3DamageLightning = 200;

    private static float lifePointsWind = 1000;
    private static float attackCoefWind = 1.2f;
    private static float defenseCoefWind = 0.8f;
    private static float speedWind = 300;
    private static float attack1DamageWind = 200;
    private static float attack2DamageWind = 200;
    private static float attack3DamageWind = 200;

    private ArrayList metalAttributes = new ArrayList();
    private ArrayList woodAttributes = new ArrayList();
    private ArrayList windAttributes = new ArrayList();
    private ArrayList waterAttributes = new ArrayList();
    private ArrayList fireAttributes = new ArrayList();
    private ArrayList lightningAttributes = new ArrayList();
    private ArrayList earthAttributes = new ArrayList();

    // Use this for initialization
    void Start () {
        metalAttributes.Add(lifePointsMetal);
        metalAttributes.Add(attackCoefMetal);
        metalAttributes.Add(defenseCoefMetal);
        metalAttributes.Add(speedMetal);
        metalAttributes.Add(attack1DamageMetal);
        metalAttributes.Add(attack2DamageMetal);
        metalAttributes.Add(attack3DamageMetal);

        woodAttributes.Add(lifePointsWood);
        woodAttributes.Add(attackCoefWood);
        woodAttributes.Add(defenseCoefWood);
        woodAttributes.Add(speedWood);
        woodAttributes.Add(attack1DamageWood);
        woodAttributes.Add(attack2DamageWood);
        woodAttributes.Add(attack3DamageWood);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public ArrayList getAttributes(string name)
    {
        switch (name)
        {
            case "pokemon-snorlax_00414346jpg":
                return woodAttributes;
            case "145Zapdos_Dreamjg":
                return metalAttributes;

            case "water_bw":
                return waterAttributes;
            case "fire_bw":
                return fireAttributes;
            case "wind_bw":
                return windAttributes;
            case "earth_bw":
                return earthAttributes;
            case "wood_bw":
                return woodAttributes;
            case "metal_bw":
                return metalAttributes;
            case "lightning_bw":
                return lightningAttributes;

            default:
                return new ArrayList();
        }
    }

    public float getWeakness(string attacker, string attacked)
    {
        switch (attacked)
        {
            case "water_bw":
                if(attacked == "fire_bw")
                {
                    
                }else if(attacked == "lightning_bw")
                {

                }
                return defenseCoefWater;
            case "fire_bw":
                if (attacked == "fire_bw")
                {

                }
                else if (attacked == "lightning_bw")
                {

                }
                return defenseCoefFire;
            case "wind_bw":
                if (attacked == "fire_bw")
                {

                }
                else if (attacked == "lightning_bw")
                {

                }
                return defenseCoefWind;
            case "earth_bw":
                if (attacked == "fire_bw")
                {

                }
                else if (attacked == "lightning_bw")
                {

                }
                return defenseCoefEarth;
            case "wood_bw":
                if (attacked == "fire_bw")
                {

                }
                else if (attacked == "lightning_bw")
                {

                }
                return defenseCoefWood;
            case "metal_bw":
                if (attacked == "fire_bw")
                {

                }
                else if (attacked == "lightning_bw")
                {

                }
                return defenseCoefMetal;
            case "lightning_bw":
                if (attacked == "fire_bw")
                {

                }
                else if (attacked == "lightning_bw")
                {

                }
                return defenseCoefLightning;
            default:
                return 1f;
        }
    }
}
