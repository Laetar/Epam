using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class GameBoard
    {
        private int _width;

        private int _height;

        public int width
        {
            get { return _width; }
        }
        public int height
        {
            get { return _height; }
        }

        GameBoard()
        {
            _width = 0;
            _height = 0;
        }

        GameBoard(int width,int height)
        {
            _width = width;
            _height = height;
        }
    }
}
