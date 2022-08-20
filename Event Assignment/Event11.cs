using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAssignment
{

    internal class AccountProtection //publisher
    {

        public delegate void NotifyHandler();
        public event NotifyHandler NotifyOtherClasses;

        public void Hackerishere()
        {
            Console.WriteLine("Hacking in progress");
            System.Threading.Thread.Sleep(10000);
            //WHEN HACKING IS DETECTED
            OnHackerDetected();
        }
        protected virtual void OnHackerDetected()
        {
            NotifyOtherClasses?.Invoke();  //raise event
        }

    }

    public class Notifier  //subscriber
    {
        public void ActonHacking()
        {
            var accPro = new AccountProtection();
            accPro.NotifyOtherClasses += HackerDetectionActions;
            accPro.NotifyOtherClasses += () => Console.WriteLine("Protection Warning-Hacker Invasion");

            accPro.Hackerishere();

        }

        public void HackerDetectionActions()
        {
            Console.WriteLine("Send a CODE RED MESSAGE to email");
            Console.ReadLine();
        }
    }
}
