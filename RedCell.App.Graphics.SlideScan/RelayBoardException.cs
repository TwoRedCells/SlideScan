using System;

namespace RedCell.Devices
{
    /// <summary>
    /// Class RelayBoardException.
    /// </summary>
    internal class RelayBoardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayBoardException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RelayBoardException(string message) : base(message)
        { }
    }
}
