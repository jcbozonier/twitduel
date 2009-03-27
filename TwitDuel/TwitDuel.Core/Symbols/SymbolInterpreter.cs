using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitDuel.Core.Symbols
{
    internal class SymbolInterpreter
    {
        public bool IsDuelStart(List<Symbol> list)
        {
            var tag = list.Find(symbol => symbol is TagSymbol && ((TagSymbol)symbol).TagName.ToLowerInvariant() == "#contestoftwit");
            var victim = list.Find(symbol => symbol is UserSymbol);

            return tag != null && victim != null;
        }
    }
}
