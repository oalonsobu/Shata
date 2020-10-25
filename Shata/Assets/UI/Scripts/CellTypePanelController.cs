using UnityEngine;
using UnityEngine.UI;
using Variables;

public class CellTypePanelController : MonoBehaviour
{

    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text commentText;
    
    [SerializeField] CellReference cellReference;    
    [SerializeField] BoolReference isActiveReference;
    
    
    GameObject container;

    private void Start() {
        isActiveReference.value = false;
        container = transform.GetChild(0).gameObject;
        container.SetActive(false);
    }

    private void Update() {
        //TODO: this is working but I don't want to constantly check this. Checks out events :D
        container.SetActive(isActiveReference.value);
        if (container.activeSelf) {
            titleText.text = cellReference.value.CellType.getTitle();
            descriptionText.text = cellReference.value.CellType.getDesription();
            commentText.text = cellReference.value.CellType.getComment();
        }
    }
}
