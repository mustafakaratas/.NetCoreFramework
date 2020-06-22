﻿using Castle.Core.Interceptor;
using System;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation ınvocation)
        {

        }

        protected virtual void OnAfter(IInvocation ınvocation)
        {

        }

        protected virtual void OnException(IInvocation ınvocation)
        {

        }

        protected virtual void OnSuccess(IInvocation ınvocation)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}