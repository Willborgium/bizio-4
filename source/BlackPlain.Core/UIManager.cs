namespace BlackPlain.Core
{
    public static class UIManager
    {
        public static void SetTaskScheduler()
        {
            _taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public static async Task ExecuteAsync(Action action, CancellationToken cancellationToken = default)
        {
            if (_taskScheduler == null)
            {
                throw new InvalidOperationException("Cannot call ExecuteAsync before calling SetTaskScheduler");
            }

            await Task.Factory.StartNew(action, cancellationToken, TaskCreationOptions.None, _taskScheduler);
        }

        private static TaskScheduler? _taskScheduler;
    }
}
