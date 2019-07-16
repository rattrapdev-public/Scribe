using RattrapDev.Scribe.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScribe.Customer
{
    [Entity("Test Entity", "A test entity")]
    public class TestEntity
    {
        public Name Name { get; set; }

        [CommandMethod("Command", "Command Definition")]
        internal void Command()
        {

        }
    }
}
