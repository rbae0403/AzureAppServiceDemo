using NLog;

namespace DemoConsoleApp
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            // log 將會寫入到當前專案目錄的 bin\{運行中的組態}\App_Data\Logs\{今天的日期}
            // 可參考 NLog.config 裡的設定

            Logger.Trace("Using nLog to write a 'trace' message");
            Logger.Debug("Using nLog to write a 'debug' message");
            Logger.Info("Using nLog to write an 'info' message");
            Logger.Warn("Using nLog to write a 'warning' message");
            Logger.Error("Using nLog to write an 'error' message");
            Logger.Fatal("Using nLog to write a 'fatal' message");
        }
    }
}