using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;
    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;
    public GameObject crosshair; // Referensi untuk crosshair

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;

    private FirstPersonController playerController; // Referensi ke skrip kontrol pemain

    void Start()
    {
        dialogueUI.SetActive(false);
        crosshair.SetActive(false); // Sembunyikan crosshair pada awal permainan

        // Mendapatkan referensi ke skrip kontrol pemain
        playerController = player.GetComponent<FirstPersonController>();
    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2.5f)
        {
            // Tampilkan crosshair
            crosshair.SetActive(true);

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll < 0f)
            {
                curResponseTracker++;
                if (curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if (scroll > 0)
            {
                curResponseTracker--;
                if (curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }

            // Trigger dialog
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 3)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
        }
        else
        {
            // Sembunyikan crosshair ketika keluar dari NPC
            crosshair.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        // Sembunyikan crosshair ketika keluar dari NPC
        crosshair.SetActive(false);
    }

    void StartConversation()
    {
        Debug.Log("Starting conversation.");
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];

        // Nonaktifkan kontrol pemain
        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

        // Aktifkan kembali kontrol pemain
        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
}
