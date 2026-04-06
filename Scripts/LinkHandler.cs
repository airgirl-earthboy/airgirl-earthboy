using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkHandler : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData) {
        TMP_Text pText = GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pText, eventData.position, null);
        if (linkIndex != -1) {
            TMP_LinkInfo linkInfo = pText.textInfo.linkInfo[linkIndex];
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}