using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Dialogue dialogue;
    private bool isPlayerNear = false;
    private bool isNo = false;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;
    public Button continueBtn;
    public Button skipBtn;
    public Button tiendaBtn;
    // public int finanDialogIndex = 0;

    public Animator animator;

    private Queue<string> sentences;

    public HUDScript finan;


    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false); // Hide buttons initially
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsOpen", true);
            dialoguePanel.SetActive(true);
            foreach (var button in optionButtons)
            {
                button.gameObject.SetActive(false); // Hide buttons initially
            }
            continueBtn.gameObject.SetActive(true);
            skipBtn.gameObject.SetActive(true);

            StartDialogue(dialogue);
            // TriggerDialogue();
        }
    }

    // public void TriggerDialogue ()
    // {
    //     FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            EndDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        if ((finan.prestamoUsado && finan.seguroVerqorUsado) || (finan.prestamoUsado && finan.seguroCoyoteUsado) || (finan.prestamoUsado && finan.seguroBancoUsado))
        {
            string lastSentence = dialogue.sentences[dialogue.sentences.Length - 1];
            if (nameText.text == "Verqor" && finan.prestamoUsado)
            {
                // Cambiar el texto de la ultima oracion
                lastSentence = "Gracias por contratar con nosotros! Ahora puedes acceder a la tienda fácilmente con nosotros!";
            }

            sentences.Enqueue(lastSentence);


            // Display the desired dialogue
            DisplayNextSentence();
            return;
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (sentences.Count == 2)
        {
            continueBtn.gameObject.SetActive(false);
            skipBtn.gameObject.SetActive(false);
        }

        string sentence;

        if (sentences.Count == 1)
        {
            sentence = sentences.Dequeue();

            if (nameText.text == "Verqor" && finan.prestamoUsado)
            {
                sentence = "¡Gracias por contratar con nosotros! Ahora puedes acceder a la tienda fácilmente con nosotros!";
                // tiendaBtn.gameObject.SetActive(true);
                // sentences.Enqueue(sentence);
            }
            if (finan.seguroVerqorUsado)
            {
                sentence = "¡Gracias por contratar con nosotros! Te ofreceremos un gran apoyo a tu agricola!";
                // sentences.Enqueue(sentence);
            }
            else if (nameText.text == "Coyote" && (finan.prestamoUsado || finan.seguroCoyoteUsado))
            {
                sentence = "¿Que tranza? Gracias por contratar conmigo. Seguramente obtendras más lana.";
                // sentences.Enqueue(sentence);
            }
            else if (nameText.text == "Banco" && (finan.prestamoUsado || finan.seguroBancoUsado))
            {
                sentence = "¡Gracias por su contrato! ¡Vuelva pronto!";
                // sentences.Enqueue(sentence);
            }
            else if (nameText.text == "Verqor" && isNo)
            {
                sentence = "Esta bien... Puedes regresar cuando cambies de opinion. Siempre estaremos aquí para ayudarte!";
                isNo = false;
                // sentences.Enqueue(sentence);
            }
            else if (nameText.text == "Coyote" && isNo)
            {
                sentence = "Hmmm... seguro? Te arrepentiras de no poder ganar más lana...";
                isNo = false;
                // sentences.Enqueue(sentence);
            }
            else if (nameText.text == "Banco" && isNo)
            {
                sentence = "¡No hay problema! Puedes regresar cuando quieras un préstamo con nosotros.";
                isNo = false;
                // sentences.Enqueue(sentence);
            }
        }
        else
        {
            sentence = sentences.Dequeue();
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void SkipToDialogue(int dialogueIndex)
    {
        // Check if dialogueIndex is valid
        if (dialogueIndex < 0 || dialogueIndex >= sentences.Count)
        {
            Debug.LogError("Invalid dialogue index");
            return;
        }

        // Dequeue sentences until the desired dialogue is reached
        while (sentences.Count > dialogueIndex + 1)
        {
            sentences.Dequeue();
        }

        continueBtn.gameObject.SetActive(false);
        skipBtn.gameObject.SetActive(false);


        // Display the desired dialogue
        DisplayNextSentence();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }

        // If there is only one sentence left in the queue, display the buttons
        if (sentences.Count == 1)
        {
            foreach (var button in optionButtons)
            {
                button.gameObject.SetActive(true);
            }

            if (finan.prestamoUsado)
            {
                optionButtons[0].gameObject.SetActive(false);
                // Transform button
                RectTransform rT = optionButtons[1].GetComponent<RectTransform>();
                rT.anchoredPosition = new Vector2(145, -24.5f);
                if (nameText.text == "Verqor")
                {
                    tiendaBtn.gameObject.SetActive(true);
                }
            }
            if (finan.seguroVerqorUsado)
            {
                optionButtons[1].gameObject.SetActive(false);
                // Transform button
                RectTransform rT = optionButtons[0].GetComponent<RectTransform>();
                rT.anchoredPosition = new Vector2(145, -24.5f);
            }
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        dialoguePanel.SetActive(false);
        Debug.Log("End of conversation");
    }

    /* public void OnFinanceSelected()
    {
        continueBtn.gameObject.SetActive(true);

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }

        string lastSentence = "Gracias por contratar con nosotros! Ahora puedes acceder a la tienda fácilmente con nosotros!";

        sentences.Enqueue(lastSentence);

        tiendaBtn.gameObject.SetActive(true);
    } */

    public void OnButtonOptionClick()
    {
        DisplayNextSentence();
        continueBtn.gameObject.SetActive(true);

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void OnClickNo()
    {
        /* DisplayNextSentence();
        continueBtn.gameObject.SetActive(true);

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
                
        string lastSentence = dialogue.sentences[dialogue.sentences.Length - 1];

        if (nameText.text == "Verqor")
        {
            lastSentence = "Esta bien... Puedes regresar cuando cambies de opinion. Siempre estaremos aquí para ayudarte!";
        }
        else if (nameText.text == "Coyote")
        {
            lastSentence = "Hmmm... seguro? Te arrepentiras de no poder ganar más lana...";
        }
        else if (nameText.text == "Banco")
        {
            lastSentence = "¡No hay problema! Puedes regresar cuando quieras un préstamo con nosotros.";
        }

        sentences.Enqueue(lastSentence); */
        isNo = true;
    }

}
