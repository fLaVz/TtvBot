using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;


class main {

	static public void Main() {

		IrcClient irc = new IrcClient(
			"irc.twitch.tv", 
			6667, 
			"flav__bot", 
			"oauth:yx9llpk5k7fjq64895vqifadgy0fke");

		graphics box = new graphics();
		box.configure();
		/*

		string inputMessage;
		irc.joinRoom("flav__");
		

		while(true) {

			inputMessage = irc.readMessage();
        	Console.ForegroundColor = ConsoleColor.DarkGreen;

			Console.WriteLine("$> " + inputMessage);

			Console.ResetColor();
			irc.parse(inputMessage);
		}*/
	}

}
	