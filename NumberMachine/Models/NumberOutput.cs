using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberMachine.Models
{
    public class NumberOutput
    {
        public int ID { get; set; }
        public int InputID { get; set; }
        public int Operation { get; set; }
        public int Output { get; set; }

        public virtual NumberInput Input { get; set; }
    }
}
