using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    Scene ChangingScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (SceneManager.GetActiveScene().name == "Tutorial Vf2")
            {
                SceneManager.LoadScene("LVL1");
            }
            else if (SceneManager.GetActiveScene().name == "LVL1")
            {
                SceneManager.LoadScene("LVL2");
            }
            else if (SceneManager.GetActiveScene().name == "LVL2")
            {
                SceneManager.LoadScene("LVL 3");
            }
            else if (SceneManager.GetActiveScene().name == "LVL 3")
            {
                SceneManager.LoadScene("LVL 4");
            }
            
        }
    }
}
