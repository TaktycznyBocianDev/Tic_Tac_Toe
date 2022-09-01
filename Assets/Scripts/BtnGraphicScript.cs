using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGraphicScript : MonoBehaviour
{
    //My role is to place image on button, depends on who plays now :)
    [SerializeField] Sprite x, o;
    [SerializeField] Image btnImage;
    [SerializeField] PlayerScript playerScript;
    //If now is "true" valiable - O, if false - X;
    public void ChangeButtonGraphic()
    {
        if (playerScript.GetWhoIsNow())
        {
            btnImage.sprite = o;
        }
        else if (!playerScript.GetWhoIsNow())
        {
            btnImage.sprite = x;
        }

    }

}
