using System;
namespace LifeGame.Model
{
    public class Settings
    {
        private static Settings myself;

        private const int max_columun = 16;
        private const int max_row = 24;



        public static Settings GetInstance()
        {               
            if(myself == null)
            {
                myself = new Settings();
            }

            return myself;
        }


        private Settings()
        { }



        public int MaxColumun()
        {
            return max_columun;
        }


        public int MaxRow()
        {
            return max_row;
        }
    }
}
