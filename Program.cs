using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
	
	public class GameAccount
	{
		public string Username { get; }
		public int CurrentRating { get; set; }
		
		
		public GameAccount(string name, int rating)
		{
			this.Username = name;
			this.CurrentRating = rating;

		}

		public static void SaveHistory(List<string> history,int index, string winner, string loser, int winnerRating, int loserRating)
		{
			history.Add("GAME:" + index+ "\t" + winner +  " VS " + loser + " \t WINNER:" + winner + "[" + winnerRating + "] \t LOSER:" + loser + "[" + loserRating + "]\n");
		}

		public static void GetHistory(List<string> history)
		{
			for (int i = 0; i < history.Count; i++)
			{
				Console.Write(history[i]);
			}
		}
		
		public string PlayerInformation() //інформація про гравця 
		{
			return "Player [name=" + this.Username + ", Rating=" + this.CurrentRating.ToString() + "]";
		}
		
		public static int WinGame(int ratingPlayer,  int rating) //перемога
		{
			
			return ratingPlayer + rating;
		}
		
		public static int LoseGame(int ratingPlayer,  int rating) //програш 
		{
			ratingPlayer -= rating;
			if (ratingPlayer < 0)
			{
				ratingPlayer = 0;
			}

			return ratingPlayer;
		}
		
		 
		public static void Main(String[] args)
		{
			int rating = 10; //рейтинг на який гравці грають 
			int result;
			int index = 1;
			var history = new List<string>();
			
			Random rnd = new Random(); 
			 
			
			var kolia = new GameAccount("KOLIA", 20);
			var olia = new GameAccount("OLIA", 50);
			var vania = new GameAccount("VANIA", 10);

			
			
			//іформація про гравців 
			Console.WriteLine("\n\t\tInformation about players:");
			Console.WriteLine(kolia.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(olia.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(vania.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------\n");
			
			
			//гра 1 
			result =  rnd. Next(1, 3);
			switch (result)
			{
				case 1: kolia.CurrentRating = WinGame(kolia.CurrentRating, rating);
					olia.CurrentRating = LoseGame(olia.CurrentRating, rating);
					SaveHistory(history, index,"kolia", "olia",kolia.CurrentRating, olia.CurrentRating);
					break;
				
				case 2 :olia.CurrentRating = WinGame(olia.CurrentRating, rating);
					kolia.CurrentRating = LoseGame(kolia.CurrentRating, rating);
					SaveHistory(history, index,"olia", "kolia",olia.CurrentRating, kolia.CurrentRating);
					break;
			}

			index++;
			
			
			
			
			//гра 2 
			result =  rnd. Next(1, 3);
			switch (result)
			{
				case 1: kolia.CurrentRating = WinGame(kolia.CurrentRating, rating);
					olia.CurrentRating = LoseGame(olia.CurrentRating, rating);
					SaveHistory(history, index,"kolia", "olia",kolia.CurrentRating, olia.CurrentRating);
					break;
				
				case 2 :olia.CurrentRating = WinGame(olia.CurrentRating, rating);
					kolia.CurrentRating = LoseGame(kolia.CurrentRating, rating);
					SaveHistory(history, index,"olia", "kolia",olia.CurrentRating, kolia.CurrentRating);
					break;
			}
			index++;

			//гра 3 
			result =  rnd. Next(1, 3);
			switch (result)
			{
				case 1: kolia.CurrentRating = WinGame(kolia.CurrentRating, rating);
					vania.CurrentRating = LoseGame(vania.CurrentRating, rating);
					SaveHistory(history, index,"kolia", "vania",kolia.CurrentRating, vania.CurrentRating);
					break;
				
				case 2 :vania.CurrentRating = WinGame(vania.CurrentRating, rating);
					kolia.CurrentRating = LoseGame(kolia.CurrentRating, rating);
					SaveHistory(history, index,"vania", "kolia",vania.CurrentRating, kolia.CurrentRating);
					break;
			}
			
			

			GetHistory(history);
			
		}
	}	
	
}