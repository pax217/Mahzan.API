using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mahzan.Facturacion.Electronica.Utils
{
    public class StringWriterWithEncoding:StringWriter
    {
        private readonly Encoding m_Encoding;

        public override Encoding Encoding 
        {
            get 
            {
                return this.m_Encoding;
            }
        }

        public StringWriterWithEncoding(Encoding encoding):base() 
        {
            this.m_Encoding = encoding;
        }


    }
}
