using UnityEngine;
using Common;

namespace UI
{
    public class MainMenuController : MonoBehaviour {

        [SerializeField] GameObject creditsMenu;
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject loadSceneMenu;
        [SerializeField] AudioClip clickAudio;

        AudioHelper audioHelper;
        private AsyncOperation loadSceneOperation;
        
        void Start() 
        {
            audioHelper = GetComponent<AudioHelper>();
            mainMenu.SetActive(true);
            creditsMenu.SetActive(false);
            loadSceneMenu.SetActive(false);
        }

        public void NewGame() 
        {
            audioHelper.PlaySound(clickAudio);
            loadSceneMenu.SetActive(true);
            mainMenu.SetActive(false);
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
            loadSceneMenu.SetActive(false);
        }
    }

}
