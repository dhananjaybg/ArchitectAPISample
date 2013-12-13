using System;
using System.IO;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Xml;
using System.Text;
using System.IO.Compression;



namespace EdwardsApp1
{
    class Program
    {

        static Boolean update_xml(string read_topic , string param_file, string[] par_pas)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(param_file);

            for (int i = 0; i < par_pas.Length; i += 2)
            {
                //Console.WriteLine("Update Label Name:" + par_pas[i] + "Label Value: " + par_pas[i+1]);

                XmlElement elem = doc.CreateElement("variable");
                elem.InnerText = par_pas[i + 1];
                doc.DocumentElement.AppendChild(elem);

                XmlAttribute newAttribute = doc.CreateAttribute("name");
                newAttribute.Value = par_pas[i];                    
                elem.Attributes.Append(newAttribute);
            }

            doc.Save(read_topic);            

            return true;
        }

        string EDT = "EDTXML";
        string Base64Data = "";

        //public void Save(string filepath, XmlReader reader)
        static void Save(string filepath,string sType, string Base64Str )
        {
            //if (this.EDT.Equals("EDTXML"))
            if (sType.Equals("EDTXML"))
            {
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                XmlReaderSettings settings = new XmlReaderSettings();                
                settings.XmlResolver = null;
                settings.DtdProcessing = DtdProcessing.Ignore;

                XmlReader reader = XmlReader.Create(new MemoryStream(Convert.FromBase64String(Base64Str)),settings);

                doc.Load(reader);

                if (doc.DocumentType != null)
                {
                    //Replace the SystemID by the full path to the DTD on the server filesystem
                    //Similar to webclient UI checkbox 'Alter DTD System ID location' in the ouput format definition
                    XmlDocument fixdoc = new XmlDocument();
                    fixdoc.PreserveWhitespace = true;
                    fixdoc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                    //fixdoc.AppendChild(fixdoc.CreateDocumentType(doc.DocumentElement.Name, doc.DocumentType.PublicId, reader.GetUrn(doc.DocumentType.PublicId), null));
                    fixdoc.AppendChild(fixdoc.CreateDocumentType(doc.DocumentElement.Name, doc.DocumentType.PublicId, "", null));
                    fixdoc.AppendChild(fixdoc.ImportNode(doc.SelectSingleNode("processing-instruction()"), false));
                    fixdoc.AppendChild(fixdoc.ImportNode(doc.DocumentElement, true));
                    fixdoc.Save(filepath);
                }
                else
                    doc.Save(filepath);
            }
            else                
                File.WriteAllBytes(filepath, Convert.FromBase64String(Base64Str));
        }

        static void makeZip()
        {
            string startPath = @"c:\temp\edwards_out";
            string zipPath = @"c:\temp\edwards_out\result.zip";

                        
            
            //ZipFile.CreateFromDirectory(startPath, zipPath);
        }

        static void Main(string[] args)
        {

            string userName = "admin";
            string password = "admin";
            //string param_file = "C://Dev//JDEdwards//EdwardsApp1//EdwardsApp1//Input_XML_SAMPLE.XML";
            string param_file = "Input_XML_SAMPLE.XML";

            try
            {
                // Create proxy instance
                Application25ServiceReference.ApplicationClient applicationClient = new Application25ServiceReference.ApplicationClient();
                applicationClient.ClientCredentials.UserName.UserName = userName;
                applicationClient.ClientCredentials.UserName.Password = password;

                // Execute the GetVersion call
                string version = applicationClient.GetVersion();
                Console.WriteLine(" **************************************************** ");
                Console.WriteLine(" Connected to SDL LiveContent Architect: " + version);
                Console.WriteLine(" **************************************************** ");
                
                // Create proxy instance
                User25ServiceReference.UserClient userClient = new User25ServiceReference.UserClient();
                userClient.ClientCredentials.UserName.UserName = userName;
                userClient.ClientCredentials.UserName.Password = password;

                DocObj25ServiceReference.DocumentObjClient docObj = new DocObj25ServiceReference.DocumentObjClient();
                docObj.ClientCredentials.UserName.UserName = userName;
                docObj.ClientCredentials.UserName.Password = password;                                               
                
                string[] ids =  {"GUID-9637F419-5935-4BC7-91D4-934649D568AD"}; //library Symbols Edwards


                string[] lang_ids =  { "en" };                
                //string str_xml_metaData = "<ishfields><ishfield name='VERSION' level='version'>1</ishfield></ishfields>";
                string str_xml_metaData = "";                
                string str_prod_defn = "";
                string str_req_meta = "<ishfields><ishfield name='VERSION' level='version'/><ishfield name='FAUTHOR' level='lng'/><ishfield name='FSTATUS' level='lng'/></ishfields>";
                
                string data_str = docObj.RetrieveObjects(ids,DocObj25ServiceReference.StatusFilter.ISHReleasedOrDraftStates, str_xml_metaData, str_prod_defn, str_req_meta);
                //Console.WriteLine("\n--------DATA_STR ---->\n" + data_str);
                char[] bekaar = new Char[] { '[', ']' };
                string[] data_str_brokenup = data_str.Split(bekaar);                
                //Console.WriteLine("\n------------>\n" + data_str_brokenup[2]);
                string read_topic = "C:\\temp\\Edwards_out\\EdwardsVariables.xml";

                string EdwardsDemo_OUT = "C:\\temp\\Edwards_out\\DEMO_OUTPUT_XML_SAMPLE.xml";

                Save(read_topic, "EDTXMLR", data_str_brokenup[2]);

                
                string[] var_args = { "lblQuantity_Alt", "Qty", "iQuantity", "iQuantity=GUID-ED31F2B5-4FD1-454E-8268-77EAD6556E88=1=en=Low.png", "lblDoNotFreeze_Alt", "Caution: Do not freeze. Store between 10°C and 25°C", "iDoNotFreeze", "iDoNotFreeze=GUID-CD85FFD7-370F-4375-B5BA-96E7BA3AB212=1=en=Low.png", "lblEthyleneOxideSterilized_Alt", "Sterilized Using Ethylene Oxide", "iEthyleneOxideSterilized", "iEthyleneOxideSterilized=GUID-DE27047A-0DA6-4565-AB9D-620C6337E64C=1=en=Low.png", "lblDoNotUse", "Do not use if package is opened or damaged", "iDoNotUse", "iDoNotUse=GUID-31102BC1-7ED7-4762-B3B5-9C0C89EB9E11=1=en=Low.png" };

                Boolean arv = update_xml(EdwardsDemo_OUT, param_file, var_args);

                Console.WriteLine(" Exporting  Labels and Assets @ location : " + read_topic);                              

                Console.WriteLine(" Exporting  DEMO_OUTPUT_XML_SAMPLE.xml to : " + EdwardsDemo_OUT);                              
                                
                //Export the images 
               
                string[] img_assets = { "iQuantity=GUID-ED31F2B5-4FD1-454E-8268-77EAD6556E88=1=en=Low.png", "iDoNotFreeze=GUID-CD85FFD7-370F-4375-B5BA-96E7BA3AB212=1=en=Low.png", "iEthyleneOxideSterilized=GUID-DE27047A-0DA6-4565-AB9D-620C6337E64C=1=en=Low.png","iDoNotUse=GUID-31102BC1-7ED7-4762-B3B5-9C0C89EB9E11=1=en=Low.png" };
                
               foreach (string s in img_assets)
                {
                   
                    string[] var_store = s.Split('=');
                    string read_img = "c:\\temp\\Edwards_out\\" + s;
                    string[] l_ids = { var_store[1] };
                   
                    string l_str_xml_metaData = "";
                    string l_str_prod_defn = "";
                    string l_str_req_meta = "<ishfields><ishfield name='VERSION' level='version'/><ishfield name='FAUTHOR' level='lng'/><ishfield name='FSTATUS' level='lng'/></ishfields>";

                    string l_data_str = docObj.RetrieveObjects(l_ids, DocObj25ServiceReference.StatusFilter.ISHReleasedOrDraftStates, l_str_xml_metaData, l_str_prod_defn, l_str_req_meta);
                    char[] l_bekaar = new Char[] { '[', ']' };
                    string[] l_data_str_brokenup = l_data_str.Split(l_bekaar);


                    Save(read_img, "EDTPNG", l_data_str_brokenup[2]);

                    
                }
                               
                Console.WriteLine(" Exporting Image Assets to : c:\\temp\\Edwards_out\\");
                Console.WriteLine(" ****************************************** ");

                /*
                 * @djay : use this when u have to gab a bunch in one call
                 * 
                string[] img_assets = { "GUID-ED31F2B5-4FD1-454E-8268-77EAD6556E88", "GUID-CD85FFD7-370F-4375-B5BA-96E7BA3AB212", "GUID-DE27047A-0DA6-4565-AB9D-620C6337E64C", "GUID-31102BC1-7ED7-4762-B3B5-9C0C89EB9E11" };
                
                string l_str_xml_metaData = "";
                string l_str_prod_defn = "";
                string l_str_req_meta = "<ishfields><ishfield name='VERSION' level='version'/><ishfield name='FAUTHOR' level='lng'/><ishfield name='FSTATUS' level='lng'/></ishfields>";

                string l_data_str = docObj.RetrieveObjects(img_assets, DocObj25ServiceReference.StatusFilter.ISHReleasedOrDraftStates, l_str_xml_metaData, l_str_prod_defn, l_str_req_meta);

                Console.Write( l_data_str );

                //char[] l_bekaar = new Char[] { '[', ']' };
                //string[] l_data_str_brokenup = l_data_str.Split(l_bekaar);
*/


                
            }
            //Catch all Application25 server exceptions that are generated after the request has been validated on the server and executes.
            catch (FaultException<Application25ServiceReference.InfoShareFault> fex)
            {
                Console.WriteLine("API25 FaultException: {0}", fex);
                Console.WriteLine("Action: {0}", fex.Action);
                Console.WriteLine("Reason: {0}", fex.Reason);
                Console.WriteLine("Description: {0}", fex.Detail.Description);
                Console.WriteLine("InfoShareErrorNumber: {0}", fex.Detail.InfoShareErrorNumber);
                Console.WriteLine("Origin: {0}", fex.Detail.Origin);
                Console.WriteLine("XMLDetail: {0}", fex.Detail.XMLDetail);
            }
            //Catch all User25 server exceptions that are generated after the request has been validated on the server and executes.
            catch (FaultException<User25ServiceReference.InfoShareFault> fex)
            {
                Console.WriteLine("User25 FaultException: {0}", fex);
                Console.WriteLine("Action: {0}", fex.Action);
                Console.WriteLine("Reason: {0}", fex.Reason);
                Console.WriteLine("Description: {0}", fex.Detail.Description);
                Console.WriteLine("InfoShareErrorNumber: {0}", fex.Detail.InfoShareErrorNumber);
                Console.WriteLine("Origin: {0}", fex.Detail.Origin);
                Console.WriteLine("XMLDetail: {0}", fex.Detail.XMLDetail);
            }
            //Catch all server exception that are generated before the request has been validated on the server and executes.
            //e.g. Token validation
            catch (FaultException fex)
            {
                Console.WriteLine("FaultException: {0}", fex);
                Console.WriteLine("Action: {0}", fex.Action);
                Console.WriteLine("Reason: {0}", fex.Reason);
            }
            //Catch the test
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Press any key...");
                Console.ReadLine();
            }




        }
    }
}
