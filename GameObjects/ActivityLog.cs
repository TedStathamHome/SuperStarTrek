namespace GameObjects
{
    /// <summary>
    /// An activity log for the game's current turn, to be displayed at the end
    /// of the turn.
    /// </summary>
    public class ActivityLog
    {
        /// <summary>
        /// The list of entries currently in the activity log awaiting display.
        /// </summary>
        private List<string> Entries = [];

        /// <summary>
        /// Adds text to the activity log entries.
        /// </summary>
        /// <param name="entryToAdd">The string of text to be added to the activity log.</param>
        public void Add(string entryToAdd)
        {
            Entries.Add(entryToAdd);
        }

        /// <summary>
        /// Clears the activity log. Usually run at the end of a game turn.
        /// </summary>
        public void Clear()
        {
            Entries.Clear();
        }

        /// <summary>
        /// Writes the activity log entries to the console.
        /// </summary>
        public void Display()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
