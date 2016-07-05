using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// A move is a compacted structure containing the moved pawn's coordinate and the destination coordinate, making easier to manipulate
    /// </summary>
    public struct Move
    {
        public readonly int sourceX;
        public readonly int sourceY;
        public readonly int destinationX;
        public readonly int destinationY;
        public Move(int x, int y, int x2, int y2)
        {
            sourceX = x;            
            sourceY = y;
            destinationX = x2;
            destinationY = y2;
        }
    }
    static internal class Helper
    {
        static internal void CheckRange(int width, int height, int x, int y)
        {
            if (x < 0 || x > width) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(x));
            if (y < 0 || y > height) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(y));
        }
    }
    public enum SortBy
    {
        Random,
        Turn
    }
    public struct Freyjas_options
    {
        public readonly int _maxSimTurn;
        public readonly int _maxIncubatedNode;
        public readonly int _maxComparaison;
        public readonly SortBy _equalResultMethod;
        public Freyjas_options(int maxSimTurn,int maxIncubatedNode,int maxComparaison,SortBy equalResultMethod)
        {
            _maxSimTurn = maxSimTurn;
            _maxIncubatedNode = maxIncubatedNode;
            _maxComparaison = maxComparaison;
            _equalResultMethod = equalResultMethod;
         }
    }
    public class XML_IO_Monitor
    {
        int _maxSimTurn;
        int _maxIncubatedNode;
        int _maxComparaison;
        SortBy _equalResultMethod;
        List<XElement> xElements = new List<XElement>();
        public XML_IO_Monitor()
        { }
        internal int MaxSimTurn { get { return _maxSimTurn; } private set { _maxSimTurn = value; } }
        internal int MaxIncubatedNode { get { return _maxIncubatedNode; } private set { _maxIncubatedNode = value; } }
        internal int MaxComparison { get { return _maxComparaison; } private set { _maxComparaison = value; } }
        internal SortBy EqualResultMethod { get { return _equalResultMethod; } private set { _equalResultMethod = value; } }

        /*
        public void WriteXmlTafl(IReadOnlyTafl TaflRead)
        {
            _TaflRead = TaflRead;
            //file = new XmlTextReader(Book.title + ".xml");
            XElement taflXml = new XElement("Tafl",
                new XElement("Width", _TaflRead.Width),
                new XElement("Height", _TaflRead.Height),
                Translate()
                );
            string title = string.Format("{0}_{1}", Convert.ToString(_TaflRead.Width), Convert.ToString(_TaflRead.Height)); ;
            taflXml.Save("./" + title + ".xml");
        }
        internal List<XElement> Translate()
        {
            for (int i = 0; i < _TaflRead.Width; i++)
            {
                for (int j = 0; j < _TaflRead.Height; j++)
                {
                    if (_TaflRead[i, j] == Pawn.None)
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
                    { }
                }
            }
            return xElements;
        }
        */

        public Freyjas_options ReadXmlOptions()
        {
            XmlTextReader xml = new XmlTextReader("./freyjaconfig.xml");
            while (xml.Read())
            {
                if (xml.Name == "MaxSimTurn")
                {
                    xml.Read();
                    MaxSimTurn = Convert.ToInt32(xml.Value);
                }
                if (xml.Name == "MaxIncubatedNode")
                {
                    xml.Read();
                    MaxIncubatedNode = Convert.ToInt32(xml.Value);
                }
                if (xml.Name == "MaxComparison")
                {
                    xml.Read();
                    MaxComparison = Convert.ToInt32(xml.Value);
                }
                if (xml.Name == "EqualResultMethod")
                {
                    xml.Read();
                    EqualResultMethod = (SortBy)Convert.ToInt32(xml.Value);
                }
            }           
            return new Freyjas_options(MaxSimTurn,MaxIncubatedNode,MaxComparison,EqualResultMethod);
        }      
    }
}
