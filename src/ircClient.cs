using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;


class IrcClient {

		private string userName;
		private string channel;

		private TcpClient tcpClient;
		private StreamReader inputStream;
		private StreamWriter outputStream;


		public IrcClient(string ip, int port, string userName, string password) {

			this.userName = userName;

			tcpClient = new TcpClient(ip, port);
			inputStream = new StreamReader(tcpClient.GetStream());
			outputStream = new StreamWriter(tcpClient.GetStream());

			outputStream.WriteLine("PASS " + password);
			outputStream.WriteLine("NICK " + userName);
			outputStream.WriteLine("USER " + userName + " 8 * :" + userName);
			outputStream.Flush();
		}

		public void reconnect() {

			outputStream.WriteLine("JOIN #" + channel);
		}

		public void requestCommands() {

			outputStream.WriteLine("CAP REQ :twitch.tv/membership");
		}

		public void joinRoom(string channel) {

			this.channel = channel;
			outputStream.WriteLine("JOIN #" + channel);
			sendChatMessage("/me has join the channel");
			outputStream.Flush();
		}

		public void sendIrcMessage(string message) {

			outputStream.WriteLine(message);

        	Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("$< :" + message);
			
			outputStream.Flush();
			Console.ResetColor();
		}

		public void sendChatMessage(string message) {

			sendIrcMessage(":" + userName + "!" + userName + "@" + userName + 
				".tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
		}

		public string readMessage() {

			string message = inputStream.ReadLine();
			return message;
		}

		public void parse(string message) {

			string[] parsed = message.Split(':');

			if(parsed.Length == 3) {

				process(parsed);
			}else {

				if(message.Contains("PING")) {

				Console.WriteLine("PONG :tmi.twitch.tv");
				sendIrcMessage("PONG :tmi.twitch.tv");
				}

			}
		}


		public void process(string[] message) {

			string viewerName = "";

			if(message[1].Contains("@")) {
				viewerName = message[1].Split('!', '@')[1];
				
			}


			if(isABannedWord(message[2], viewerName) == true) {

				switch(message[2]) {

					case "!hello":
					sendChatMessage("Salut ! et bienvenue sur le live " + viewerName + " :)");
					break;

					case "!useroptions":
					sendChatMessage(viewerName + " : Voici mon useroptions ! -> http://pastebin.com/eEuegC3D");
					break;

				}
			}
		}

		public bool isABannedWord(string message, string viewerName) {

			if(message.Contains("pute") || 
				message.Contains("salope")) {

				sendChatMessage(viewerName + " : Don't be so rude");
				sendChatMessage("/timeout " + viewerName + " 3");

				return false;
			}else {
				return true;
			}
		}
}