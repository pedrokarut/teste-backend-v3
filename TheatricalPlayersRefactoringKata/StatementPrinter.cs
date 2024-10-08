﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    public List<string> resultXML { get; set; }
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var totalAmount = 0;
        var volumeCredits = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");
        var valorComedy = 0;
        var valorTragedy = 0;
        var valorHistory = 0;

        foreach(var perf in invoice.Performances) 
        {
            var play = plays[perf.PlayId];
            var lines = play.Lines;
            if (lines < 1000) lines = 1000;
            if (lines > 4000) lines = 4000;
            var thisAmount = lines * 10;
            switch (play.Type) 
            {
                case "tragedy":
                    if (perf.Audience > 30) {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }
                    valorTragedy += thisAmount;
                    break;
                case "comedy":
                    if (perf.Audience > 20) {
                        thisAmount += 10000 + 500 * (perf.Audience - 20);
                    }
                    thisAmount += 300 * perf.Audience;
                    valorComedy += thisAmount;
                    break;
                case "history":
                    valorHistory = valorComedy + valorTragedy;
                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }
            // add volume credits
            volumeCredits += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);

            // print line for this order
            result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
            totalAmount += (play.Type == "history" ? valorHistory : thisAmount);
        }
        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        result += String.Format("You earned {0} credits\n", volumeCredits);
        //resultXML = result;
        return result;
    }

    public string GeraXML()
    {
        XmlConvert xmlConvert = new XmlConvert();
        return xmlConvert.ToString();
    }

    
}
