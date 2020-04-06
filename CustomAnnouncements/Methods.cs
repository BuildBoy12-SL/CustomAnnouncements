using System.Collections.Generic;

namespace CustomAnnouncements
{
    public class Methods
    {
        public Plugin plugin;
        public Methods(Plugin plugin) => this.plugin = plugin;

        public void DoAnnouncement(string config, bool noise)
        {
            PlayerManager.localPlayer.GetComponent<MTFRespawn>().RpcPlayCustomAnnouncement(config, false, noise);
        }

        public static Dictionary<string, string> GetDictonaryValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (!value.Contains(","))
            {
                var splitted = value.Split(':');
                if (splitted.Length != 2)
                    return null;
                dict.Add(value.Split(':')[0], value.Split(':')[1]);
                return dict;
            }
            string[] tl = value.Split(',');
            foreach (string t in tl)
            {
                string[] vl = t.Split(':');
                dict.Add(vl[0], vl[1]);
            }
            return dict;
        }
    }
}
