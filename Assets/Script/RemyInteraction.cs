using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueEditor;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private NPCConversation Wardrobe;

    public GameObject inttext;
    public bool onDialog = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (onDialog)
            {
                inttext.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    onDialog = false;
                    inttext.SetActive(false);
                    ConversationManager.Instance.StartConversation(Wardrobe);
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    inttext.SetActive(false);
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inttext.SetActive(false);
    }

    public void ableToInt()
    {
        onDialog=true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inttext.SetActive(false);
    }
}