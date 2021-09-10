using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace SpaceWar.Classes
{
    /**
     * The player class
     */
    public class Player
    {

        public int Cash { get; set; } // cash of player
        public List<Spaceship> Ships { get; set; } // a list of all the ships the player has
        public Spaceship UseShip { get; set; } //the ship that player choose to play with
        public int BestLevel { get; set; } // the best level of player
        public Settings Settings { get; set; } // settings object
       
        public Player()
        {
            //initialization
            Cash = 100000;
            var ship = new Spaceship("rocket1"); //default ship
            UseShip = ship;
            Ships = new List<Spaceship>();
            Ships.Add(ship);
            BestLevel = 1;
            Settings = new Settings();
        }
        /*
         * export object to json file with a third-party library
         */
        public void Export()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(this);
                writer = new StreamWriter("player.json", false);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        /*
        * import object from json file with a third-party library
        */
        public Player Import()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader("player.json");
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Player>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

        }
    }
}
