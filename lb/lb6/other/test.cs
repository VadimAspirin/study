using System;

namespace Laba6 {

	delegate void lol ();
	
	class lolki {
		public void lolki1 () {
			Console.WriteLine ("1");
			}
		public void lolki2 () {
			Console.WriteLine ("2");
			}
		}
		
	class myEvent {
		public event lol EventLol;
		public void startEvent () {
			EventLol ();
			}
		}
		
	class Animals {
		public void songDog () {
			Console.WriteLine ("RRRRRRR GAV!!!"); 
			}
		public void songCat () {
			Console.WriteLine ("meow"); 
			}
		}

	class MainLaba {
		static void Main () {
			lolki Lolki = new lolki();
			lol LOL = Lolki.lolki1;
			LOL += Lolki.lolki2;
			// анонимный метод
			LOL += delegate () { 
				Console.WriteLine ("3"); 
				};
			// лямбда-выражение
			LOL += () => Console.WriteLine ("4");
			LOL += () => { 
				Console.WriteLine ("5"); 
				};
			LOL();
			
			myEvent me = new myEvent();
			Animals animals = new Animals();
			me.EventLol += animals.songDog;
			me.EventLol += animals.songCat;
			me.startEvent();
			
			}
		}
	}
