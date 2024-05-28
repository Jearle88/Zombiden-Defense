using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUIItem : 
  MonoBehaviour, 
  IBeginDragHandler, 
  IDragHandler, 
  IEndDragHandler
{
    public AudioSource src;
    public AudioClip sfx1;

    private GameObject player;

    public int cost;
    // prefab to create when you drag and drop from the UI element
    [SerializeField]
    GameObject PrefabToInstantiate;
    //reference to the element to apply transformation
    [SerializeField]
    RectTransform UIDragElement;
    // cache the reference to the canvas
    [SerializeField]
    RectTransform Canvas;

    LayerMask placingMask;

    // private data to store the pointer positions
    private Vector2 mOriginalLocalPointerPosition;
    private Vector3 mOriginalPanelLocalPosition;
    private Vector2 mOriginalPosition; 

    // Initializes mOriginalPosition with local position UIDragElement
    private void Start()
    {
        mOriginalPosition = UIDragElement.localPosition;
        placingMask = LayerMask.GetMask("TowersPlaceable");
    }

    // Called when drag begins. Saves the position UIDragElement 
    // and the local position of the pointer relative to the canvas
    public void OnBeginDrag(PointerEventData data)
    {
        mOriginalPanelLocalPosition = UIDragElement.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        Canvas, 
        data.position, 
        data.pressEventCamera, 
        out mOriginalLocalPointerPosition);

        src.clip = sfx1;
        src.Play();
    }

    // Called while drag is happening. Calculates the offset between 
    // the current and the original position of the pointer
    // and adjusts the position of UIDragElement
    public void OnDrag(PointerEventData data)
    {
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
        Canvas, 
        data.position, 
        data.pressEventCamera, 
        out localPointerPosition))
        {
        Vector3 offsetToOriginal =
            localPointerPosition - 
            mOriginalLocalPointerPosition;
        UIDragElement.localPosition = 
            mOriginalPanelLocalPosition + 
            offsetToOriginal;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(
        Input.mousePosition);

    }

    // Called when drag ends. Performs a raycast from
    // the mouse pointer position to the world space to determine
    // where to create a new object
    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine(
        Coroutine_MoveUIElement(      
            UIDragElement,       
            mOriginalPosition,       
            0.5f));

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(
        Input.mousePosition);

        
        if (Physics.Raycast(ray, out hit, 1000.0f, placingMask))
        {
            Vector3 worldPoint = hit.point;


            GameObject player = GameObject.Find("Player");
            if (player.GetComponent<playerdata>().currMoney >= cost)
            {
                CreateObject(worldPoint);
                player.GetComponent<playerdata>().currMoney -= cost;
            }
        }
    }

    // Moves the given RectTransform from its current position 
    // to the target position
    public IEnumerator Coroutine_MoveUIElement(
        RectTransform r, 
        Vector2 targetPosition, 
        float duration = 0.1f)
    {
        float elapsedTime = 0;
        Vector2 startingPos = r.localPosition;
        while (elapsedTime < duration)
        {
        r.localPosition =
            Vector2.Lerp(
            startingPos,
            targetPosition, 
            (elapsedTime / duration));
        elapsedTime += Time.deltaTime;
        yield return new WaitForEndOfFrame();
        }
        r.localPosition = targetPosition;
    }

    // Instantiates the prefab at the given position
    public void CreateObject(Vector3 position)
    {
        if (PrefabToInstantiate == null)
        {
        Debug.Log("No prefab to instantiate");
        return;
        }
        GameObject obj = Instantiate(
        PrefabToInstantiate, 
        position, 
        Quaternion.identity);
    }
}