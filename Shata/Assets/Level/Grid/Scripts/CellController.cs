using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Grid
{
    //Cell information related with unity behaviours
    public class CellController : MonoBehaviour
    {
        Outline outline;
        
        //TODO: need one for active :D
        [SerializeField] StringReference titleReference;
        [SerializeField] StringReference descriptionReference;
        [SerializeField] StringReference commentReference;        
        [SerializeField] BoolReference   isActiveCelReference;


        //TODO: randomize, just for testing rn
        public Cell cell = new Cell(new Grass());
        
        void Start() {
            outline = GetComponent<Outline>();
            outline.enabled = false;
        }
        
        public GameObject SelectCell () {
            outline.enabled = true;
            isActiveCelReference.value = true;
            titleReference.value = getCellTitle();
            descriptionReference.value = getCellDescription();
            commentReference.value = getCellComment();
            
            return gameObject;
        }
        
        public void UnselectCell () {
            titleReference.value = "";
            descriptionReference.value = "";
            commentReference.value = "";
            outline.enabled = false;
            isActiveCelReference.value = false;
        }

        public string getCellDescription() {
            return cell.CellType.getDesription();
        }
        
        public string getCellComment() {
            return cell.CellType.getComment();
        }
        
        public string getCellTitle() {
            return cell.CellType.getTitle();
        }
    }
}
