﻿using System;
using System.Collections.Generic;

namespace Parcel_Sorting_line
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FirstParceLine(BoxSizes);
        }

        public static bool FirstParceLine(List<BoxSize> boxSizes)
        {
            bool parcelFits = false;

            foreach (BoxSize box in boxSizes)
            {
                Console.WriteLine("New sorting line starts");

                var boxLengthInHalf = box.Lenght / 2;
                var halfBoxDiagonalNotSqrt = (boxLengthInHalf * boxLengthInHalf) + (box.Width * box.Width);
                var halfParceDiagonal = Math.Sqrt(halfBoxDiagonalNotSqrt);

                var lineWidth = 0;

                foreach (SortingLineParam sortingLine in box.SortingLineParams)
                {
                    var sortingLineNotSqrt  = (sortingLine.LineWidth * sortingLine.LineWidth) + (lineWidth * lineWidth);
                    var cornerDiagonal = Math.Sqrt(sortingLineNotSqrt);

                    if (sortingLine.LineWidth >= halfParceDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }

                    else if (box.Width >= halfParceDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }

                    else if (box.Lenght <= sortingLine.LineWidth)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }

                    else if (box.Width >= sortingLine.LineWidth)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }

                    /*else if (box.Width >= halfParceDiagonal && sortingLine.LineWidth >= halfParceDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }*/

                    else if (sortingLine.LineWidth <= halfParceDiagonal && lineWidth >= halfParceDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }

                    else if (sortingLine.LineWidth <= halfParceDiagonal && sortingLine.LineWidth >= cornerDiagonal)
                    {
                        parcelFits = sortingLine.LineWidth <= halfParceDiagonal && sortingLine.LineWidth >= cornerDiagonal;

                        var result = parcelFits
                            ? "Sorting line width " + sortingLine.LineWidth + " and it fits " : "It doesnt fit to the sorting line and need to be wider";
                        Console.WriteLine(result);
                    }

                    else
                    {
                        Console.WriteLine("It doesn't fit to the sorting line and needs to be wider");
                    }

                    lineWidth = sortingLine.LineWidth;
                }
            }

            return parcelFits;
        }

        public static readonly List<BoxSize> BoxSizes = new List<BoxSize>
        {
            new BoxSize
            {
                Lenght = 120,
                Width = 60,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 100
                    },
                    new SortingLineParam
                    {
                        LineWidth = 75
                    }
                }
            },

            new BoxSize
            {
                Lenght = 100,
                Width = 35,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 75
                    },
                    new SortingLineParam
                    {
                        LineWidth = 50
                    },
                    new SortingLineParam
                    {
                        LineWidth = 80
                    },
                    new SortingLineParam
                    {
                        LineWidth = 100
                    },
                    new SortingLineParam
                    {
                        LineWidth = 37
                    }
                }
            },

            new BoxSize
            {
                Lenght = 70,
                Width = 50,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 60
                    },
                    new SortingLineParam
                    {
                        LineWidth = 60
                    },
                    new SortingLineParam
                    {
                        LineWidth = 55
                    },
                    new SortingLineParam
                    {
                        LineWidth = 90
                    }
                }
            }
        };
    }

    public class BoxSize
    {
        public int Lenght { get; set; }
        public int Width { get; set; }
        public List<SortingLineParam> SortingLineParams { get; set; } = new List<SortingLineParam>();
    }

    public class SortingLineParam
    {
        public int LineWidth { get; set; }
    }
}
