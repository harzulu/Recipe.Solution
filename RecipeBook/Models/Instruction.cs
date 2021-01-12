using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Instruction
    {
        public Instruction()
        {
        }

        public int InstructionId { get; set; }
        public string Blurb { get; set; }
    }
}