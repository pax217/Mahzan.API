using Mahzan.Facturacion.Electronica.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Mahzan.Facturacion.Electronica
{
    class Program
    {
        static string pathXML = @"C:\GitHub\Mahzan.API\tools\Mahzan.Facturacion.Electronica\";
        static string fileXML = @"MiPrimerXml.xml";

        static void Main(string[] args)
        {


            //Obtener numero cetificado
            string pathCer = @"C:\GitHub\Mahzan.API\tools\Mahzan.Facturacion.Electronica\30001000000400002335.cer";
            string pathKey = @"C:\GitHub\Mahzan.API\tools\Mahzan.Facturacion.Electronica\CSD_XOCHILT_CASAS_CHAVEZ_CACX7605101P8_20190528_173544.key";
            string clavePrivada = "12345678a";

            //Obtener el número 
            string numeroCetificado, aa, bb, c;

            SelloDigital.leerCER(pathCer, out aa, out bb, out c, out numeroCetificado);


            Comprobante comprobante = new Comprobante();
            comprobante.Version = "3.3"; /* Requerido */
            comprobante.Serie = "H";  /*Cuando las emisiones de facturas de Emisiones por servicios 1 a 25 caracteres, dato interno de la empresa */
            comprobante.Folio = "1";
            comprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            comprobante.FormaPago = c_FormaPago.Item01;
            comprobante.NoCertificado = numeroCetificado;
            comprobante.SubTotal = 10.80M;
            comprobante.Descuento = 1;
            comprobante.Moneda = c_Moneda.MXN;
            comprobante.Total = 9.80M;
            comprobante.TipoDeComprobante = c_TipoDeComprobante.I;
            comprobante.MetodoPago = c_MetodoPago.PUE;
            /*Lugar de Expedición*/

            ComprobanteEmisor emisor = new ComprobanteEmisor();
            emisor.Rfc = "CAMD8806188RA";
            emisor.Nombre = "Carlos Alberto Maldonado Díaz";
            emisor.RegimenFiscal = c_RegimenFiscal.Item605;

            ComprobanteReceptor receptor = new ComprobanteReceptor();
            receptor.Nombre = "Nombre del Cliente";
            receptor.Rfc = "CAMD8806188RA";



            /*Lista de Conceptos*/
            List<ComprobanteConcepto> listConceptos = new List<ComprobanteConcepto>();
            ComprobanteConcepto comprobanteConcepto = new ComprobanteConcepto();
            comprobanteConcepto.Descripcion = "Crema Libriderm 400 ml.";
            comprobanteConcepto.Cantidad = 1;
            comprobanteConcepto.Importe = 95.50M;
            comprobanteConcepto.Unidad = "PZA";
            comprobanteConcepto.ValorUnitario = 95.50M;
            comprobanteConcepto.Descuento = 1;

            listConceptos.Add(comprobanteConcepto);

            //Asignaciones

            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;
            comprobante.Conceptos = listConceptos.ToArray();

            //Crea XML Cadena Original
            XML(comprobante);

            string cadenaOriginal = "";
            string pathxsl = pathXML + @"cadenaoriginal_3_3.xslt";

            XslCompiledTransform transformador = new XslCompiledTransform(true);
            XsltSettings sets = new XsltSettings(true, true);
            var resolver = new XmlUrlResolver();
            transformador.Load(pathxsl, sets, resolver);

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw, transformador.OutputSettings))
                {
                    transformador.Transform(pathXML + fileXML, xw);
                    cadenaOriginal = sw.ToString();
                }
            }

            SelloDigital selloDigital = new SelloDigital();
            comprobante.Certificado = selloDigital.Certificado(pathCer);
            comprobante.Sello = selloDigital.Sellar(cadenaOriginal,pathKey,clavePrivada);

            //Crea Sellado
            XML(comprobante);
        }

        private static void XML(Comprobante comprobante)
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlSerializerNamespaces.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Comprobante));



            string xml = string.Empty;

            using (var sw = new StringWriterWithEncoding(Encoding.UTF8))
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xmlSerializer.Serialize(writer, comprobante, xmlSerializerNamespaces);
                    xml = sw.ToString();
                }
            }

            File.WriteAllText(pathXML + fileXML, xml);
        }

    }
}
