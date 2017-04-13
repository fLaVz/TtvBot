using System;
using System.Text;
using System.Threading.Tasks;
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

		string inputMessage;
		int loop = 1;

		irc.joinRoom("flav__");
		

		while(loop == 1) {

			inputMessage = irc.readMessage();
			Console.WriteLine("$> " + inputMessage);

			irc.parse(inputMessage);
		}
	}

}
	