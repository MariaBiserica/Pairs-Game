using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_Pairs_Game
{
    public class Card
    {
        public List<List<string>> Items { get; set; }

        public Card()
        {
            Items = new List<List<string>>();

            for (int i = 0; i < 4; i++)
            {
                List<string> item = new List<string>();

                for (int j = 0; j < 6; j++)
                    item.Add(i + "" + j);

                Items.Add(item);
            }
        }

        public Card(int rows, int cols)
        {
            Items = new List<List<string>>();
            
            for (int i = 0; i < rows; i++)
            {
                List<string> item = new List<string>();

                for (int j = 0; j < cols; j++)
                    item.Add(i + "" + j);

                Items.Add(item);
            }
        }
    }
}
