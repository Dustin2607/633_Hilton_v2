namespace App.Utility
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Text;

    public abstract class CDisposeHelper : IDisposable
    {
        private bool m_bDisposed;

        public bool Disposed
        {
            get { return m_bDisposed; }
        }

        ~CDisposeHelper()
        {
            Dispose(false);
        }

        #region IDisposable Members

        [MethodImpl(MethodImplOptions.Synchronized)]  
        public void Dispose()  
        {  
            Dispose(true);

            // Use SupressFinalize in case a subclass of this type implements a finalizer.
            GC.SuppressFinalize(this);  
        }

        #endregion

        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.m_bDisposed)
            {
                if (isDisposing)
                {
                    // Cleanup managed resources
                    FreeManagedRessources();
                }

                // Cleanup unmanaged resources
                FreeUnmanagedRessources(); 

                this.m_bDisposed = true;
            }
        }

        protected virtual void FreeManagedRessources()
        {
            // Cleanup managed resources

        }

        protected virtual void FreeUnmanagedRessources()
        {
            // Cleanup unmanaged resources

        }  

    }
}
