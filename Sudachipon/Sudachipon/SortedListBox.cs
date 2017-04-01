using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudachipon
{
    class SortedListBox : System.Windows.Forms.ListBox
    {
        protected override void Sort()
        {
            // アイテム数が2個以上でなければ終了
            if (Items.Count <= 1)
            {
                return; 
            }

            bool swapped;
            do
            {
                int counter = Items.Count - 1;
                swapped = false;

                while (counter > 0)
                {
                    DbAccessor.UserMaster umA = (DbAccessor.UserMaster)Items[counter];
                    DbAccessor.UserMaster umB = (DbAccessor.UserMaster)Items[counter-1];
                    if (umA.id < umB.id)
                    {
                        Object tmp = Items[counter];
                        Items[counter] = Items[counter - 1];
                        Items[counter - 1] = tmp;
                        swapped = true;
                    }
                    counter -= 1;
                }
            }
            while (swapped);
        }
    }
}
