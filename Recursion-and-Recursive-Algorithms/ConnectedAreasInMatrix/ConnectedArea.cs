namespace ConnectedAreasInMatrix
{
    using System;

    public class ConnectedArea : IComparable
    {
        private const int MinSize = 2;
        private int size;

        public ConnectedArea(int firstRow, int firstCol, int size)
        {
            this.FirstRow = firstRow;
            this.FirstCol = firstCol;
            this.Size = size;
        }

        public int FirstRow { get; set; }

        public int FirstCol { get; set; }      

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < MinSize)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Size cannot be less than {0}", MinSize));
                }

                this.size = value;
            }
        }

        public int CompareTo(object obj)
        {
            ConnectedArea other = (ConnectedArea)obj;
            if (this.Size > other.Size)
            {
                return 1;
            }

            if (this.Size < other.Size)
            {
                return -1;
            }

            if (this.FirstRow < other.FirstRow)
            {
                return 1;
            }

            if (this.FirstRow > other.FirstRow)
            {
                return -1;
            }

            if (this.FirstCol < other.FirstCol)
            {
                return 1;
            }

            if (this.FirstCol > other.FirstCol)
            {
                return -1;
            }

            return 0;
        }
    }
}
