using UnityEngine;

public class MiniMenuBehScript : MonoBehaviour
{
    //The role of this script is to place mini "new game" menu object next to the board
    [SerializeField] RectTransform miniMenu;
    [SerializeField] Vector3 oWictory, xWictory;
    private void OnEnable()
    {
        EventManagerScript.victory += PlaceMenuWhenWin;
        EventManagerScript.draw += MenuSetOnDraw;
    }
    private void OnDisable()
    {
        EventManagerScript.victory -= PlaceMenuWhenWin;
        EventManagerScript.draw -= MenuSetOnDraw;
    }
    private void PlaceMenuWhenWin(bool winner)
    {
        if (winner)
        {
            miniMenu.anchoredPosition = oWictory;

        }
        else
        {
            miniMenu.anchoredPosition = xWictory;
        }
    }
    private void MenuSetOnDraw()
    {
        miniMenu.anchoredPosition = xWictory;
    }

}
