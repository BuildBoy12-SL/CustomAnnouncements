namespace CustomAnnouncements
{
	public static class Extensions
	{
		public static void RAMessage(this CommandSender sender, string message, bool success = true) =>
			sender.RaReply("Custom Announcements#" + message, success, true, string.Empty);
	}
}