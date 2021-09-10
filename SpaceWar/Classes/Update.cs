using System;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    /*
     *  anyone who wants to be updates should inherit from it
    */
    public abstract class Update
    {
        public DispatcherTimer dispatcherTimer;//the main timer

        public Update()
        {
            //initialization
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20); // set to 20 milliseconds
            dispatcherTimer.Start();
        }

        //abstract function execute every 20 milliseconds
        abstract public void dispatcherTimer_Tick(object sender, EventArgs e);

    }
}
