using Level.Grid;
using UnityEngine;
using UnityEngine.UI;
using Variables;

public class CellTypePanelController : MonoBehaviour
{

    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text commentText;
    
    [SerializeField] BoolReference isActiveReference;
    
   
    GameObject container;

    private void Start() {
        isActiveReference.value = false;
        container = transform.GetChild(0).gameObject;
        container.SetActive(false);
    }

    public void selectedCellEvent(CellReference cellReference) {
        container.SetActive(isActiveReference.value);
        titleText.text = cellReference.value.CellType.getTitle();
        descriptionText.text = cellReference.value.CellType.getDesription();
        commentText.text = cellReference.value.CellType.getComment();
    }
    
    public void unselectedCellEvent() {
        container.SetActive(isActiveReference.value);
    }
}
