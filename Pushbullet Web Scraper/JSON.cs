using System;

namespace Pushbullet_Web_Scraper {
    /// <summary>
    /// Defines a website to scrap.
    /// </summary>
    public class WebsiteSettings {
        public String Id, Name, Url, Xpath, ChannelTag, PushbulletKey, Encoding;
    }

    /// <summary>
    /// Stores last announcement for a website.
    /// </summary>
    public class WebsiteTemporarySettings {
        public String Id, LastAnnouncement;
    }
}
