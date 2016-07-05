using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ITI.GameCore
{
    //struct for can move to answer
    public struct PossibleMove
    {
        public readonly int X;
        public readonly int Y;
        public readonly List<StudiedPawn> FreeSquares;
        public readonly Pawn Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleMove" /> struct.
        /// </summary>
        /// <param name="x">The x position of the analyzed pawn.</param>
        /// <param name="y">The y position of the analyzed pawn.</param>
        /// <param name="freeSquares">The free squares.</param>
        /// <param name="value">The value.</param>
        public PossibleMove(int x, int y, List<StudiedPawn> freeSquares, Pawn value)
        {
            X = x;
            Y = y;
            FreeSquares = freeSquares;
            Value = value;
        }
        public bool IsFree
        {
            get { 
                if (FreeSquares.Count == 0) return false;
                return true;
            }
        }
        public int Up
        {
            get { 
                int up = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X == X && value.Y < Y) up++;
                }
                return up;
            }
        }
        public int Down
        {
            get { 
                int down = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X == X && value.Y > Y) down++;
                }
                return down;
            }
        }
        public int Left
        { 
            get { 
                int left = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X < X && value.Y == Y) left++;
                }
                return left;
            }
        }
        public int Right
        {
            get { 
                int right = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X > X && value.Y == Y) right++;
                }
                return right;
            }
            }
        }

    public struct StudiedPawn
    {
        public readonly int X;
        public readonly int Y;

        public StudiedPawn(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    static public class Helper
    {
        static internal void CheckRange(int width, int height, int x, int y)
        {
            if (x < 0 || x > width) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(x));
            if (y < 0 || y > height) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(y));

        }

        #region Checkers for emptyness
        /// <summary>
        /// Checks if the pawn above/down/left/right is empty, if so, return true.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        static public bool CheckUp(int x, int y, IReadOnlyTafl _tafl)
        {
            if (y - 1 < 0 || _tafl[x, y - 1] != Pawn.None) return false;
            if (_tafl[x, y - 1] == Pawn.None) return true;
            return false;
        }
        static public bool CheckDown(int x, int y, IReadOnlyTafl _tafl)
        {
            if (y + 1 >= _tafl.Height || _tafl[x, y + 1] != Pawn.None) return false;
            if (_tafl[x, y + 1] == Pawn.None) return true;
            return false;
        }
        static public bool CheckLeft(int x, int y, IReadOnlyTafl _tafl)
        {
            if (x - 1 < 0 || _tafl[x - 1, y] != Pawn.None) return false;
            if (_tafl[x - 1, y] == Pawn.None) return true;
            return false;
        }
        static public bool CheckRight(int x, int y, IReadOnlyTafl _tafl)
        {
            if (x + 1 >= _tafl.Width || _tafl[x + 1, y] != Pawn.None) return false;
            if (_tafl[x + 1, y] == Pawn.None) return true;
            return false;
        }
        #endregion
        /// <summary>
        /// Checks the walls pawn, forteress corner and throne If detected return true.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        static public bool CheckWalls(int x, int y, IReadOnlyTafl _tafl) //temp, send that to toolbox;
        {
            if ((_tafl[x, y] == Pawn.Wall)
                || (x == 0 && y == 0)  //Top left corner
                || (x == 0 && y == _tafl.Height - 1) //Bot left corner
                || (x == _tafl.Width - 1 && y == 0)  //top right corner
                || (x == _tafl.Width - 1 && y == _tafl.Height - 1)  //Bot right corner
                || (x == (_tafl.Width - 1) / 2 && y == (_tafl.Height - 1) / 2 && (_tafl[((_tafl.Width - 1) / 2), ((_tafl.Height - 1) / 2)]) == Pawn.None)//Throne only if empty
                ) return true;
            return false;
        }
        /// <summary>
        /// Gets the default tafl.
        /// </summary>
        /// <returns>A IReadOnlyTafl with default 11*11</returns>
        static public IReadOnlyTafl GetDefaultTafl()
        {
            //if no tafl send, create a new default tafl
            TaflBasic tafl = new TaflBasic(11, 11);
            //Sets board for a standard 11*11 game [Hardcoded for IT1]
            /*
             x 00 01 02 03 04 05 06 07 08 09 10 x
            00 -- -- -- 01 01 01 01 01 -- -- --
            01 -- -- -- -- -- 01 -- -- -- -- --
            02 -- -- -- -- -- -- -- -- -- -- --
            03 01 -- -- -- -- 10 -- -- -- -- 01
            04 01 -- -- -- 10 10 10 -- -- -- 01
            05 01 01 -- 10 10 11 10 10 -- 01 01
            06 01 -- -- -- 10 10 10 -- -- -- 01
            07 01 -- -- -- -- 10 -- -- -- -- 01
            08 -- -- -- -- -- -- -- -- -- -- --
            09 -- -- -- -- -- 01 -- -- -- -- --
            10 -- -- -- 01 01 01 01 01 -- -- --
            y

            */

            //Set the king and defenders
            tafl[5, 5] = Pawn.King;

            tafl[3, 5] = Pawn.Defender;
            tafl[4, 4] = Pawn.Defender;
            tafl[4, 5] = Pawn.Defender;
            tafl[4, 6] = Pawn.Defender;
            tafl[5, 3] = Pawn.Defender;
            tafl[5, 4] = Pawn.Defender;
            tafl[5, 6] = Pawn.Defender;
            tafl[5, 7] = Pawn.Defender;
            tafl[6, 4] = Pawn.Defender;
            tafl[6, 5] = Pawn.Defender;
            tafl[6, 6] = Pawn.Defender;
            tafl[7, 5] = Pawn.Defender;

            //Set the attackers
            tafl[0, 3] = Pawn.Attacker;
            tafl[0, 4] = Pawn.Attacker;
            tafl[0, 5] = Pawn.Attacker;
            tafl[0, 6] = Pawn.Attacker;
            tafl[0, 7] = Pawn.Attacker;
            tafl[1, 5] = Pawn.Attacker;
            tafl[3, 0] = Pawn.Attacker;
            tafl[3, 10] = Pawn.Attacker;
            tafl[4, 0] = Pawn.Attacker;
            tafl[4, 10] = Pawn.Attacker;
            tafl[5, 0] = Pawn.Attacker;
            tafl[5, 1] = Pawn.Attacker;
            tafl[5, 9] = Pawn.Attacker;
            tafl[5, 10] = Pawn.Attacker;
            tafl[6, 0] = Pawn.Attacker;
            tafl[6, 10] = Pawn.Attacker;
            tafl[7, 0] = Pawn.Attacker;
            tafl[7, 10] = Pawn.Attacker;
            tafl[9, 5] = Pawn.Attacker;
            tafl[10, 3] = Pawn.Attacker;
            tafl[10, 4] = Pawn.Attacker;
            tafl[10, 5] = Pawn.Attacker;
            tafl[10, 6] = Pawn.Attacker;
            tafl[10, 7] = Pawn.Attacker;

            return tafl;
        }
    }
    public class XML_Tafl
    {
        IReadOnlyTafl _TaflRead;
        TaflBasic _TaflWrite;
        List<XElement> xElements = new List<XElement>();
        internal IReadOnlyTafl TaflToRead { get { return _TaflRead; } private set { _TaflRead = value; } }
        internal TaflBasic TaflToWrite { get { return _TaflWrite; } private set { _TaflWrite = value; } }
        public XML_Tafl()
        {
        }
        public void WriteXmlTafl(TaflBasic TaflRead)
        {
            _TaflRead = TaflRead;
            //file = new XmlTextReader(Book.title + ".xml");
            XElement taflXml = new XElement("Tafl",
                new XElement("Width", _TaflRead.Width),
                new XElement("Height", _TaflRead.Height),
                Translate()
                );
            string title = string.Format("{0}_{1}", Convert.ToString(_TaflRead.Width), Convert.ToString(_TaflRead.Height)); ;
            taflXml.Save("./TaflBoardCreate/" + title + ".xml");
        }

        //surcharge
        public void WriteXmlTafl(TaflBasic TaflRead, string name)
        {
            _TaflRead = TaflRead;
            //file = new XmlTextReader(Book.title + ".xml");
            XElement taflXml = new XElement("Tafl",
                new XElement("Width", _TaflRead.Width),
                new XElement("Height", _TaflRead.Height),
                Translate()
                );
            taflXml.Save("./TaflBoardCreate/" + name + ".xml");
        }
        public void WriteXmlTafl(IReadOnlyTafl TaflRead)
        {
            TaflBasic send = new TaflBasic(TaflRead);
            WriteXmlTafl(send);
        }
        internal List<XElement> Translate()
        {
            for (int j = 0; j < _TaflRead.Width; j++)
            {
                for (int i = 0; i < _TaflRead.Height; i++)
                {
                    if (_TaflRead[i,j] == Pawn.None)
                    {
                        xElements.Add(new XElement("Pawn", "None"));
                    }
                    else if (_TaflRead[i, j] == Pawn.King)
                    {
                        xElements.Add(new XElement("Pawn", "King"));
                    }
                    else if (_TaflRead[i, j] == Pawn.Attacker)
                    {
                        xElements.Add(new XElement("Pawn", "Attacker"));
                    }
                    else if (_TaflRead[i, j] == Pawn.Defender)
                    {
                        xElements.Add(new XElement("Pawn", "Defender"));
                    }
                    else if (_TaflRead[i, j] == Pawn.Wall)
                    {}
                }
            }
            return xElements;
        }
        public TaflBasic ReadXmlTafl(int width, int height)
        {
            string title = string.Format("{0}_{1}", Convert.ToString(width), Convert.ToString(height)); ;
            XmlTextReader reader = new XmlTextReader("./TaflBoardCreate/" + title + ".xml");
            TaflBasic outTafl = new TaflBasic(ArrayWidth(reader), ArrayHeight(reader));
            outTafl = ReadTaflArray(reader, outTafl);
            return outTafl;
        }
        //surcharge
        public TaflBasic ReadXmlTafl(string name)
        {
            XmlTextReader reader = new XmlTextReader("./TaflBoardCreate/" + name + ".xml");
            TaflBasic outTafl = new TaflBasic(ArrayWidth(reader), ArrayHeight(reader));
            outTafl = ReadTaflArray(reader, outTafl);
            return outTafl;
        }
        internal int ArrayWidth(XmlTextReader xml)
        {
            int arrayWidth = 0;
            while (xml.Read())
            {
                if (xml.Name == "Width")
                {
                    xml.Read();
                    arrayWidth = Convert.ToInt32(xml.Value);
                    return arrayWidth;
                }
            }
            throw new ArgumentException("The XML dosn't contains a width information");
        }
        internal int ArrayHeight(XmlTextReader xml)
        {
            int arrayHeight = 0;
            while (xml.Read())
            {
                if (xml.Name == "Height")
                {
                    xml.Read();
                    arrayHeight = Convert.ToInt32(xml.Value);
                    return arrayHeight;
                }
            }
            throw new ArgumentException("The XML dosn't contains a height information");
        }
        internal TaflBasic ReadTaflArray(XmlTextReader xml, TaflBasic tafl)
        {
            int x = 0;
            int y = 0;
            int width = tafl.Width;
            int height = tafl.Height;
            if (xml == null)
            {
                throw new ArgumentException("The XML must not be empty");
            }
            while (xml.Read())
            {   
                if (xml.Name == "Pawn")
                {
                    xml.Read();
                    if (xml.Value == "None")
                    {
                        if (x == width - 1)
                        {
                            tafl[x,y] = Pawn.None;
                            x = 0;
                            y++;
                        }
                        else
                        {
                            tafl[x, y] = Pawn.None;
                            x++;
                        }
                    }
                    else if (xml.Value == "King")
                    {
                        if (x == width - 1)
                        {
                            tafl[x, y] = Pawn.King;
                            x = 0;
                            y++;
                        }
                        else
                        {
                            tafl[x, y] = Pawn.King;
                            x++;
                        }
                    }
                    else if (xml.Value == "Attacker")
                    {
                        if (x == width - 1)
                        {
                            tafl[x, y] = Pawn.Attacker;
                            x = 0;
                            y++;
                        }
                        else
                        {
                            tafl[x, y] = Pawn.Attacker;
                            x++;
                        }
                    }
                    else if (xml.Value == "Defender")
                    {
                        if (x == width - 1)
                        {
                            tafl[x, y] = Pawn.Defender;
                            x = 0;
                            y++;
                        }
                        else
                        {
                            tafl[x, y] = Pawn.Defender;
                            x++;
                        }
                    }
                }                
            }
            return tafl;
        }
    }
}
