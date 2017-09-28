using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace clientprj.Domain.Util
{
    public static class Telefone
    {

        public static Boolean ValidaTelefone(string telefone)
        {
            var regex = new Regex(@"^[1-9]{2}\-[2-9][0-9]{3,4}\-[0-9]{4}$");
            Match match = regex.Match(telefone);
            return match.Success;
        }
    }
}