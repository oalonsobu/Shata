using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using Common;

namespace UI
{
    public class InGameMenu : MonoBehaviour
    {
        
        [SerializeField] GameObject inGameMenu;
        [SerializeField] AudioClip clickAudio;
        
        AudioHelper audioHelper;
        
        private Scene currentScene;
        
        void Awake() {
            currentScene = SceneManager.GetActiveScene();
        }
        
        // Start is called before the first frame update
        void Start() 
        {
            inGameMenu.SetActive(false);
            Time.timeScale = 1;
            audioHelper = GetComponent<AudioHelper>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

        public void PauseGame()
        {
            audioHelper.PlaySound(clickAudio);
            if (!inGameMenu.activeSelf)
            {
                inGameMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                inGameMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
        
        public void Resume() 
        {
            PauseGame();
        }

        public void Restart() 
        {
            audioHelper.PlaySound(clickAudio);
            SceneManager.LoadScene(currentScene.name);
        }

        public void ExitToMainMenu() 
        {
            audioHelper.PlaySound(clickAudio);
            SceneManager.LoadScene("MainMenu");
        }
    }
}

