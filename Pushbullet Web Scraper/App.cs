using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Pushbullet_Web_Scraper {
    public class App {
        // Websites
        public static List<WebsiteSettings> Websites;
        public static List<WebsiteTemporarySettings> WebsitesTemp;

        public static void Main(string[] args) {
            // Read settings from disk
            ReadSettings();

            // Check each website for new stuff
            foreach (var website in Websites) {
                // Try to find last status (if it exists)
                var lastStatus = WebsitesTemp.FirstOrDefault(x => x.Id == website.Id);

                // Retrieve page
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.GetEncoding(website.Encoding);
                HtmlDocument doc = web.Load(website.Url);

                // Parse announcemets
                var node = doc.DocumentNode.SelectNodes(website.Xpath);

                if (node != null) { // If the node eixsts
                    string noHTML = Regex.Replace(node[0].InnerText, @"<[^>]+>|&nbsp;", "").Trim();
                    string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");

                    // Check if it's new
                    if (lastStatus != null) {
                        if (lastStatus.LastAnnouncement == noHTMLNormalised) continue;
                        lastStatus.LastAnnouncement = noHTMLNormalised;

                        PushbulletApi.PushLink(website.Name, noHTMLNormalised, website.Url, website.PushbulletKey, website.ChannelTag);
                    } else {
                        WebsiteTemporarySettings temp = new WebsiteTemporarySettings();
                        temp.Id = website.Id;
                        temp.LastAnnouncement = noHTMLNormalised;
                        WebsitesTemp.Add(temp);

                        PushbulletApi.PushLink(website.Name, noHTMLNormalised, website.Url, website.PushbulletKey, website.ChannelTag);
                    }
                } else { // The page layout has changed
                    PushbulletApi.PushLink(website.Name, "Page layout changed.", website.Url, website.PushbulletKey, website.ChannelTag);
                }
            }

            // Save current settings
            SaveSettings();

            // Exit
            Environment.Exit(0);
        }

        public static void ReadSettings() {
            // User Settings
            String websitesRaw = File.ReadAllText("Settings.json");
            Websites = JsonConvert.DeserializeObject<List<WebsiteSettings>>(websitesRaw);

            // Last status
            if (File.Exists("Temp.json")) {
                String websitesTempRaw = File.ReadAllText("Temp.json");
                WebsitesTemp = JsonConvert.DeserializeObject<List<WebsiteTemporarySettings>>(websitesTempRaw);
            } else {
                WebsitesTemp = new List<WebsiteTemporarySettings>();
            }
        }

        public static void SaveSettings() {
            String raw = JsonConvert.SerializeObject(WebsitesTemp);
            File.WriteAllText("Temp.json", raw);
        }
    }
}
