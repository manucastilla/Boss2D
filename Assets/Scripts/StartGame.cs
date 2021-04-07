using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }
    public void Startgame()
    {
        gm.points = 0;
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
