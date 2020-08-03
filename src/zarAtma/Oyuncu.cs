using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zarAtma
{
    class Oyuncu
    {
        private string isim;
        private int zarNo;
        private int skor;
        Random rnd;

        public Oyuncu(string isim)
        {
            this.isim = isim;
            zarNo = 0;
            skor = 0;
        }

        public void zarAt()
        {
            rnd = new Random();
            zarNo = rnd.Next(1, 7);
        }

        public int Zar
        {
            get
            {
                return zarNo;
            }
        }

        public int Skor
        {
            get
            {
                return skor;
            }
            set
            {
                skor = value;
            }
        }

    }
}
