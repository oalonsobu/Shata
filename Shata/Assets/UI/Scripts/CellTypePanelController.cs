using Level.Grid;
using UnityEngine;
using UnityEngine.UI;
using Variables;

public class CellTypePanelController : MonoBehaviour
{

    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text commentText;
    
   
    GameObject container;

    private void Start() {
        container = transform.GetChild(0).gameObject;
        container.SetActive(false);
    }

    public void selectedCellChangedEvent(CellReference cellReference)
    {
        bool isActive = cellReference.value != null;
        container.SetActive(isActive);
        if (isActive)
        {
            titleText.text = cellReference.value.Title;
            descriptionText.text = cellReference.value.Description;
            commentText.text = cellReference.value.Comment;
            
        }
    }
}
