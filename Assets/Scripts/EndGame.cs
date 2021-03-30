using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Endgame()
    {
        SceneManager.LoadScene("StartMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
