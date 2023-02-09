using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Garden
    {
        const int scale = 10;
        public int Scale { get; set; }

        string[,] place = new string[scale, scale];
        public void ChangePlace(int i, int j, string place) => this.place[i, j] = place;

        public string GetPlace(int i, int j) => place[i, j];

        public Garden()
        {
            Scale = scale;
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                {
                    ChangePlace(i, j, "0");
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                {
                    Console.Write(GetPlace(i, j) + " ");
                }
                Console.WriteLine();
            }
        }

        public bool Finished()
        {
            int counter = 0;
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                {
                    if (GetPlace(i, j) != "0")
                        counter++;
                }
            }
            if (counter == scale * scale)
                return true;
            else return false;
        }
    }

    internal class Gardener
    {
        int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        char symbol;
        bool directionType;
        public int[] position = {0,0};
        int scale;

        public void Move()
        {
            if (!directionType)
            {
                if (position[0] + 1 <= scale)
                    position[0] = position[0] + 1;
                else if (position[1] + 1 <= scale)
                {
                    position[0] = 0;
                    position[1] = position[1] + 1;
                }
            }
            else 
            { 
                if (position[1] - 1 >= 0)
                    position[1] = position[1] - 1;
                else if (position[0] - 1 >= 0)
                {
                position[1] = scale;
                position[0] = position[0] - 1;
                }
            }
        }

        public Gardener(Garden garden, int speed, char symbol = 'X', bool directionType = false)
        {
            Speed = speed;
            if (symbol == '0')
            {
                this.symbol = 'X';
            }
            else this.symbol = symbol;
            this.directionType = directionType;
            scale = garden.Scale - 1;
            position[0] = directionType ? scale : 0;
            position[1] = directionType ? scale : 0;
        }
        public string Perform() => Convert.ToString(symbol);
    }

}
