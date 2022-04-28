using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace xam.course.example1
{
    public class ErrorManager
    {
        private readonly Func<Exception, Task> _errorAction;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly Dictionary<Type, DateTime> _managedException = new Dictionary<Type, DateTime>();

        public ErrorManager(Func<Exception, Task> errorAction)
        {
            this._errorAction = errorAction;
        }

        public async Task AddError(Exception exception)
        {
            await this._semaphore.WaitAsync();

            if (this._managedException.ContainsKey(exception.GetType()))
            {
                var lastEvaluation = this._managedException[exception.GetType()];

                if ((DateTime.Now - lastEvaluation) > TimeSpan.FromSeconds(5))
                    await this._errorAction.Invoke(exception);
            }
            else
                await this._errorAction.Invoke(exception);

            this._managedException[exception.GetType()] = DateTime.Now;
            this._semaphore.Release();
        }
    }
}