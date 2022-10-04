using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuitButton : MonoBehaviour
{

    public void QuitOnClick(){
        SceneManager.LoadScene(0);
    }
}
