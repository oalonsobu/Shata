using UnityEngine;
using UnityEngine.UI;
using Variables;

public class CellTypePanelController : MonoBehaviour
{

    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text commentText;
    
    //TODO: I think I can change all this reference for the self reference, but for now is ok I think :D
    [SerializeField] StringReference titleReference;
    [SerializeField] StringReference descriptionReference;
    [SerializeField] StringReference commentReference;
    
    [SerializeField] BoolReference isActiveReference;
    
    
    GameObject container;

    private void Start()
    {
        isActiveReference.value = false;
        container = transform.GetChild(0).gameObject;
        container.SetActive(false);
    }

    private void Update()
    {
        //TODO: this is working but I don't want to constantly check this. Checks out events :D
        container.SetActive(isActiveReference.value);
        if (container.activeSelf) {
            titleText.text = titleReference.value;
            descriptionText.text = descriptionReference.value;
            commentText.text = commentReference.value;
        }
    }
}
