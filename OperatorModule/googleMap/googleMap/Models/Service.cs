using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using googleMap.Models.Database;
using System.Net;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Configuration;

namespace googleMap.Models
{
    public class Service
    {
        public static Coe25dbDataContext db = new Coe25dbDataContext();
            
        public static string GetAllStringLocation()
        {
            int count = 0; 
            string StringLocation = string.Empty;
            try
            {
            
                List<tbl_Cluster> clusters = getAllCluster();
                if (clusters.Count > 0)
                {
                    foreach (tbl_Cluster cluster in clusters){
                        List<tbl_Post> posts = getAllPost(cluster.ID);

                        foreach (tbl_Post post in posts){
                            tbl_Map maps = getMapByPostID(post.ID);
                            if (maps != null)
                            {
                                ///Check if ang map naay wa pa na fix na session.
                                if (!CheckIfNeedToFix(post.ID))
                                    StringLocation += string.Format("{0},{1},{2},{3};", post.PostName, maps.Latitude, maps.Longitude, count); 
                                else
                                    StringLocation += string.Format("NeedtoFix,{0},{1},{2},{3};", post.PostName, maps.Latitude, maps.Longitude, count); 
                                count++; 
                            }
                        }
                    }
                }
            }
            catch
            {
                StringLocation = "";
            }
            return StringLocation;
        }

        public static bool CheckIfNeedToFix(int PostID)
        {
            bool flag = false;
            List<tbl_History> historypost = new List<tbl_History>();
            try
            {
                historypost = (from m in db.tbl_Histories
                               where m.PostID == PostID &&
                                     m.IsFixed == false
                               select m).ToList();
                if (historypost.Count > 0)
                    flag = true;
            }
            catch { }
            return flag;
        }

        public static List<tbl_Cluster> getAllCluster()
        {
            List<tbl_Cluster> clusters = new List<tbl_Cluster>();
            try
            {
                clusters = (from m in db.tbl_Clusters
                            select m).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return clusters;
        }

        public static List<tbl_Post> getAllPost(int ID)
        {
            List<tbl_Post> posts = new List<tbl_Post>();
            try
            {
                posts = (from m in db.tbl_Posts
                         where m.Cluster == ID
                         select m).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return posts;
        }

        public static tbl_Map getMapByPostID(int PostID)
        {
            return db.tbl_Maps.FirstOrDefault(p => p.PostID == PostID);
        }

        public static List<tbl_Map> getAllMap(int ID)
        {
            List<tbl_Map> maps = new List<tbl_Map>();
            try
            {
                maps = (from m in db.tbl_Maps
                        where m.PostID == ID
                        select m).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return maps;
        }

        public static tbl_Cluster HasTbl_Post(string UniqueCode)
        {
            tbl_Cluster cluster = new tbl_Cluster();
            try
            {
                cluster = (from m in db.tbl_Clusters
                           where m.UniqueCode == UniqueCode
                           select m).SingleOrDefault();
                if (cluster != null)
                {
                }
            }
            catch { cluster = null; }
            return cluster;
        }

        public static void Insert_Post(int ClusterID, string PostName, string PostSerialNumber)
        {
            try
            {
                tbl_Post post = new tbl_Post();
                post.PostName = PostName;
                post.PostSerialNumber = PostSerialNumber;
                post.Cluster = ClusterID;
                post.CreateDate = DateTime.UtcNow;
                db.tbl_Posts.InsertOnSubmit(post);
                db.SubmitChanges();
            }
            catch { }

        }

        public static void Insert_Map(string Lat, string Long, string PostSerialNumber)
        {
            try
            {
                tbl_Post post = getPostByPostSerialNumber(PostSerialNumber);
                if (post != null)
                {
                    tbl_Map map = new tbl_Map();
                    map.Latitude = Lat;
                    map.Longitude = Long;
                    map.PostID = post.ID;
                    map.CreateDate = DateTime.UtcNow;
                    db.tbl_Maps.InsertOnSubmit(map);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex){
                throw ex;
            }
        }

        public static tbl_Post getPostByPostSerialNumber(string SerialNumber)
        {
            try
            {
                return db.tbl_Posts.SingleOrDefault(s => s.PostSerialNumber == SerialNumber);
            }
            catch { }
            return null;
        }

        public static string GetLocation(string Lat, string Long)
        {
            string Base_URL = "http://maps.google.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
            string URL = string.Format(Base_URL, Lat, Long);
            XElement Result = XElement.Parse(ServiceRequest.GetRequest(URL));
            string Location = string.Empty;
            try
            {
                if (Result.HasElements)
                    Location = Result.Element("result").Element("formatted_address").Value;
            }
            catch
            {
                Location = "";
            }
            return Location;
        }

        public static string GenerateSerialNumber()
        {
            string serialNumber = (from m in db.tbl_Posts
                                   orderby m.ID descending
                                   select m.PostSerialNumber ).FirstOrDefault();
            if (!string.IsNullOrEmpty(serialNumber))
            {
                int serial = int.Parse(serialNumber);
                serial++;
                return serial.ToString(); 
            }
            return "";
        }

    }

    public static class ServiceRequest
    {
        public static string GetRequest(string url)
        {
            string ResponseMsg = string.Empty;
            try
            {
                Uri address = new Uri(url);
                //Get HttpWebRequest
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                //Get HttpWebResponse
                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(resp.GetResponseStream(), ASCIIEncoding.ASCII);
                    // Console application output  
                    ResponseMsg = reader.ReadToEnd().ToString();
                    resp.Close();
                }
            }
            catch (WebException ex)
            {
                string message = ((System.Net.HttpWebResponse)(ex.Response)).StatusDescription;
                if (message.Contains("Error"))
                {
                    return string.Empty;
                }
                else
                {
                    throw new Exception(message);
                }
            }
            return ResponseMsg;
        }
    }
}