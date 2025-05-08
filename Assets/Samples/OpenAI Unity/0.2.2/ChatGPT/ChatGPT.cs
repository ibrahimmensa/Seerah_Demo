using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using LMNT;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;
        
        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;
        //[SerializeField] private LMNTSpeech narrator;

        private float height;
        private OpenAIApi openai = new OpenAIApi();
        public TMP_Text story;
        public bool isScrolling = false;
        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "Act as a random stranger in a chat room and reply to the questions. Don't break character. Don't ever mention that you are an AI model.";

        private void Start()
        {
            button.onClick.AddListener(SendReply);
            //Invoke("test", 2);
        }

        private void OnEnable()
        {
            startScrollingStory();
        }

        void test()
        {
            //StartCoroutine(narrator.Talk());
        }

        private void AppendMessage(ChatMessage message)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

            var item = Instantiate(message.Role == "user" ? sent : received, scroll.content);
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = message.Content;
            item.anchoredPosition = new Vector2(0, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        public async void SendReply()
        {
            inputField.text = "Tell The detailed Story of Prophet Musa according to Ar - Raheeq Al - Makhtum (The Sealed Nectar) — by Safi-ur-Rahman Al-Mubarakpuri";
            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = inputField.text/*"Tell the story of Prophet Musa"*/
            };
            
            //AppendMessage(newMessage);

            if (messages.Count == 0) newMessage.Content = prompt + "\n" + inputField.text; 
            
            messages.Add(newMessage);
            
            button.enabled = false;
            inputField.text = "";
            inputField.enabled = false;
            //narrator.dialogue = "";
            // Complete the instruction
            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-4o-mini",
                Messages = messages
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();
                
                //narrator.dialogue = message.Content;
                
                Debug.Log(message.Content);
                //StartCoroutine(narrator.Talk());
                messages.Add(message);
                Debug.Log(messages[messages.Count - 1].Content);
                AppendMessage(message);
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            button.enabled = true;
            inputField.enabled = true;
        }

        public void onClickBack()
        {
            SceneManager.LoadScene(1);
        }

        //public void OnEnable()
        //{
        //    narrator.dialogue = story.text;
        //    StartCoroutine(narrator.Talk());
        //}

        public void startScrollingStory()
        {
            isScrolling = true;
            StartCoroutine(startScrolling());
        }

        IEnumerator startScrolling()
        {
            while (isScrolling)
            {
                yield return new WaitForSeconds(0.1f);
                story.transform.position = new Vector3(story.transform.position.x, story.transform.position.y + 2.5f, story.transform.position.z);
            }
        }
    }
}
