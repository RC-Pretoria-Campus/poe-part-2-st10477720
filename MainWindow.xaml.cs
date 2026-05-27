using System.Text;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog_Poe_Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // memory storage
        Dictionary<string, string> chatMemory = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent(); ;

            txtChat.AppendText("Bot: Hello! I'm CyAC, your cybersecurity assisstant.\n");
            txtChat.AppendText("Bot: What is your name?\n");
            txtChat.AppendText("Type 'quit' to exit the chatbot.\n");

        }

        // send button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sendMessage();
        }

        private void sendMessage()
        {
            string userInput = txtMessage.Text.ToLower().Trim();
           
            // empty validation
            if (string.IsNullOrWhiteSpace(userInput))
            {
                txtChat.AppendText("Bot: The message is empty. Please enter a message.\n");
                return;
            }

            // display user message
            txtChat.AppendText("You: " + userInput + "\n");

            string name = userInput.Replace("my name is", "").Trim();

            // memory feature
            if (userInput.Contains("my name is"))
            {              
                chatMemory["name"] = name;

                txtChat.AppendText("Bot: Nice to meet you " + name + "! I'll remember your name.\n");
            }
            // exit
            else if (userInput == "quit")
            {
                string userName = chatMemory.ContainsKey("name")? chatMemory["name"]: "User";

                MessageBox.Show(
                    "Thank you " + userName +
                    " for using CyAC chatbot.\nSee you next time, goodbye!",
                    "CyAC Chatbot :)"
                );

                this.Close();
            }
            // memory recall
            else if (userInput.Contains("who am i") || userInput.Contains("my name"))
            {
                if (chatMemory.ContainsKey("name"))
                {
                    txtChat.AppendText("Bot: Your name is " + chatMemory["name"] + "\n");
                }
                else
                {
                    txtChat.AppendText("Bot: I don't know your name yet. \n");
                }
            }
            //greetings
            else if (userInput == "hello" || userInput == "hi")
            {
                if (chatMemory.ContainsKey("name"))
                {
                    txtChat.AppendText("Bot: Hello " + chatMemory["name"] + "! How can I help you?\n");
                }
                else
                {
                    txtChat.AppendText("Bot: Hello! How can I help you?\n");
                }
            }
            //purpose
            else if (userInput.Contains("purpose") || userInput.Contains("mission") || userInput.Contains("what can i ask"))
            {
                txtChat.AppendText("Bot: You can ask me about anything related to cybersecurity such as passwords, phishing, scams, malware, VPNs, and online safety.\n");
            }
            else if (userInput.Contains("how are you"))
            {
                txtChat.AppendText("Bot: I'm running perfectly and ready to help you stay safe online!\n");
            }
            // chatbot responses
            else
            {
                string botResponse = CyberSecurityBot.GetBotResponse(userInput);

                if (botResponse != null)
                {
                    txtChat.AppendText("Bot: " + botResponse + "\n");
                }
                else
                {
                    txtChat.AppendText("Bot: I didn't quite understand that. Try asking about passwords, scams, phishing, or online safety.\n");
                }
            }


            // clears textbox
            txtMessage.Clear();

            // auto scroll
            txtChat.ScrollToEnd();
        }



        // enter key send feature
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sendMessage();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtChat.Document.Blocks.Clear();
            txtChat.AppendText("Bot: The chat is cleared.\n");
            return;
        }
    }
}