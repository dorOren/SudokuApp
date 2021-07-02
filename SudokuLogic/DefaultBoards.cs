using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class DefaultBoards
    {
        public List<List<MemoryCell>> BoardSetting { get; }

        public Random rand { get; }

        public DefaultBoards() 
        {
            BoardSetting = new List<List<MemoryCell>>();
            rand = new Random();
            getGameSetsFromMemory();
        }

        private void getGameSetsFromMemory()
        {
            BoardSetting.Add(new List<MemoryCell>());
            BoardSetting[0].Add(new MemoryCell(0, 0, 5)); BoardSetting[0].Add(new MemoryCell(0, 1, 3)); BoardSetting[0].Add(new MemoryCell(0, 4, 7))
                ; BoardSetting[0].Add(new MemoryCell(1, 0, 6)); BoardSetting[0].Add(new MemoryCell(1, 3, 1)); BoardSetting[0].Add(new MemoryCell(1, 4, 9)); BoardSetting[0].Add(new MemoryCell(1, 5, 5))
                ; BoardSetting[0].Add(new MemoryCell(2, 1, 9)); BoardSetting[0].Add(new MemoryCell(2, 2, 8)); BoardSetting[0].Add(new MemoryCell(2, 7, 6))
                ; BoardSetting[0].Add(new MemoryCell(3, 0, 8)); BoardSetting[0].Add(new MemoryCell(3, 4, 6)); BoardSetting[0].Add(new MemoryCell(3, 8, 3))
                ; BoardSetting[0].Add(new MemoryCell(4, 0, 4)); BoardSetting[0].Add(new MemoryCell(4, 3, 8)); BoardSetting[0].Add(new MemoryCell(4, 5, 3)); BoardSetting[0].Add(new MemoryCell(4, 8, 1))
                ; BoardSetting[0].Add(new MemoryCell(5, 0, 7)); BoardSetting[0].Add(new MemoryCell(5, 4, 2)); BoardSetting[0].Add(new MemoryCell(5, 8, 6))
                ; BoardSetting[0].Add(new MemoryCell(6, 1, 6)); BoardSetting[0].Add(new MemoryCell(6, 6, 2)); BoardSetting[0].Add(new MemoryCell(6, 7, 8))
                ; BoardSetting[0].Add(new MemoryCell(7, 3, 4)); BoardSetting[0].Add(new MemoryCell(7, 4, 1)); BoardSetting[0].Add(new MemoryCell(7, 5, 9)); BoardSetting[0].Add(new MemoryCell(7, 8, 5))
                ; BoardSetting[0].Add(new MemoryCell(8, 4, 8)); BoardSetting[0].Add(new MemoryCell(8, 7, 7)); BoardSetting[0].Add(new MemoryCell(8, 8, 9));
        }
    }
}
