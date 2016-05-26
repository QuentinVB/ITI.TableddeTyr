using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.GameCore
{
    /// <summary>
    /// Nature of the pawn: a <see cref="Tafl"/> is a board of pawns.
    /// </summary>
    public enum Pawn
    {
        None,
        Attacker,
        Defender,
        King,
        Wall
    }
    public class TaflBasic : ITafl
    {
        int _width;
        int _height;
        Pawn[,] _tafl;
        //Constructor
        public TaflBasic(int width, int height)
        {
            //Tests for "Exceptions dans ta gueule"
            if (width % 2 == 0) throw new ArgumentException("Width of the tafl must be odd", nameof (width));
            if (height % 2 == 0) throw new ArgumentException("Height of the tafl must be odd", nameof(height));
            if (width < 7 || width > 15) throw new ArgumentOutOfRangeException("Width of the tafl must be between 5 and 15", nameof(width));
            if (height < 7 || height > 15) throw new ArgumentOutOfRangeException("Width of the tafl must be between 5 and 15", nameof(height));
            //Creating the new _tafl
            _width = width;
            _height = height;
            _tafl = new Pawn[width, height];
        }

        public TaflBasic(IReadOnlyTafl source)
            : this(source.Width, source.Height)
        {
            //Tests in case of very critical problem. If these are triggered, nuke the matrix.
            if (Width % 2 == 0) throw new ArgumentException("Width of the tafl must be odd", nameof(Width));
            if (Height % 2 == 0) throw new ArgumentException("Height of the tafl must be odd", nameof(Height));
            if (Width < 7 || Width > 15) throw new ArgumentOutOfRangeException("Width of the tafl must be between 5 and 15", nameof(Width));
            if (Height < 7 || Height > 15) throw new ArgumentOutOfRangeException("Width of the tafl must be between 5 and 15", nameof(Height));
            _width = Width;
            _height = Height;
            _tafl = new Pawn[Width, Height];
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public int AttackerCount
        {
            get
            {
                int count = 0;
                foreach (Pawn Attacker in _tafl)
                {
                    count++;
                }
                return count;
            }
        }

        public int DefenderCount
        {
            get
            {
                int count = 0;
                foreach (Pawn Defender in _tafl)
                {
                    count++;
                }
                return count;
            }
        }

        public bool HasKing
        {
            get
            {
                foreach (Pawn King in _tafl)
                {
                    return true;
                }
                return false;
            }
        }

        public Pawn this[int x, int y]
        {
            get {
                if (x < 0 || x > _width-1 || y < 0 || y > _height-1) return Pawn.Wall;
                return _tafl[x,y]; }
            set {
                Helper.CheckRange(_width, _height, x, y);
                _tafl[x, y] = value;
            }
        }

    }

    public class TaflCompressed : ITafl
    {
        //Constructor
        public TaflCompressed(int width, int height)
        {

        }

        public TaflCompressed(ITafl source)
            : this(source.Width, source.Height)
        {

        }

        public int Width
        {
            get { throw new NotImplementedException(); }
        }

        public int Height
        {
            get { throw new NotImplementedException(); }
        }

        public int AttackerCount
        {
            get { throw new NotImplementedException(); }
        }

        public int DefenderCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasKing
        {
            get { throw new NotImplementedException(); }
        }

        public Pawn this[int x, int y]
        {
            get { return Pawn.King; }
            set { throw new NotImplementedException(); }
        }

    }

    static internal class Helper
    {
        static internal void CheckRange (int width, int height, int x, int y)
        {
            if (x < 0 || x > width) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(x));
            if (y < 0 || y > height) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(y));

        }
    }
    /*
    int[] _tafl = new int[height - 1];
    /// <summary>
    /// Edits the tafl at the designated position, replacing the piece by another.
    /// </summary>
    /// <param name="tafl">The tafl edited.</param>
    /// <param name="x">The x position of the edited piece.</param>
    /// <param name="y">The y position of the edited piece.</param>
    /// <param name="piece">The piece,
    /// 0 : 00 : empty,
    /// 1 : 01 : atk : attacker,
    /// 2 : 10 : def : defensor,
    /// 3 : 11 : kig : king</param>
    /// <returns>
    /// Edit the tafl at the designated coordinate.
    /// </returns>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// The piece sent is not acceptable
    /// or
    /// The y coordinate is higher than the tafl send
    /// </exception>
    public int[] EditTaflAt(int[] tafl, byte x, byte y, byte piece)
    {
        if (piece > 3 || piece < 0) throw new ArgumentOutOfRangeException("The piece sent is not acceptable", nameof(piece));
        if (y > tafl.Length) throw new ArgumentOutOfRangeException("The y coordinate is higher than the tafl send", nameof(y));
        int toEdit = tafl[y];//get the int storing the row y
        byte n = (byte)(x * 2);//set the byte offset of column
        toEdit = toEdit & ~(3 << n);//AND operation with the mask "11" for purging the 2 bit edited
        toEdit = toEdit | (piece << n);//OR operation,with the mask based on the piece recieved 
        tafl[y] = toEdit;//store the edited int in the edited taffl
        return tafl;//return the edited tafl
    }
    /// <summary>
    /// Reads the tafl at the designated coordinate.
    /// </summary>
    /// <param name="tafl">The tafl read.</param>
    /// <param name="x">The x position of the case read.</param>
    /// <param name="y">The y position of the case read.</param>
    /// <returns>
    /// 0 : if nothing
    /// 1 : if attacker
    /// 2 : if defensor
    /// 3 : if king
    /// </returns>
    /// <exception cref="System.ArgumentOutOfRangeException">The y coordinate is higher than the tafl send</exception>
    /// <exception cref="System.Exception">There is no king, no attacker, no defensor and not nothing... Something realy bad happened</exception>
    public byte ReadTaflAt(int[] tafl, byte x, byte y)
    {
        if (y > tafl.Length) throw new ArgumentOutOfRangeException("The y coordinate is higher than the tafl send", nameof(y));
        int toRead = tafl[y];//get the int storing the row y
        byte n = (byte)(x * 2);//set the byte offset of column
        if ((toRead & (3 << n)) != 0) return 0;//if there is a king
        if ((((toRead & (1 << n)) != 0) ? true : false) == ((((toRead & (1 << n + 1)) != 0) ? true : false))) return 1;//if there is attacker
        if ((((toRead & (1 << n)) != 0) ? false : true) == ((((toRead & (1 << n + 1)) != 0) ? false : true))) return 2;//if there is defensor
        if ((toRead & (3 << n)) == 0) return 0;//if there is nothing
        throw new Exception("There is no king, no attacker, no defensor and not nothing... Something realy bad happened");
    }
    */

}
/* Hard codded 11*11 /cryalot
0 0 0 1 1 1 1 1 0 0 0
0 0 0 0 0 1 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0
1 0 0 0 0 2 0 0 0 0 1
1 0 0 0 2 2 2 0 0 0 1
1 1 0 2 2 3 2 2 0 1 1
1 0 0 0 2 2 2 0 0 0 1
1 0 0 0 0 2 0 0 0 0 1
0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 1 0 0 0 0 0
0 0 0 1 1 1 1 1 0 0 0
*/
