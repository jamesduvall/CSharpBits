using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace CsharpBits
{
    class WebTools
    {
        //This mess done with a quick script which parsed http://www.web2generators.com/html/entities that page.
        /*private static string[] chars = {"\"", "'", "&", "<", ">", " ", "¡", "¢", "£", "¤", "¥", "¦", "§", "¨", "©", "ª",
                           "«", "¬", "­", "®", "¯", "°", "±", "²", "³", "´", "µ", "¶", "·", "¸", "¹", "º",
                           "»", "¼", "½", "¾", "¿", "×", "÷", "À", "Á", "Â", "Ã", "Ä", "Å", "Æ", "Ç", "È",
                           "É", "Ê", "Ë", "Ì", "Í", "Î", "Ï", "Ð", "Ñ", "Ò", "Ó", "Ô", "Õ", "Ö", "Ø", "Ù",
                           "Ú", "Û", "Ü", "Ý", "Þ", "ß", "à", "á", "â", "ã", "ä", "å", "æ", "ç", "è", "é",
                           "ê", "ë", "ì", "í", "î", "ï", "ð", "ñ", "ò", "ó", "ô", "õ", "ö", "ø", "ù", "ú",
                           "û", "ü", "ý", "þ", "ÿ"};
      private static  string[] escapedHtml = {"&quot;", "&apos;", "&amp;", "&lt;", "&gt;", "&nbsp;", "&iexcl;", "&cent;", "&pound;",
                                   "&curren;", "&yen;", "&brvbar;", "&sect;", "&uml;", "&copy;", "&ordf;", "&laquo;",
                                   "&not;", "&shy;", "&reg;", "&macr;", "&deg;", "&plusmn;", "&sup2;", "&sup3;", "&acute;",
                                   "&micro;", "&para;", "&middot;", "&cedil;", "&sup1;", "&ordm;", "&raquo;", "&frac14;",
                                   "&frac12;", "&frac34;", "&iquest;", "&times;", "&divide;", "&Agrave;", "&Aacute;",
                                   "&Acirc;", "&Atilde;", "&Auml;", "&Aring;", "&AElig;", "&Ccedil;", "&Egrave;", "&Eacute;",
                                   "&Ecirc;", "&Euml;", "&Igrave;", "&Iacute;", "&Icirc;", "&Iuml;", "&ETH;", "&Ntilde;",
                                   "&Ograve;", "&Oacute;", "&Ocirc;", "&Otilde;", "&Ouml;", "&Oslash;", "&Ugrave;",
                                   "&Uacute;", "&Ucirc;", "&Uuml;", "&Yacute;", "&THORN;", "&szlig;", "&agrave;", "&aacute;",
                                   "&acirc;", "&atilde;", "&auml;", "&aring;", "&aelig;", "&ccedil;", "&egrave;", "&eacute;",
                                   "&ecirc;", "&euml;", "&igrave;", "&iacute;", "&icirc;", "&iuml;", "&eth;", "&ntilde;", "&ograve;",
                                   "&oacute;", "&ocirc;", "&otilde;", "&ouml;", "&oslash;", "&ugrave;", "&uacute;", "&ucirc;", "&uuml;",
                                   "&yacute;", "&thorn;", "&yuml;"};
      //Turns out this wasn't enough. Stole some more from http://www.eggheadcafe.com/tutorials/aspnet/ca7f59b0-e086-4974-9130-3210625e675c/html-entities-class.aspx . Stealing is okay if I link him in the comments which get optimized out, right? :P
         */
         
        //FFFFFFFFUUUUUUUUU, turns out HtmlAgilityPack already had a method for this. Derpa derpa derpa. Let's use that instead.

        public static string HtmlEncode(string s)
        {
            return HtmlEntity.Entitize(s);
        }

        public static string HtmlDecode(string s)
        {
            return HtmlEntity.DeEntitize(s);
        }
    }
}
