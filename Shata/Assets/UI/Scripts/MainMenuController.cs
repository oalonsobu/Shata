using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

namespace UI
{
    public class MainMenuController : MonoBehaviour {

        [SerializeField] GameObject creditsMenu;
        [SerializeField] GameObject mainMenu;
        [SerializeField] AudioClip clickAudio;

        AudioHelper audioHelper;
        
        void Start() 
        {
            audioHelper = GetComponent<AudioHelper>();
            mainMenu.SetActive(true);
            creditsMenu.SetActive(false);
        }

        public void NewGame() 
        {
            audioHelper.PlaySound(clickAudio);
            SceneManager.LoadScene("Level1");
        }

        public void ShowCredits() 
        {
            audioHelper.PlaySound(clickAudio);
            creditsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        public void ExitGame() 
        {
            audioHelper.PlaySound(clickAudio);
            Application.Quit();
        }
        
        public void GoBack() 
        {
            audioHelper.PlaySound(clickAudio);
            mainMenu.SetActive(true);
            creditsMenu.SetActive(false);
        }

    }

}
