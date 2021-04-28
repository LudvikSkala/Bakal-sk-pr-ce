using UnityEngine;
using TMPro;

public class PickupCoin : MonoBehaviour
{
    //Pocet predmetu
    public float gems = 0;
    public float cherries = 0;
    
    //Promene pro UI zobrazeni predmetu
    public TextMeshProUGUI textGems;
    public TextMeshProUGUI textCherries;

    //Pri kontaktu s predmetem
    private void OnTriggerEnter2D(Collider2D pickUpItem) {

        Debug.Log("PickupTrigger");

        //Podminka pro drahokamy
        if(pickUpItem.transform.tag == "Gem"){
            gems++;

            //Prevede aktualni hodnotu do UI
            textGems.text = gems.ToString();

            //Znici objekt ve hre
            Destroy(pickUpItem.gameObject);
        } else {
                    
            //Podminka pro tresne
            if(pickUpItem.transform.tag == "Cherry"){
            cherries++;

            //Prevede aktualni hodnotu do UI
            textCherries.text = cherries.ToString();

            //Znici objekt ve hre
            Destroy(pickUpItem.gameObject);
            }
        }
    }
}
