namespace Application
{
    public class CommandException : Exception
    {
        /// <summary>
        ///     Constructs an exception raised in commands: Add, Update, Delete.
        /// </summary>
        /// <param name="commandCode">0-Add, 1-Update, 2-Update</param>
        /// <param name="message"></param>
        public CommandException(int commandCode, string message) : base(message)
        {
            CommandCode = commandCode;
        }

        /// <summary>
        ///     Constructs an exception raised in a command(Add)
        /// </summary>
        /// <param name="message">Exceptional message</param>
        public CommandException(string message) : this(0, message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public CommandException()
        {

        }
        /// <summary>
        ///     Returns or sets an action command (0-Add, 1-Update, 2-Delete) caused an exception
        /// </summary>
        public int CommandCode { get; set; }
    }
}
