using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NocdeskFirstLevalApi.DataAccessLayer
{
    public class NocDeskCommon
    {
        //public static string logPath = "";Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\AssertYIT\\OwnYITHRMS\\Log";
        public static string logPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\AssertYIT\\NocdeskMicroservice\\";
        public String strOSType = "";
        public static string LINUX_WWW_PATH = "";
        public NocDeskCommon()
        {
            strOSType = readOSType();
        }
        public string readDBConfig(string Item, string OSType, string LinuxFileName, string WindowsFileName)
        {
            string _dbSettings = "";
            if (OSType.ToUpper() == "LINUX")
            {
                _dbSettings = NocDeskCommon.LINUX_WWW_PATH + LinuxFileName;
            }
            else
            {
                _dbSettings = systemcheck() + "\\AssertYIT\\Configuration\\" + WindowsFileName;
            }
            string retVal = "";
            DataSet ds = new DataSet("DataSet");
            try
            {
                ds.ReadXml(_dbSettings);
                retVal = ds.Tables["Config"].Rows[0][Item].ToString();
            }
            catch (Exception ex)
            {
                //WriteLog("Exception", "Exception while read DB Configuration : " + ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return retVal;
        }
        public string readOSType()
        {
            string xmlPath = Directory.GetCurrentDirectory() + "/wwwroot/xml/OSType.xml";
            string retVal = "";
            DataSet ds = new DataSet("DataSet");
            try
            {
                ds.ReadXml(xmlPath);
                retVal = ds.Tables["Config"].Rows[0]["ostype"].ToString();
            }
            catch (Exception ex)
            {
                retVal = "Linux";
                //WriteLog("Exception", "Exception while read DB Configuration : " + ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return retVal;
        }
        public string systemcheck()
        {
            string _systemPath = "";
            if (Is64BitSystem())
                _systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System).ToUpper().Replace("SYSTEM32", "SysWOW64");
            else
                _systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System).ToUpper().Replace("SysWOW64", "SYSTEM32");
            return _systemPath;
        }
        public bool Is64BitSystem()
        {
            return (Environment.GetEnvironmentVariable("ProgramFiles(x86)")) != null;
        }
        //public void WriteLog(string strFileName, string strMessage)
        //{
        //    try
        //    {
        //        if (strOSType.ToUpper() == "LINUX")
        //        {
        //            logPath = "/var/log/OwnYITHRMS/log";
        //        }
        //        else
        //        {
        //            //logPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\AssertYIT\\OwnYITHRMS\\Log";
        //            logPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\AssertYIT\\NocdeskMicroservice\\FirstLeval";

        //        }
        //        Console.WriteLine("Path : " + LINUX_WWW_PATH);
        //        if (!System.IO.Directory.Exists(logPath)) System.IO.Directory.CreateDirectory(logPath);
        //        FileStream fs;
        //        strFileName = logPath + "/" + strFileName + ".log";
        //        Console.WriteLine("File : " + strFileName);
        //        fs = new FileStream(strFileName, FileMode.Append);
        //        StreamWriter s = new StreamWriter(fs);
        //        s.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : " + strMessage);
        //        s.Close();
        //        fs.Close();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        public void WriteLog(string FileName, string Extension, string ProductName, string Message, bool HourWise)
        {
            try
            {
                if (strOSType.ToUpper() == "LINUX")
                {
                    logPath = "/var/log/OwnYITHRMS/log";
                }
                else
                {
                    logPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\AssertYIT\\NocdeskMicroservice\\";

                }
                if (HourWise)
                    FileName = FileName + "_" + System.DateTime.Now.ToString("yyyy-MM-dd HH") + "." + Extension;
                else
                    FileName = FileName + "." + Extension;
                FileName = logPath + ProductName + "\\" + FileName;
                if (!Directory.Exists(logPath + ProductName))
                    Directory.CreateDirectory(logPath + ProductName);
                FileStream fs;
                fs = new FileStream(FileName, FileMode.Append);
                StreamWriter s = new StreamWriter(fs);
                s.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : " + Message);
                s.Close();
                fs.Close();
            }
            catch (Exception)
            {
            }
        }

        //public DataSet xmlToDataset(string strXML)
        //{
        //    DataSet DS = new DataSet();
        //    try
        //    {
        //        XmlDocument xmltest = new XmlDocument();
        //        xmltest.LoadXml(strXML);
        //        XmlNodeReader xmlnr = new XmlNodeReader(xmltest);

        //        DS.ReadXml(xmlnr);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return DS;
        //}
    }
}
