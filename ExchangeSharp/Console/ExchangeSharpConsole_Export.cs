﻿/*
MIT LICENSE

Copyright 2017 Digital Ruby, LLC - http://www.digitalruby.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ExchangeSharp
{
    public static partial class ExchangeSharpConsole
    {
        public static void RunExportData(Dictionary<string, string> dict)
        {
            RequireArgs(dict, "exchange", "symbol", "path", "sinceDateTime");
            string exchange = dict["exchange"];
            long total = 0;
            TraderExchangeExport.ExportExchangeTrades(ExchangeAPI.GetExchangeAPI(exchange), dict["symbol"], dict["path"], DateTime.Parse(dict["sinceDateTime"]), (long count) =>
            {
                total = count;
                Console.Write("Exporting {0}: {1}     \r", exchange, total);
            });
            Console.WriteLine("{0}Finished Exporting {1}: {2}     \r", Environment.NewLine, exchange, total);
        }
    }
}