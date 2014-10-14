using System;
using System.Collections.Specialized;
using System.Net;

namespace Pushbullet_Web_Scraper {
    public class PushbulletApi {
        /// <summary>
        /// Pushes a link to pushbullet
        /// </summary>
        /// <param name="title">Notification Title</param>
        /// <param name="body">Notification Body</param>
        /// <param name="url">URL to open when tapping the notification</param>
        /// <param name="apiKey">Pushbullet API key</param>
        /// <param name="channelTag">Channel tag. Empty if no channel</param>
        public static void PushLink(String title, String body, String url, String apiKey, String channelTag) {
            using (var wb = new WebClient()) {
                // Auth
                var auth = new NameValueCollection();

                auth["Authorization"] = "Basic " +
                    Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(apiKey + ":"));

                wb.Headers.Add(auth);

                // Data
                var data = new NameValueCollection();

                data["type"] = "link";
                data["title"] = title;
                data["body"] = body;
                data["url"] = url;

                // Channel tag (if it exists)
                if (channelTag.Trim().Length != 0) data["channel_tag"] = channelTag;

                // Push link
                wb.UploadValues("https://api.pushbullet.com/v2/pushes", "POST", data);
            }
        }

        /// <summary>
        /// Pushes a link to pushbullet
        /// </summary>
        /// <param name="title">Notification Title</param>
        /// <param name="body">Notification Body</param>
        /// <param name="url">URL to open when tapping the notification</param>
        /// <param name="apiKey">Pushbullet API key</param>
        public static void PushLink(String title, String body, String url, String apiKey) {
            PushLink(title, body, url, apiKey, "");
        }
    }
}
