using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviourScritp : MonoBehaviour
{
    [SerializeField] int x, y;
    [SerializeField] PlayerScript playerScript;

    private void OnEnable()
    {
        EventManagerScript.victory += NoWayToPress;
        EventManagerScript.draw += NoWayToPress;

    }
    private void OnDisable()
    {
        EventManagerScript.victory -= NoWayToPress;
        EventManagerScript.draw -= NoWayToPress;
    }
    public void WhenPressed()
    {
        Test();
        EventManagerScript.PlayerPressButtonFunction(x, y, playerScript.GetWhoIsNow());
        Destroy(GetComponent<Button>());

    }
    public void Test()
    {
        Debug.Log(x + " " + y + " " + playerScript.GetWhoIsNow());
    }
    private void NoWayToPress(bool tmp)
    {
        Destroy(GetComponent<Button>());
    }
    private void NoWayToPress()
    {
        Destroy(GetComponent<Button>());
    }



}
