using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Poe_Part2
{
    internal class CyberSecurityBot
    {
        private static readonly Random _random = new Random();

        // remember last discussed topic
        private static string currentTopic = "";
        
        // memory storage
        private static Dictionary<string, string> chatMemory = new Dictionary<string, string>();
            
        // returns chatbot responses
        public static string GetBotResponse(string input)
        {
            input = input.ToLower().Trim();
        
            // follow-up conversation flow
            if (input.Contains("tell me more") ||
                input.Contains("explain more") ||
                input.Contains("another tip"))
            { 
            
                if (currentTopic != "")
                {
                    // give another response from the same topic
                    if (multipleResponses.ContainsKey(currentTopic))
                    {
                        List<string> responses = multipleResponses[currentTopic];
        
                        return "Here's more about " + currentTopic + ": "
                            + responses[_random.Next(responses.Count)];
                    }
        
                    return "Would you like to know more about " + currentTopic + "?";
                }
        
                return "Please mention a cybersecurity topic first.";
            }
        
        
            // sentiment detection
            string sentimentKey = userSentiments.Keys.FirstOrDefault(k => input.Contains(k));
            
            if (sentimentKey != null)
            {
                // detect cybersecurity topic together with emotion
                string topicKey = botResponse.Keys.FirstOrDefault(k => input.Contains(k));
        
                if (topicKey != null)
                {
                    currentTopic = topicKey;
        
                    return userSentiments[sentimentKey] +
                           "\nHere is an important tip about " + topicKey + ": " +
                           botResponse[topicKey];
                }
        
        
                return userSentiments[sentimentKey];
            }
        
        
            // multiple responses
            string multiKey = multipleResponses.Keys.FirstOrDefault(k => input.Contains(k));
            
            if (multiKey != null)
            {
                currentTopic = multiKey;
        
                List<string> botResponses = multipleResponses[multiKey];
        
                return botResponses[_random.Next(botResponses.Count)] +
                    "\nDo you want to learn more about " + multiKey + "?";
            }
        
            // single responses
            string key = botResponse.Keys.FirstOrDefault(k => input.Contains(k));
        
            if (key != null)
            {
                currentTopic = key;
        
                return botResponse[key] +
                    "\nWould you like another tip about " + key + "?";
            }
        
            // follow-up responses
            if (input.Contains("yes"))
            {
                // continue current topic conversation
                if (currentTopic != "")
                {
                    // check if topic has multiple responses
                    if (multipleResponses.ContainsKey(currentTopic))
                    {
                        List<string> responses = multipleResponses[currentTopic];
        
                        return "Here's another tip about " + currentTopic + ": " +
                               responses[_random.Next(responses.Count)];
                    }
        
                    // fallback if no multiple responses exist
                    return "Let's continue learning about " + currentTopic + ".";
                }
        
                return "Please mention a cybersecurity topic first.";
            }
        
            if (input.Contains("no"))
            {
                return "Alright! Let me know if you need any cybersecurity assistance later.";
            }
        
            if (input.Contains("more"))
            {
                return "Sure! I can explain the topic in more detail. Which cybersecurity topic would you like to explore further?";
            }
        
            if (input.Contains("i dont understand") || input.Contains("im confused"))
            {
                return "No problem. I can explain the cybersecurity concept in a simpler way. Which part is confusing?";
            }
        
            //unknown input
            return " I do not understand that cybersecurity term yet. Try another keyword.";
        
        }
        
        // save memory
        public static void SaveMemory(string key, string value)
        {
            chatMemory[key] = value;
        }
        
        // check if memory exists
        public static bool HasMemory(string key)
        {
            return chatMemory.ContainsKey(key);
        }
        
        // get memory value
        public static string GetMemory(string key)
        {
            if (chatMemory.ContainsKey(key))
            {
                return chatMemory[key];
            }
        
            return "";
        }
        
        // single responses per keyword
        private static readonly Dictionary<string, string> botResponse = new Dictionary<string, string>
        {
            { "password", "A password is a secret combination of characters used to verify a user's identity " +
                "and protect accounts or devices from unauthorised access." },
        
            { "firewall", "A firewall is a security system that monitors and controls incoming and outgoing " +
                "network traffic to block unauthorised access to devices or networks." },
        
            { "antivirus", "Antivirus software is a cybersecurity program designed to detect, prevent, and remove " +
                "malicious software from a computer or device." },
        
            { "ransomware", "Ransomware is a type of malicious software that encrypts or locks a user's files and " +
                "demands payment in exchange for restoring access." },
        
            { "spyware", "Spyware is malicious software that secretly collects information about a user's activity, " +
                "such as passwords, browsing habits, or personal data, without consent." },
        
            { "https", "HTTPS is a secure version of the HyperText Transfer Protocol that encrypts communication " +
                "between a user's browser and a website." },
        
            { "public wifi", "Public Wi-Fi is a wireless internet network available in public places that may expose " +
                "users to cybersecurity risks if not properly secured." },
        
            { "fraud", "Fraud is the illegal act of deceiving individuals or organisations in order to gain money, " +
                "sensitive information, or other benefits." },
        
            { "privacy", "Privacy refers to a person's ability to control how their personal information is collected, " +
                "used, stored, and shared online." },
        
            { "encryption", "Encryption is the process of converting readable data into coded information to prevent " +
                "unauthorised users from accessing it." },
        
            { "identity theft", "Identity theft is a cybercrime in which someone steals and uses another person's " +
                "personal information for fraudulent purposes." },
        
            { "dark web", "The dark web is a hidden section of the internet that requires special software to access " +
                "and is often associated with anonymous and illegal activities." },
        
            { "backup", "A backup is a secure copy of important data stored separately so it can be recovered if the " +
                "original data is lost, damaged, or stolen." },
        
            { "two factor", "Two-factor authentication is a security process that requires users to provide two forms " +
                "of identification before accessing an account or system." },
        
            { "malware", "Malware is any type of harmful software created to damage devices, steal information, disrupt " +
                "systems, or gain unauthorised access to networks." },
        
            { "vpn", "A Virtual Private Network, or VPN, is a service that encrypts internet traffic and hides a user's " +
                "online identity to improve privacy and security." },
        
            { "scam", "A scam is a dishonest scheme designed to trick people into giving away money, sensitive " +
                "information, or access to personal accounts." },
        
            { "data breach", "A data breach is a security incident in which confidential, sensitive, or protected " +
                "information is accessed or exposed without authorisation." },
        
            { "phishing", "Phishing is a cyberattack in which criminals use fake emails, messages, or websites to trick " +
                "users into revealing sensitive information." },
        
            { "virus", "A computer virus is a type of malicious software that spreads between devices and files, often " +
                "causing damage or stealing information." },
        
            { "worm", "A worm is a self-replicating type of malware that spreads automatically across computers and " +
                "networks without user interaction." },
        
            { "trojan", "A Trojan horse is malicious software disguised as a legitimate program that allows attackers to " +
                "gain unauthorised access to a device." },
        
            { "hacker", "A hacker is a person who uses technical skills to gain access to computer systems, either " +
                "legally for security testing or illegally for malicious purposes." },
        
            { "cyberattack", "A cyberattack is a deliberate attempt to damage, disrupt, or gain unauthorised access " +
                "to computer systems, networks, or digital information." },
        
            { "social engineering", "Social engineering is a manipulation technique used by cybercriminals to trick " +
                "people into revealing confidential information or performing unsafe actions." },
        
            { "brute force", "A brute force attack is a hacking method that repeatedly guesses passwords or encryption " +
                "keys until the correct one is found." },
        
            { "botnet", "A botnet is a network of infected devices controlled remotely by cybercriminals to carry out " +
                "malicious activities such as spam or cyberattacks." },
        
            { "ddos", "A Distributed Denial-of-Service attack is a cyberattack that overwhelms a system or website with " +
                "traffic to make it unavailable to users." },
        
            { "spam", "Spam refers to unwanted or unsolicited digital messages that are often sent in bulk and may " +
                "contain scams, malware, or phishing links." },
        
            { "adware", "Adware is software that automatically displays advertisements on a device and may also collect " +
                "information about a user's online activity." },
        
            { "keylogger", "A keylogger is malicious software or hardware that secretly records everything typed on a " +
                "keyboard, including passwords and personal information." },
        
            { "authentication", "Authentication is the process of verifying the identity of a user, device, or system " +
                "before access is granted." },
        
            { "authorisation", "Authorisation is the process of determining what actions or resources a verified user " +
                "is allowed to access within a system." },
        
            { "cybersecurity", "Cybersecurity is the practice of protecting computers, networks, systems, and data " +
                "from cyber threats, attacks, and unauthorised access." },
        
            { "patch", "A patch is a software update released to fix security vulnerabilities, bugs, or performance " +
                "issues in a program or operating system." },
        
            { "update", "A software update is a newer version of a program or system that improves security, fixes " +
                "problems, or adds new features." },
        
            { "cookies", "Cookies are small files stored by websites on a user's device to remember preferences, login " +
                "information, and browsing activity." },
        
            { "cloud storage", "Cloud storage is an online service that allows users to store, manage, and access files " +
                "over the internet instead of on a physical device." },
        
            { "digital footprint", "A digital footprint is the trail of information and activity a person leaves behind " +
                "while using the internet and digital devices." },
        
            { "cybercrime", "Cybercrime refers to illegal activities carried out using computers, digital devices, or " +
                "the internet to steal, damage, or exploit information." },
        
            { "biometrics", "Biometrics are security technologies that use unique physical characteristics, such as " +
                "fingerprints or facial recognition, to verify identity." },
        
            { "spoofing", "Spoofing is a cyberattack technique in which a criminal disguises their identity by " +
                "pretending to be a trusted person, website, or device." },
        
            { "zero day", "A zero-day vulnerability is a software security flaw that is discovered and exploited by " +
                "attackers before developers can release a fix." },
        
            { "ethical hacker", "An ethical hacker is a cybersecurity professional who legally tests systems and " +
                "networks to identify and fix security weaknesses." },
        
            { "iot", "The Internet of Things, or IoT, refers to physical devices connected to the internet that can " +
                "collect, send, and receive data." },
        
            { "browser security", "Browser security refers to the protective features and settings used to keep " +
                "internet browsing safe from threats such as malware and phishing." },
        
            { "fake website", "A fake website is a fraudulent web page designed to imitate a legitimate site in order to " +
                "steal personal or financial information." },
        
            { "password manager", "A password manager is a secure application that stores, organises, and generates " +
                "passwords for online accounts." },
        
            { "email security", "Email security involves protecting email accounts and communication from threats such " +
                "as phishing, spam, malware, and unauthorised access." },
        
            { "mobile security", "Mobile security is the protection of smartphones, tablets, and mobile devices from " +
                "cyber threats, data theft, and malicious software." },
        
            { "data protection", "Data protection refers to the measures and practices used to safeguard sensitive " +
                "information from loss, theft, or unauthorised access." },
        
            { "security breach", "A security breach is an incident in which unauthorised individuals gain access to " +
                "confidential systems, networks, or information." },
        
            { "cyber threat", "A cyber threat is any potential malicious activity that could exploit vulnerabilities " +
                "and cause harm to digital systems or data." },
        
            { "safe browsing", "Safe browsing is the practice of using the internet responsibly by avoiding suspicious " +
                "websites, links, and downloads that may pose security risks." },
        
            { "online safety", "Online safety refers to the practices and precautions taken to protect users, devices, " +
                "and personal information while using the internet." },
        
            { "shoulder surfing", "Shoulder surfing is the act of secretly observing someone entering sensitive information, " +
                "such as passwords or PINs, in public places." },
        
            { "penetration testing", "Penetration testing is the authorised process of simulating cyberattacks to identify " +
                "and fix security weaknesses in systems or networks." },
        
            { "cyber awareness", "Cyber awareness is the understanding of cyber threats and safe online practices used to " +
                "reduce the risk of digital attacks." },
        
            { "session timeout", "A session timeout is a security feature that automatically logs a user out after a period " +
                "of inactivity to prevent unauthorised access." },
        
            { "secure website", "A secure website is a website that uses security technologies such as HTTPS encryption to " +
                "protect user data and online activity." },
        
            { "smart device", "A smart device is an electronic device connected to the internet that can collect, process, " +
                "and exchange data automatically." },
        
            { "account recovery", "Account recovery is the process of regaining access to an account when login credentials " +
                "are forgotten, lost, or compromised." },
        
            { "password reuse", "Password reuse is the unsafe practice of using the same password across multiple accounts, " +
                "increasing the risk of multiple account compromises." }
        };
        
        // multiple responses for variety 
        private static readonly Dictionary<string, List<string>> multipleResponses = new Dictionary<string, List<string>>
        {
             { "password", new List<string>
                {
                    "A strong password should contain letters, numbers, and symbols to improve account security.",
                    "Using the same password for multiple accounts increases the risk of cybercriminals accessing your information.",
                    "Password managers can help generate and securely store complex passwords."
                }
             },
             { "firewall", new List<string>
                {
                    "A firewall helps block unauthorised traffic from entering your computer or network.",
                    "Firewalls act as a protective barrier between your device and the internet.",
                    "Both hardware and software firewalls improve cybersecurity protection."
                }
             },
             { "privacy", new List<string>
                {
                    "Avoid sharing sensitive personal information on public websites or social media.",
                    "Strong privacy settings help protect your information from cybercriminals.",
                    "Always review app permissions to control what data applications can access."
                }
             },
             { "antivirus", new List<string>
                {
                    "Antivirus software scans devices for harmful programs and removes threats.",
                    "Keeping antivirus software updated improves protection against modern malware.",
                    "Antivirus programs help detect viruses, spyware, and ransomware before damage occurs."
                }
            },
            { "ransomware", new List<string>
                {
                    "Ransomware locks or encrypts files until payment is demanded from the victim.",
                    "Regular backups are important because ransomware attacks can permanently damage data.",
                    "Avoid downloading unknown attachments because ransomware often spreads through email scams."
        
                }
            },
            { "malware", new List<string>
                {
                    "Malware is harmful software designed to damage systems or steal information.",
                    "Viruses, worms, and ransomware are all forms of malware.",
                    "Avoid downloading files from untrusted websites to reduce malware infections."
                }
            },
            { "vpn", new List<string>
                 {
                    "A VPN encrypts internet traffic to improve online privacy and security.",
                    "VPNs are especially useful when using public Wi-Fi networks.",
                    "A VPN helps hide your IP address and online activity from attackers."
                 }
            },
            { "scam", new List<string>
                {
                    "Online scams often trick users into sending money or revealing sensitive information.",
                    "Scammers frequently pretend to represent trusted organisations or banks.",
                    "Be cautious of urgent messages requesting payments or account details."
        
                }
            },
            { "data breach", new List<string>
                {
                    "A data breach occurs when confidential information is exposed without permission.",
                    "Changing passwords quickly after a data breach can reduce security risks.",
                    "Data breaches may expose personal details such as emails, passwords, or banking information."
                }
            },
            { "phishing", new List<string>
                {
                    "Phishing attacks often use fake emails or websites to steal sensitive information.",
                    "Always verify suspicious links before clicking because phishing websites can look legitimate.",
                    "Cybercriminals use phishing messages to trick users into revealing passwords or banking details."
        
                }
            },
           { "spyware", new List<string>
                {
                    "Spyware secretly monitors user activity and collects personal information.",
                    "Cybercriminals use spyware to steal passwords and track online behaviour.",
                    "Installing trusted security software can help detect and remove spyware."
                }
            },
            { "hacker", new List<string>
                {
                    "Hackers use technical skills to gain access to computer systems or networks.",
                    "Ethical hackers help organisations improve security by testing vulnerabilities.",
                    "Malicious hackers often steal data, spread malware, or disrupt systems."
                }
            },
            { "cyberattack", new List<string>
                {
                    "Cyberattacks target systems and networks to steal, damage, or disrupt information.",
                    "Phishing, malware, and DDoS attacks are common forms of cyberattacks.",
                    "Strong cybersecurity practices help reduce the risk of cyberattacks."
                }
            },
            { "social engineering", new List<string>
                {
                    "Social engineering manipulates people into revealing confidential information.",
                    "Cybercriminals often pretend to be trusted individuals to trick victims.",
                    "Awareness and verification are important defences against social engineering attacks."
                }
            },
            { "ddos", new List<string>
                {
                    "A DDoS attack floods a website or network with traffic to make it unavailable.",
                    "Distributed Denial-of-Service attacks can slow down or completely crash online services.",
                    "Many devices working together are often used to perform DDoS attacks."
                }
            },
            { "spam", new List<string>
                {
                    "Spam messages are unwanted digital communications often sent in large quantities.",
                    "Spam emails may contain phishing links or malware attachments.",
                    "Email filters help reduce spam and improve online security."
                }
            },
            { "cookies", new List<string>
                {
                    "Cookies store information about website activity and user preferences.",
                    "Some cookies improve browsing experiences while others track online behaviour.",
                    "Users can manage or delete cookies through browser settings."
                }
            },
            { "cybersecurity", new List<string>
                {
                    "Cybersecurity protects devices, networks, and data from digital threats.",
                    "Good cybersecurity practices help prevent hacking, malware, and identity theft.",
                    "Cybersecurity combines technology, awareness, and safe online behaviour."
                }
            },
            { "online safety", new List<string>
                {
                    "Online safety involves protecting personal information and avoiding cyber threats.",
                    "Strong passwords and careful browsing improve online safety.",
                    "Users should avoid suspicious websites and unknown downloads."
                }
            },
            { "fake website", new List<string>
                {
                    "Fake websites imitate real websites to steal passwords or financial information.",
                    "Always check website URLs carefully before entering sensitive data.",
                    "Secure websites usually display HTTPS and a padlock icon."
                }
            },
            { "password manager", new List<string>
                {
                    "Password managers securely store and organise account passwords.",
                    "Using a password manager helps users create stronger and unique passwords.",
                    "Password managers reduce the risk of forgetting complex passwords."
                }
            }
        };
        
        // chatbot detects sentiment
        private static readonly Dictionary<string, string> userSentiments = new Dictionary<string, string>
        {
            {"sad","I'm sorry you're feeling sad. Remember to take breaks and stay safe online" },
            {"angry", "I understand your frustration. Cyber threats can be stressful." },
            {"worried", "It's okay to feel worried. Staying informed and practising safe online " +
                "habits can greatly reduce risks." },
            {"scared", "Online scams can feel scary, but awareness is your best defence." },
            {"happy", "I'm glad you're feeling happy today!" },
            {"frustrated", "Cybersecurity can sometimes feel frustrating and overwhelming, but " +
                "learning one concept at a time makes it easier to stay safe online." },
            {"confused", "Cybersecurity terms can be confusing at first, but I can explain them " +
                "in a simpler way if you need help understanding them." }
        };

    }
}
