using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Mahzan.Models.Enums.Taxes
{

    public enum TaxTypeEnum
    {

        INCLUDED_IN_PRICE,

        ADD_IN_PRICE
    }
}
