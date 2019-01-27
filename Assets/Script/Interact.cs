using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class Interact : MonoBehaviour
{
    [Header("Dialogs")]
    [SerializeField] List<TextMeshProUGUI> dialogs = new List<TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI displayDialog = new TextMeshProUGUI();
    [SerializeField] GameObject dialogOptions;
    [Header("Interact button")]
    [SerializeField] GameObject interactButtonPrefab;
    [SerializeField] float offset;
    GameObject interactButtonDisplay;
    TextMeshProUGUI currentDialog = new TextMeshProUGUI();

    bool canInteract = false;
    bool interact = false;
    int dialogCounter = 0;

    private void Start()
    {
        offset = GetComponent<Renderer>().bounds.size.y / 2.0f;
        interactButtonDisplay = Instantiate(interactButtonPrefab, transform.position + new Vector3(0, offset, 0), Quaternion.identity);
        interactButtonDisplay.SetActive(false);

        displayDialog.transform.position = transform.position + new Vector3(0, offset, 0);
        dialogOptions.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactButtonDisplay.SetActive(true);
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButtonDisplay.SetActive(false);
        ResetDialog();
        dialogOptions.SetActive(false);
        canInteract = false;
    }

    private void InteractWithObject()
    {
        if(Input.GetButtonDown("Jump"))
        {
            ProgessDialog();
        }
    }

    private void ProgessDialog()
    {
        if(dialogCounter < dialogs.Count)
        {
            interactButtonDisplay.SetActive(false);
            currentDialog = dialogs[dialogCounter];
            displayDialog.SetText(currentDialog.text);
            dialogCounter++;
        }
        else if(dialogCounter == dialogs.Count)
        {
            displayDialog.SetText("");
            dialogCounter++;
            dialogOptions.SetActive(true);
        } 
        else
        {
            ResetDialog();
            dialogOptions.SetActive(false);
            interactButtonDisplay.SetActive(true);
        }

    }

    private void Update()
    {
        if(canInteract)
        {
            InteractWithObject();
        }
    }

    private void ResetDialog()
    {
        dialogCounter = 0;
        displayDialog.SetText("");
    }

}
