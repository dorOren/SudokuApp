using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public struct MemoryCell
    {
        public int colIndex { get; set; }
        public int RowIndex { get; set; }
        public int Value { get; set; }

        public MemoryCell(int i_RowIndex, int i_ColIndex, int i_Value)
        {
            Value = i_Value;
            RowIndex = i_RowIndex;
            colIndex = i_ColIndex;
        }
    }
}
