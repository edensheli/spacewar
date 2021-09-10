
namespace SpaceWar.Classes
{
    /*
     *the settings class 
     */
    public class Settings
    {
        public bool Music { get; set; } //play music
        public bool Sound { get; set; }//play sound
        public bool Attack { get; set; }//if true attack with mouse else with space
        public bool Move { get; set; } //if true move with mouse else with arrows
        public string Name { get; set; }//player name
        public Settings()
        {
            //initialization
            Music = true;
            Sound = true;
            Move = true;
            Attack = true;
            Name = "";
        }

    }
}
