using Parcel_Sorting_line;
using System;
using System.Collections.Generic;
using Xunit;

namespace Parcing_line_Test
{
    public class UnitTest1
    {
        [Fact]
        public void When_ParcelHasNewDimensionsAndSortingLineHasNewDimensions_Then_CanFitSortingLine()
        {
            var boxSizes = new List<BoxSize>()
            {
                new BoxSize
                {
                    Lenght = 100,
                    Width = 50,
                    SortingLineParams = new List<SortingLineParam>
                    {
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
                            LineWidth = 90
                        }
                    }
                }
            };
        bool result = Program.FirstParceLine(boxSizes);

            Assert.True(result);
        }
    }
}
